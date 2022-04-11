using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReaderManager : Singleton<ReaderManager>
{
    [SerializeField] private Text storyText;
    [SerializeField] private Image coverImage;

    public void SetupReader(Sprite coverSprite, string story){
        coverImage.sprite = coverSprite;
        storyText.text = story;

        LayoutRebuilder.ForceRebuildLayoutImmediate(storyText.rectTransform);
    }
}
