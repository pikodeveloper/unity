using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : Singleton<BookManager>
{
    [SerializeField] private GameObject mainBook;
    [SerializeField] private GameObject frontPage;
    [SerializeField] private GameObject readerPage;    

    [SerializeField] private Sprite[] bookSprites_0;
    [SerializeField] private Text storyText;

    private enum BookState
    {
        FrontPage,
        ReaderPage
    }

    private BookState bookState;   

    private Book currentBook;
    private Sprite currentBookCover;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void OpenMainBook(Book book, Sprite coverSprite){

        //Open Main Book
        mainBook.SetActive(true);        
        currentBook = book;
        currentBookCover = coverSprite;
        BookPageManager.Instance.OpenBook(book, coverSprite);
        bookState = BookState.FrontPage;
    }

    public void Read(){
        BookStoryController.Instance.CallShowAPI(currentBook.slug);
    }

    public void OpenReaderPage(string story){
        frontPage.SetActive(false);
        readerPage.SetActive(true);
        bookState = BookState.ReaderPage;

        ReaderManager.Instance.SetupReader(currentBookCover, story);
        
    }

    public void Back(){
        switch (bookState)
        {
            case BookState.FrontPage :
                mainBook.SetActive(false);
                break;
            case BookState.ReaderPage :
                readerPage.SetActive(false);
                frontPage.SetActive(true);
                bookState = BookState.FrontPage;
                break;
            default:
                break;
        }
    }
}
