using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class InventorySlotHelmet : MonoBehaviour, IDropHandler
{
    public Inventory inventory;

    public InventoryManager inventoryManager;
    public int character;
    public GameObject PlayerSlot;
    public void OnDrop(PointerEventData eventData)
    {
        if (PlayerSlot.activeSelf)
        {
            character = 0;
        }
        else if (!PlayerSlot.activeSelf)
        {
            character = 1;
        }
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (inventoryItem.item.itemType == ItemType.Helmet)
        {
            if (transform.childCount == 0)
            {
 
                inventoryItem.parentAfterDrag = transform;
                inventory.EquipHelmet(inventoryItem.item, character);
                inventory.RemoveItem(inventoryItem.item);
            }

            else if (transform.childCount == 1)
            {
               
                InventoryItem droppedItem = eventData.pointerDrag.GetComponent<InventoryItem>();
                InventoryItem currentItem = transform.GetChild(0).GetComponent<InventoryItem>();
               // Debug.Log(currentItem.item.itemType == ItemType.Helmet);
                if ( currentItem.item.itemType == ItemType.Helmet)
                {
                   // Debug.Log("currentItem.item.itemName" + currentItem.item.itemName);
                   // Debug.Log("droppedItem " + droppedItem.item.itemName);


                    int previousParentSlotIndex = GetSlotIndex(droppedItem.parentBeforeDrag);
                    currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                    currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                    
                    droppedItem.parentAfterDrag = transform;



                    //   Debug.Log("From Inventory to  Equip");
                    //   Debug.Log("currentItem.item.itemName" + currentItem.item.itemName);
                    //  Debug.Log("droppedItem " + droppedItem.item.itemName);

                    Item swappedItem = droppedItem.item;
                    inventory.EquipHelmet(droppedItem.item, character);

                    inventory.MoveItem(currentItem.item, previousParentSlotIndex);

                    //inventory.RemoveItem(currentItem.item);
                    //inventory.EquipHelmet(droppedItem.item, character);

                    inventoryManager.UpdateInventoryItems();
                }
            }
        }
    }
    int GetSlotIndex(Transform slotTransform)
    {
        // Find the index of the given slot in the inventorySlots array
        for (int i = 0; i < inventoryManager.inventorySlots.Length; i++)
        {
            if (inventoryManager.inventorySlots[i].transform == slotTransform)
            {
                return i;
            }
        }

        // Slot not found
        Debug.LogError("Slot not found in inventorySlots array");
        return -1;
    }

}
