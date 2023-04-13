using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            var dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();

            if(eventData.pointerDrag.CompareTag(gameObject.tag))
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                dragDrop.inSlot = true;
                Debug.Log("a");

            }
            else if(eventData.pointerDrag.CompareTag("Accessory"))
            {
                dragDrop.inSlot = true;
                Debug.Log("aa");
            }

            Debug.Log(eventData.pointerDrag.name);
        }
    }
}
