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
               
            }
        }
        LoadItemInInventory();
      

    }
    void Start()
    {
        LoadItemInInventory();
    }
    public void LoadItemInInventory()
    {
        for(int i =0; i < inventory.itemList.Count;i++)
        {   
            if(inventory.itemList[i] != null)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                itemInSlot = null;
                Item item= inventory.itemList[i];
                SpawnNewItem(item, slot);
            }
        }
        if(inventory.playerEquippedArmor != null)
        {
            Item item = inventory.playerEquippedArmor;
            if(item.itemType == ItemType.Armor)
                SpawnEquipedArmor(item, PlayerArmorSlot);
        }
        if(inventory.playerEquippedHelmet != null)
        {
            Item item = inventory.playerEquippedHelmet;
            if (item.itemType == ItemType.Helmet)
                SpawnEquipedHelmet(item, PlayerHelmetSlot);
        }
        if(inventory.playerEquippedBoot != null)
        {
            Item item = inventory.playerEquippedBoot;
            if (item.itemType == ItemType.Boot)
                SpawnEquipedBoot(item, PlayerBootSlot);
        }
        if(inventory.equippedHelmet != null)
        {
            Item item = inventory.equippedHelmet;
            if (item.itemType == ItemType.Helmet)
                SpawnEquipedHelmet(item, helmetSlot);
        }
        if(inventory.equippedArmor != null)
        {
            Item item = inventory.equippedArmor;
            if (item.itemType == ItemType.Armor)
                SpawnEquipedArmor(item, armorSlot);
        }
        if(inventory.equippedBoot != null)
        {
            Item item = inventory.equippedBoot;
            if (item.itemType == ItemType.Boot)
                SpawnEquipedBoot(item, bootSlot);
        }
    }

    public void UpdateInventoryItems()
    {
        // Clear the current itemList
        inventory.itemList.Clear();
        inventory.playerEquippedHelmet = null;
        inventory.playerEquippedArmor = null;
        inventory.playerEquippedBoot = null;
        inventory.equippedHelmet = null;
        inventory.equippedArmor = null;
        inventory.equippedBoot = null;
        // Update the itemList based on the items in the inventory slots
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                inventory.itemList.Add(itemInSlot.item);
            }
            else
            {
                // If the slot is empty, add null to the itemList
                inventory.itemList.Add(null);
            }
        }
        if (PlayerHelmetSlot.transform.childCount != 0)
        {
            Debug.Log("Player helmet");
            InventoryItem inventoryItem = PlayerHelmetSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipHelmet(inventoryItem.item, 0);
        }
        if (PlayerArmorSlot.transform.childCount != 0)
        {
            Debug.Log("Player Armor");
            InventoryItem inventoryItem = PlayerArmorSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipArmor(inventoryItem.item, 0);
        }
        if (PlayerBootSlot.transform.childCount != 0)
        {
            Debug.Log("Player Boot");
            InventoryItem inventoryItem = PlayerBootSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipBoot(inventoryItem.item, 0);
        }
        if (helmetSlot.transform.childCount != 0)
        {
            Debug.Log("Helmet");
            InventoryItem inventoryItem = helmetSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipHelmet(inventoryItem.item, 1);
        }
        if (armorSlot.transform.childCount != 0)
        {
            Debug.Log(" Armor");
            InventoryItem inventoryItem = armorSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipArmor(inventoryItem.item, 1);
        }
        if (bootSlot.transform.childCount != 0)
        {
            Debug.Log("boot");
            InventoryItem inventoryItem = bootSlot.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipBoot(inventoryItem.item, 1);
        }

      
    }
    void SpawnEquipedArmor(Item item, InventorySlotArmor slot)
    { if (slot.GetComponentInChildren<InventoryItem>() == null)
        {
            GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item);
        }
    }
    void SpawnEquipedHelmet(Item item, InventorySlotHelmet slot)
    { if (slot.GetComponentInChildren<InventoryItem>() == null)
        {
            GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item);
        }
    }
    void SpawnEquipedBoot(Item item, InventorySlotBoot slot)
    {
        if (slot.GetComponentInChildren<InventoryItem>() == null)
        {
            GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item);
        }
    }
    void SpawnNewItem(Item item,InventorySlot slot){

        if (slot.GetComponentInChildren<InventoryItem>() == null)
        {
            GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item);
        }   
    }

}
