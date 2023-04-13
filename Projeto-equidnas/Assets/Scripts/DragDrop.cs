using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [HideInInspector]
    public Vector3 initialPosition;
    public bool inSlot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initialPosition = GetComponent<RectTransform>().position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        if(gameObject.CompareTag("Accessory"))
        {
            inSlot = true;
            return;
        }
        inSlot = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag"); 
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if(inSlot == false)
        {
            rectTransform.position = initialPosition;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    
    void Update()
    {
        
    }
}
