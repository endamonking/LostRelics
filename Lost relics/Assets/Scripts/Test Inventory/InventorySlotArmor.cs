using UnityEngine.EventSystems;
using UnityEngine;

public class InventorySlotArmor : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    public int character;
    private EquipmentStats equipmentStats; 
    public InventoryManager inventoryManager;
    public GameObject PlayerUI;
    public void OnDrop(PointerEventData eventData)
    {

        PlayerStatsUI UI = PlayerUI.GetComponent<PlayerStatsUI>();
        character = UI.character;
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (inventoryItem.item.itemType == ItemType.Armor)
        {
            if (transform.childCount == 0)
            {
                // Move the dropped item to this slot
                inventoryItem.parentAfterDrag = transform;
                inventory.EquipArmor(inventoryItem.item, character);
                UI.UpdateStat( );
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
                    UI.UpdateStat( );
                }
            }
        }
    }
 
}