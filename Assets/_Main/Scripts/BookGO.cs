using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BookGO : MonoBehaviour
{
    [SerializeField] private Image coverImage;
    [SerializeField] private Text titleText;
    [SerializeField] private Text publisherText;

    private Book book;
    private Sprite coverSprite;
    

    public void Open(){
        BookManager.Instance.OpenMainBook(book, coverSprite);
    }

    public void Setup(Book book){
        
        this.book = book;

        titleText.text = book.title;
        publisherText.text = book.publisher.name;
        
        
        if(book.coverBase64Encoded != null){
            byte[] imageBytes = Convert.FromBase64String(book.coverBase64Encoded);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage( imageBytes );
            coverSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            coverImage.sprite = coverSprite;
        }
        
    }
    
}
