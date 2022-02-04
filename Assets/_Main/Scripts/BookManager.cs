using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : Singleton<BookManager>
{
    [SerializeField] private GameObject mainBook;
    [SerializeField] private GameObject frontPage;
    [SerializeField] private GameObject readerPage;
    [SerializeField] private List<Book> books = new List<Book>();

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
        AssignBooks();
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
        BookPageManager.Instance.OpenBook(books[bookIndex], bookIndex);
        bookState = BookState.FrontPage;
    }

    void AssignBooks(){

        books.Add(new Book("ABC Ayo Belajar Membaca",
         "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim" ,
         "Risma El Jundi", "Someone", "5-10", "27", "2-5", "PIKO Original")
         );

        
    }

    public Book GetBook(int bookIndex){
        return books[bookIndex];
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
