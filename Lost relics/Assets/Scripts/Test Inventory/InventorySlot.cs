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
                int newSlotIndex = GetSlotIndex();
                
                inventory.MoveItem(inventoryItem.item, GetSlotIndex());
            
            
        }
        else if(transform.childCount == 1)
        {
      
            InventoryItem droppedItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventoryItem currentItem = transform.GetChild(0).GetComponent<InventoryItem>();
            InventorySlotHelmet inventorySlotHelmet = droppedItem.parentBeforeDrag.GetComponentInParent<InventorySlotHelmet>();
            InventorySlotArmor inventorySlotArmor = droppedItem.parentBeforeDrag.GetComponentInParent<InventorySlotArmor>();
            InventorySlotBoot inventorySlotBoot = droppedItem.parentBeforeDrag.GetComponentInParent<InventorySlotBoot>();

            if ((inventorySlotHelmet == null) && (inventorySlotArmor == null) && (inventorySlotBoot == null))
            {
                Debug.Log(droppedItem.parentBeforeDrag);

                currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                int newSlotIndex = GetSlotIndex();
                // Debug.Log("New slot index: " + newSlotIndex);
                droppedItem.parentAfterDrag = transform;
                inventory.MoveItem(droppedItem.item, GetSlotIndex());
            }
            else {
                switch (droppedItem.item.itemType)
                {
                    case ItemType.Helmet:
                        // Debug.Log(droppedItem.parentBeforeDrag);
                        if (currentItem.item.itemType == ItemType.Helmet)
                        {
                            currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                            currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                            int newSlotIndex = GetSlotIndex();
                            droppedItem.parentAfterDrag = transform;
                            Debug.Log("From Equip To Inventory");
                            inventory.MoveItem(droppedItem.item, GetSlotIndex());
                        }
                        break;
                    case ItemType.Armor:
                        if (currentItem.item.itemType == ItemType.Armor)
                        { 
                            currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                            currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                            int newSlotIndex = GetSlotIndex();
                            droppedItem.parentAfterDrag = transform;
                            inventory.MoveItem(droppedItem.item, GetSlotIndex());
                        }
                        break;
                    case ItemType.Boot:
                        if (currentItem.item.itemType == ItemType.Boot)
                        {
                            currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                            currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                            int newSlotIndex = GetSlotIndex();
                            droppedItem.parentAfterDrag = transform;
                            inventory.MoveItem(droppedItem.item, GetSlotIndex());
                        }
                        break;
                    default:
                         
                        break;
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
            //Debug.Log("ReferenceEquals(inventoryManager.inventorySlots[i], this)" + ReferenceEquals(inventoryManager.inventorySlots[i], this) + this + inventoryManager.inventorySlots[i]+i);
            if (inventoryManager.inventorySlots[i]==this)
            {
              //  Debug.Log("Found slot at index: " + i);
                return i;
            }
        }

        // Slot not found
       // Debug.LogError("Slot not found in inventorySlots array");
        return -1;
    }
}
