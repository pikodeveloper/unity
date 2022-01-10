using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPageManager : Singleton<BookPageManager>
{

    
    private Sprite[] bookSprites;
    private int bookIndex;
    private int bookPageIndex;
    private int pageCount;

    [SerializeField] private GameObject bookPagePrefab;

    [Header("UI")]
    [SerializeField] private GameObject frontPage;
    [SerializeField] private Image coverImage;
    [SerializeField] private Text titleText;
    [SerializeField] private Text descText;
    [SerializeField] private Text authorText;
    [SerializeField] private Text illustratorText;
    [SerializeField] private Text readingTimeText;
    [SerializeField] private Text pageCountText;
    [SerializeField] private Text ageRangeText;
    [SerializeField] private Text publisherText;

    [SerializeField] private Image loveImage;
    [SerializeField] private Sprite[] loveSprites;
    
    void Awake(){
        
    }

    public void OnSwipeLeft(){
        if(bookPageIndex < pageCount){
            transform.GetChild(bookPageIndex).gameObject.SetActive(false);
            bookPageIndex++;
            transform.GetChild(bookPageIndex).gameObject.SetActive(true);
            Debug.Log("I am Swaping Left");
        }
    }

    public void OnSwipeRight(){
        if(bookPageIndex > 0){
            transform.GetChild(bookPageIndex).gameObject.SetActive(false);
            bookPageIndex--;
            transform.GetChild(bookPageIndex).gameObject.SetActive(true);
            Debug.Log("I am Swaping Right");
        }
    }

    public void OpenBook(Book openedBook, int openedBookIndex){
        
        bookIndex = openedBookIndex;
        pageCount = bookSprites.Length;
        bookPageIndex = 0;

        //Set Loved Image
        if(BookManager.Instance.GetBook(bookIndex).GetLoved()){            
            loveImage.sprite = loveSprites[1];
        }else{            
            loveImage.sprite = loveSprites[0];
        }

        //Change Front Page Variables
        frontPage.SetActive(true);
        coverImage.sprite = bookSprites[0];        
        titleText.text = openedBook.GetTitle();
        descText.text = openedBook.GetDescription();
        authorText.text = openedBook.GetAuthor();
        illustratorText.text = openedBook.GetIllustrator();
        readingTimeText.text = openedBook.GetReadingTime() + " menit";
        pageCountText.text = openedBook.GetPageCount();
        ageRangeText.text = openedBook.GetAgeRange();
        publisherText.text = openedBook.GetPublisher();

        //Destroy previous bookPage
        for (int i = 1; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        //Instantiate bookPage
        for (int i = 0; i < bookSprites.Length; i++)
        {
            
            GameObject newPage = Instantiate(bookPagePrefab, transform);
            newPage.GetComponent<Image>().sprite = bookSprites[i];
            newPage.name = "Page_" + i;
            
            SetPageSize(newPage.GetComponent<RectTransform>());
            
        }

        
        
    }

    void SetPageSize(RectTransform pageRect){
        
            pageRect.anchorMin = new Vector2(0,0.5f);
            pageRect.anchorMax = new Vector2(1,0.5f);

            //right
            pageRect.offsetMax = new Vector2(0, pageRect.offsetMax.y);
            //left
            pageRect.offsetMin = new Vector2(0, pageRect.offsetMin.y);
            
            float stretchedWidth = pageRect.rect.width;

            pageRect.anchorMin = new Vector2(0.5f,0.5f);
            pageRect.anchorMax = new Vector2(0.5f,0.5f);
            
            pageRect.sizeDelta = new Vector2(stretchedWidth,stretchedWidth);
    }

    public void SetBookSprites(Sprite[] bookSprites){
        this.bookSprites = null;
        this.bookSprites = bookSprites;
    }

    public void LoveBook(){
        if(BookManager.Instance.GetBook(bookIndex).GetLoved()){
            BookManager.Instance.GetBook(bookIndex).SetLoved(false);
            loveImage.sprite = loveSprites[0];
        }else{
            BookManager.Instance.GetBook(bookIndex).SetLoved(true);
            loveImage.sprite = loveSprites[1];
        }
    }
}
