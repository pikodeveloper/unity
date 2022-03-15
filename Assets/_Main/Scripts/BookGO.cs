using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookGO : MonoBehaviour
{
    [SerializeField] private Image coverImage;

    [SerializeField] private Sprite[] coverSpriteTemps;
    [SerializeField] private Text titleText;
    [SerializeField] private Text publisherText;

    public void Setup(Book book){
        titleText.text = book.title;
        publisherText.text = book.publisher.name;

        coverImage.sprite = coverSpriteTemps[Random.Range(0,coverSpriteTemps.Length)];
    }
    
}
