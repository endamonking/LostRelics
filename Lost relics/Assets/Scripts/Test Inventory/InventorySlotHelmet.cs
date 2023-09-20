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
            }

            else if (transform.childCount == 1)
            {

                InventoryItem currentItem = transform.GetChild(0).GetComponent<InventoryItem>();
                if (currentItem.item.itemType == ItemType.Helmet)
                {
                    // Swap the dropped item with the current item in this slot
                    InventoryItem droppedItem = eventData.pointerDrag.GetComponent<InventoryItem>();

                    currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                    currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                    droppedItem.parentAfterDrag = transform;


                }
            }
        }
    }

 

}
