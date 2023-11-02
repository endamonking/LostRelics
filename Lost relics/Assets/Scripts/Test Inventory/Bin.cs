using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bin : MonoBehaviour, IDropHandler
{
    public InventoryManager inventoryManager;

    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

        if (inventoryItem != null)
        {
            // Destroy the dropped item's GameObject.
            Destroy(inventoryItem.gameObject);

            // Update the inventory after destroying an item.
            inventoryManager.UpdateInventoryItems();
        }
    }


}
