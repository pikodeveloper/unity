using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : Singleton<BookManager>
{
    [SerializeField] private GameObject mainBookPage;
    [SerializeField] private List<Book> books = new List<Book>();

    [SerializeField] private Sprite[] bookSprites_0;
    [SerializeField] private Sprite[] bookSprites_1;
    [SerializeField] private Sprite[] bookSprites_2;
    [SerializeField] private Sprite[] bookSprites_3;
    [SerializeField] private Sprite[] bookSprites_4;
    [SerializeField] private Sprite[] bookSprites_5;
   


    // Start is called before the first frame update
    void Start()
    {
        AssignBooks();
    }

    public void ChooseBookToOpen(int bookIndex){
        mainBookPage.SetActive(true);
        

        Sprite[] tempBookSprites = null;
        switch (bookIndex)
        {
            case 0:
                tempBookSprites = bookSprites_0;
                break;
            case 1:
                tempBookSprites = bookSprites_1;
                break;
            case 2:
                tempBookSprites = bookSprites_2;
                break;
            case 3:
                tempBookSprites = bookSprites_3;
                break;
            case 4:
                tempBookSprites = bookSprites_4;
                break;
            case 5:
                tempBookSprites = bookSprites_5;
                break;
            default:
                tempBookSprites = bookSprites_0;
                break;
        }

        //
        BookPageManager.Instance.SetBookSprites(tempBookSprites);

        //Open Book
        BookPageManager.Instance.OpenBook(books[bookIndex], bookIndex);
    }

    void AssignBooks(){

        books.Add(new Book("ABC Ayo Belajar Membaca",
         "Kumpulan bentuk-bentuk huruf Alphabet beserta contohnya" ,
         "Nasir Nugroho", "Nasir Nugroho", "5-10", "27", "2-5", "PIKO")
         );

        books.Add(new Book("Belajar Sholat Bersama Ali",
         "Buku belajar sholat, mengenalkan anak gerakan-gerakan dasar sholat" ,
         "Bilal Surya", "Bilal Surya", "5-10", "13", "7-11", "PIKO")
         );

         books.Add(new Book("Mengenal Banyak Hewan",
         "Ayo mengenal nama-nama hewan!" ,
         "Nasir Nugroho", "Nasir Nugroho", "5-10", "30", "2-7", "PIKO")
         );
    }

    public Book GetBook(int bookIndex){
        return books[bookIndex];
    }
}
