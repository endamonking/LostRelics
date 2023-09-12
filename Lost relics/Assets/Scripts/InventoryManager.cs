using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
   
    public GameObject inventoryItemPrefab;
    public InventorySlot[] inventorySlots;
    public InventorySlotHelmet PlayerHelmetSlot;
    public InventorySlotArmor PlayerArmorSlot;
    public InventorySlotBoot PlayerBootSlot;
    public InventorySlotHelmet  helmetSlot;
    public InventorySlotArmor  armorSlot;
    public InventorySlotBoot  bootSlot;
    public void AddItem(Item item)
    {
        int succes = 0;
        for(int i=0; i<inventorySlots.Length && succes ==0;i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null)
            {
                succes++;
                SpawnNewItem(item, slot);
                inventory.itemList[i] =item;
            }
        }
    }
    public void LoadItemInInventory()
    {
        for(int i =0; i < inventory.itemList.Count;i++)   
        {   
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            itemInSlot = null;
            if (inventory.itemList[i] != null)
            { Item item= inventory.itemList[i];
                SpawnNewItem(item, slot);
            }
        }
        if (inventory.playerEquippedArmor != null)
        {
            Item item = inventory.playerEquippedArmor;
            PlayerArmorSlot.GetComponentInChildren<InventoryItem>();
            SpawnEquipedArmor(item, PlayerArmorSlot);
        }
        if (inventory.playerEquippedHelmet != null)
        {
            Item item = inventory.playerEquippedHelmet;
            PlayerHelmetSlot.GetComponentInChildren<InventoryItem>();
            SpawnEquipedHelmet(item, PlayerHelmetSlot);
        }
        if (inventory.playerEquippedBoot != null)
        {
            Item item = inventory.playerEquippedHelmet;
            PlayerHelmetSlot.GetComponentInChildren<InventoryItem>();
            SpawnEquipedBoot(item, PlayerBootSlot);
        }
        if (inventory.equippedHelmet)
        {
            Item item = inventory.equippedHelmet;
            SpawnEquipedHelmet(item, helmetSlot);
        }
        if (inventory.equippedArmor)
        {
            Item item = inventory.equippedArmor;
            SpawnEquipedArmor(item, armorSlot);
        }
        if (inventory.equippedBoot)
        {
            Item item = inventory.equippedBoot;
            SpawnEquipedBoot(item, bootSlot);
        }
    }

    public void UpdateInventoryItems()
    {
        if (PlayerHelmetSlot.transform.childCount != 0)
        {
            InventoryItem inventoryItem = PlayerHelmetSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipHelmet(inventoryItem.item, 0);
        }
        if (PlayerArmorSlot.transform.childCount != 0)
        {
            InventoryItem inventoryItem = PlayerArmorSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipArmor(inventoryItem.item, 0);
        }
        if (PlayerBootSlot.transform.childCount != 0)
        {
            InventoryItem inventoryItem = PlayerBootSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipBoot(inventoryItem.item, 0);
        }
        if (helmetSlot.transform.childCount != 0)
        {
            InventoryItem inventoryItem = helmetSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipHelmet(inventoryItem.item, 1);
        }
        if (armorSlot.transform.childCount != 0)
        {
            InventoryItem inventoryItem = armorSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipArmor(inventoryItem.item, 1);
        }
        if (bootSlot.transform.childCount != 0)
        {
            InventoryItem inventoryItem = bootSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipBoot(inventoryItem.item, 1);
        }
    }
    void SpawnEquipedArmor(Item item, InventorySlotArmor slot)
    {
        GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    void SpawnEquipedHelmet(Item item, InventorySlotHelmet slot)
    {
        GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    void SpawnEquipedBoot(Item item, InventorySlotBoot slot)
    {
        GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    void SpawnNewItem(Item item,InventorySlot slot){
        GameObject spawnItemInSlot =  Instantiate(inventoryItemPrefab,slot.transform);
        InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

}
