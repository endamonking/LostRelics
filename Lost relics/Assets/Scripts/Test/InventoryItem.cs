using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    [Header("UI")]
    public Image image;


    [HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem) {
        image.sprite = newItem.icon;
    }
    private void Start()
    {
        InitialiseItem(item);
    }
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("BeginDrag");
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        Debug.Log("BeginDrag transform.parent = " + parentAfterDrag);
        transform.SetParent(transform.root);
        Debug.Log("BeginDrag transform.root = " + transform.root);


    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition; 
    }
    public void OnEndDrag(PointerEventData eventData)
    {image.raycastTarget = true;
 
        Debug.Log("EndDrag = " + parentAfterDrag);
        transform.SetParent(parentAfterDrag);
        

    }
}
