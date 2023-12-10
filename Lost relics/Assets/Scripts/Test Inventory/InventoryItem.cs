using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    [Header("UI")]
    public Image image;
    private InventoryManager inventoryManager;
    public GameObject itemStatsPopupPrefab;
    private GameObject itemStatsPopup;
    private bool isDragging = false;  
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform parentBeforeDrag;

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isDragging) // Show the popup only if not dragging
        {
            itemStatsPopup = Instantiate(itemStatsPopupPrefab, transform.position + new Vector3(0, 50, -1), Quaternion.identity);
            itemStatsPopup.transform.SetParent(transform); // Set the popup's parent to the inventory item

            // Customize the popup to display item stats based on the item data
            ItemStatsPopup popupScript = itemStatsPopup.GetComponent<ItemStatsPopup>();
            if (popupScript != null)
            {
                // Assuming 'item' is a reference to the current item
                popupScript.DisplayStats(item); // Pass the item's information to display in the popup
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(itemStatsPopup);
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
        isDragging = true;
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition; 
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        inventoryManager.UpdateInventoryItems();
    }                                                                                       
}
