using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
   
    public GameObject inventoryItemPrefab;
    public InventorySlot[] inventorySlots;
   // public InventorySlotHelmet PlayerHelmetSlot;
    //public InventorySlotArmor PlayerArmorSlot;
    //public InventorySlotBoot PlayerBootSlot;
    //public InventorySlotHelmet  helmetSlot;
    //public InventorySlotArmor  armorSlot;
    //public InventorySlotBoot  bootSlot;
    public void AddItem(Item Item)
    {
        int succes = 0;
        for(int i=0; i<inventorySlots.Length && succes ==0;i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null)
            {
                succes++;
                SpawnNewItem(Item, slot);
                inventory.itemList[i] = Instantiate(Item);
            }
        }
    }
   
    void SpawnNewItem(Item item,InventorySlot slot){
        GameObject spawnItemInSlot =  Instantiate(inventoryItemPrefab,slot.transform);
        InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

}
