using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideCloset : MonoBehaviour
{
    public bool isOpen;
    public Sprite closedCloset;
    public Sprite openCloset;

    public void Awake()
    {
        UpdateSprites();
        if(isOpen)
        {
            GetComponent<Image>().sprite = openCloset;
        }
        else
        {
            GetComponent<Image>().sprite = closedCloset;
        }
    }

    public void UpdateSprites()
    {
        foreach (Transform child in transform) 
        {
            DragDrop dragDrop = child.GetComponent<DragDrop>();
            if(dragDrop != null)
            {
                dragDrop.gameObject.SetActive(isOpen || dragDrop.inSlot);
            }
        }
    }

    public void Toggle()
    {
        isOpen = !isOpen;
        UpdateSprites();
        if(isOpen)
        {
            GetComponent<Image>().sprite = openCloset;
        }
        else
        {
            GetComponent<Image>().sprite = closedCloset;
        }
    }
}
