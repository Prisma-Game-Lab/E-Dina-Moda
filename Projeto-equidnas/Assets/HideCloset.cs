using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCloset : MonoBehaviour
{
    public bool isOpen;

    public void Awake()
    {
        UpdateSprites();
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
    }
}
