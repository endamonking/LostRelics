using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bin : MonoBehaviour, IDropHandler
{
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
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

        if (inventoryItem != null)
        {
            Destroy(inventoryItem.gameObject);
            inventoryManager.UpdateInventoryItems();
        }
    }


}
