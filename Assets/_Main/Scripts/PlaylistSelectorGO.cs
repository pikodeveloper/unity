using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaylistSelectorGO : MonoBehaviour
{
    [SerializeField] private Text titleText;
    
    public void Setup(Bookplaylist bookplaylist){
        

        titleText.text = bookplaylist.title;

        
        
    }
    
}
