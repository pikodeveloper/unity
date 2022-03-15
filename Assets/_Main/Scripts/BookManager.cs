using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : Singleton<BookManager>
{
    [SerializeField] private GameObject mainBook;
    [SerializeField] private GameObject frontPage;
    [SerializeField] private GameObject readerPage;    

    [SerializeField] private Sprite[] bookSprites_0;

    private enum BookState
    {
        FrontPage,
        ReaderPage
    }

    private BookState bookState;   


    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void ChooseBookToOpen(int bookIndex){
        mainBook.SetActive(true);        

        Sprite[] tempBookSprites = null;
        switch (bookIndex)
        {
            case 0:
                tempBookSprites = bookSprites_0;
                break;
            
            default:
                tempBookSprites = bookSprites_0;
                break;
        }

        //
        BookPageManager.Instance.SetBookSprites(tempBookSprites);

        //Open Book
        // BookPageManager.Instance.OpenBook(books[bookIndex], bookIndex);
        bookState = BookState.FrontPage;
    }

    public void Read(){
        frontPage.SetActive(false);
        readerPage.SetActive(true);
        bookState = BookState.ReaderPage;
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
