using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class InventorySlotHelmet : MonoBehaviour, IDropHandler
{
    
     
        
    private int character;
    public GameObject PlayerUI;
    private InventoryManager inventoryManager;

    void Start()
    {
         
        inventoryManager = FindObjectOfType<InventoryManager>();

        if (inventoryManager == null)
        {
            Debug.LogError("No InventoryManager found in the scene.");
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        PlayerStatsUI UI = PlayerUI.GetComponent<PlayerStatsUI>();
        EquipmentStats stats = PlayerUI.GetComponent<EquipmentStats>();
        character = UI.character;
        
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (inventoryItem.item.itemType == ItemType.Helmet)
        {
            if (transform.childCount == 0)
            {
                
                inventoryItem.parentAfterDrag = transform;
                inventoryManager.inventory.EquipHelmet(inventoryItem.item, character);
                stats.UpdateStat(character);
            }

            else if (transform.childCount == 1)
            {

                InventoryItem currentItem = transform.GetChild(0).GetComponent<InventoryItem>();
                if (currentItem.item.itemType == ItemType.Helmet)
                {
  
                        InventoryItem droppedItem = eventData.pointerDrag.GetComponent<InventoryItem>();

                    currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                    currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                    droppedItem.parentAfterDrag = transform;

                    stats.UpdateStat(character);
                }
            }
        }
    }

 

}
