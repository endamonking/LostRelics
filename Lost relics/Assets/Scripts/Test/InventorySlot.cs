using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    public InventoryManager inventoryManager;
    public void OnDrop(PointerEventData eventData)
    {   
        if (transform.childCount == 0)
        {  
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
            inventory.MoveItem(inventoryItem.item, GetSlotIndex());
        }
        else if(transform.childCount == 1)
        {
           
            InventoryItem droppedItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventoryItem currentItem = transform.GetChild(0).GetComponent<InventoryItem>();
            currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
            currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
            droppedItem.parentAfterDrag = transform;
            inventory.MoveItem(droppedItem.item, GetSlotIndex());

        }
    }
    int GetSlotIndex()
    {
        // Find the index of this slot in the inventorySlots array
        for (int i = 0; i < inventoryManager.inventorySlots.Length; i++)
        {
            if (inventoryManager.inventorySlots[i] == this)
            {
                return i;
            }
        }

        // Slot not found
        return -1;
    }
}
