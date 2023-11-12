using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class InventorySlotHelmet : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    private EquipmentStats equipmentStats;
    public InventoryManager inventoryManager;
    public int character;
    public GameObject PlayerUI;
    public void OnDrop(PointerEventData eventData)
    {
        PlayerStatsUI UI = PlayerUI.GetComponent<PlayerStatsUI>();
        character = UI.character;
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (inventoryItem.item.itemType == ItemType.Helmet)
        {
            if (transform.childCount == 0)
            {
 
                inventoryItem.parentAfterDrag = transform;
                inventory.EquipHelmet(inventoryItem.item, character);
                equipmentStats.UpdateStat();
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

                    equipmentStats.UpdateStat();
                }
            }
        }
    }

 

}
