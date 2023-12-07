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
    public InventoryManager inventoryManager;

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform parentBeforeDrag;
    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    public void InitialiseItem(Item newItem) {

        item= newItem;
        image.sprite = newItem.icon;
    }
  
    public void OnBeginDrag(PointerEventData eventData) {
        // Debug.Log("BeginDrag");
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        parentBeforeDrag= transform.parent;
        transform.SetParent(transform.root);
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition; 
    }
    public void OnEndDrag(PointerEventData eventData)
    {   image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        inventoryManager.UpdateInventoryItems();
    }                                                                                       
}
