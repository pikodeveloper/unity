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
        if(bookPageIndex < pageCount - 1){
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

    public void OpenBook(Book openedBook, Sprite coverSprite){                       

        //Change Front Page Variables
        frontPage.SetActive(true);
        coverImage.sprite = coverSprite;        
        titleText.text = openedBook.title;
        descText.text = openedBook.description;
        authorText.text = openedBook.author_name;
        illustratorText.text = openedBook.illustrator_name;
        readingTimeText.text = openedBook.reading_minute + " Menit";        
        ageRangeText.text = openedBook.age_min + " - " + openedBook.age_max + " Tahun";
        publisherText.text = openedBook.publisher.name;

        //Destroy previous bookPage
        for (int i = 1; i < transform.childCount; i++)
        {
            // Destroy(transform.GetChild(i).gameObject);
            // transform.GetChild(i).gameObject.SetActive(false);
        }

        //Instantiate bookPage
        // for (int i = 0; i < bookSprites.Length; i++)
        // {
        //     if(i == 0){
        //         continue;
        //     }
            
        //     GameObject newPage = Instantiate(bookPagePrefab, transform);
        //     newPage.GetComponent<Image>().sprite = bookSprites[i];
        //     newPage.name = "Page_" + i;
            
        //     SetPageSize(newPage.GetComponent<RectTransform>());
            
        // }

        
        
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

    
}
