using UnityEngine.EventSystems;
using UnityEngine;
using System.Threading;

public class InventorySlotBoot : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    public int character;
    public InventoryManager inventoryManager;
    public GameObject PlayerSlot;
    public void OnDrop(PointerEventData eventData)
    { if (PlayerSlot.activeSelf)
        {
            character = 0;
        }
        else if(!PlayerSlot.activeSelf) {
            character = 1;
        }
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (inventoryItem.item.itemType == ItemType.Boot)
        {
            if (transform.childCount == 0)
            {
                // Move the dropped item to this slot
                inventoryItem.parentAfterDrag = transform;
                inventory.EquipBoot(inventoryItem.item, character);
            }
            else if (transform.childCount == 1)
            {
                InventoryItem currentItem = transform.GetChild(0).GetComponent<InventoryItem>();
                if (currentItem.item.itemType == ItemType.Boot)
                {
                    // Swap the dropped item with the current item in this slot
                    InventoryItem droppedItem = eventData.pointerDrag.GetComponent<InventoryItem>();
                    
                    currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                    currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                    droppedItem.parentAfterDrag = transform;
                    inventory.EquipBoot(droppedItem.item, character);
                    inventoryManager.UpdateInventoryItems();
                    inventory.MoveItem(droppedItem.item, GetSlotIndex());
                }
            }
        }
    }

 

    int GetSlotIndex()
    {


       // Debug.Log("This: " + this);
        // Find the index of this slot in the inventorySlots array
        for (int i = 0; i < inventoryManager.inventorySlots.Length; i++)
        {
            //Debug.Log("ReferenceEquals(inventoryManager.inventorySlots[i], this)" + ReferenceEquals(inventoryManager.inventorySlots[i], this) + this + inventoryManager.inventorySlots[i] + i);
            if (inventoryManager.inventorySlots[i] == this)
            {
               // Debug.Log("Found slot at index: " + i);
                return i;
            }
        }

        // Slot not found
       // Debug.LogError("Slot not found in inventorySlots array");
        return -1;
    }
}

