using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellSlot : MonoBehaviour, IDropHandler
{
    private InventoryManager inventoryManager;
    void Start()
    {

        inventoryManager = FindObjectOfType<InventoryManager>();

        if (inventoryManager == null)
        {
            Debug.LogError("No InventoryManager found in the scene.");
        }
        gameObject.SetActive(false);
    }
    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

        inventoryManager.inventory.money = inventoryManager.inventory.money + inventoryItem.item.sell;
        Debug.Log("inventoryManager.inventory.money" + inventoryManager.inventory.money);
        if (inventoryItem != null)
        {
            Destroy(inventoryItem.gameObject);

            inventoryManager.UpdateInventoryItems();
            gameObject.SetActive(false);
        }
       
    }
}
