using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaylistGO : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private Transform bookListHolder;
    [SerializeField] private SecondScrollRect secondScrollRect;
    [SerializeField] private GameObject bookGOPrefab;

    public void Setup(ScrollRect otherScrollRect, Bookplaylist bookplaylist){
        secondScrollRect.OtherScrollRect = otherScrollRect;

        titleText.text = bookplaylist.title;

        foreach (Book book in bookplaylist.books)
        {
            InstantiateBookGO(book);
        }
        
    }

    private void InstantiateBookGO(Book book){
        GameObject bookGO = Instantiate(bookGOPrefab, bookListHolder);
        BookGO bookGOComponent = bookGO.GetComponent<BookGO>();
        bookGOComponent.Setup(book);
    }
}
