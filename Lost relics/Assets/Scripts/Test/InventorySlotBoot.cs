using UnityEngine.EventSystems;
using UnityEngine;

public class InventorySlotBoot : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    public int character;
    public void OnDrop(PointerEventData eventData)
    {
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
                // Swap the dropped item with the current item in this slot
                InventoryItem droppedItem = eventData.pointerDrag.GetComponent<InventoryItem>();
                InventoryItem currentItem = transform.GetChild(0).GetComponent<InventoryItem>();
                currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                droppedItem.parentAfterDrag = transform;
                inventory.EquipBoot(droppedItem.item, character);
            }
        }
    }
}

