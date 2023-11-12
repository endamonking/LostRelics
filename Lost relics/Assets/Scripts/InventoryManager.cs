using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;

    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private InventorySlot[] inventorySlots;
    [SerializeField] private Bin binSlot;
    [SerializeField] private InventorySlotHelmet helmetSlot_1;
    [SerializeField] private InventorySlotArmor armorSlot_1;
    [SerializeField] private InventorySlotBoot bootSlot_1;
    [SerializeField] private InventorySlotHelmet  helmetSlot_2;
    [SerializeField] private InventorySlotArmor  armorSlot_2;
    [SerializeField] private InventorySlotBoot  bootSlot_2;
    [SerializeField] private InventorySlotHelmet helmetSlot_3;
    [SerializeField] private InventorySlotArmor armorSlot_3;
    [SerializeField] private InventorySlotBoot bootSlot_3;
    [SerializeField] private InventorySlotHelmet helmetSlot_4;
    [SerializeField] private InventorySlotArmor armorSlot_4;
    [SerializeField] private InventorySlotBoot bootSlot_4;



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
        if(inventory.equippedArmor_1 != null)
        {
            Item item = inventory.equippedArmor_1;
            if(item.itemType == ItemType.Armor)
                SpawnEquipedArmor(item, armorSlot_1);
        }
        if(inventory.equippedHelmet_1!= null)
        {
            Item item = inventory.equippedHelmet_1;
            if (item.itemType == ItemType.Helmet)
                SpawnEquipedHelmet(item, helmetSlot_1);
        }
        if(inventory.equippedBoot_1 != null)
        {
            Item item = inventory.equippedBoot_1;
            if (item.itemType == ItemType.Boot)
                SpawnEquipedBoot(item, bootSlot_1);
        }

        if(inventory.equippedHelmet_2 != null)
        {
            Item item = inventory.equippedHelmet_2;
            if (item.itemType == ItemType.Helmet)
                SpawnEquipedHelmet(item, helmetSlot_2);
        }
        if(inventory.equippedArmor_2 != null)
        {
            Item item = inventory.equippedArmor_2;
            if (item.itemType == ItemType.Armor)
                SpawnEquipedArmor(item, armorSlot_2);
        }
        if(inventory.equippedBoot_2 != null)
        {
            Item item = inventory.equippedBoot_2;
            if (item.itemType == ItemType.Boot)
                SpawnEquipedBoot(item, bootSlot_2);
        }
        if (inventory.equippedArmor_3 != null)
        {
            Item item = inventory.equippedArmor_3;
            if (item.itemType == ItemType.Armor)
                SpawnEquipedArmor(item, armorSlot_3);
        }
        if (inventory.equippedHelmet_3 != null)
        {
            Item item = inventory.equippedHelmet_3;
            if (item.itemType == ItemType.Helmet)
                SpawnEquipedHelmet(item, helmetSlot_3);
        }
        if (inventory.equippedBoot_3 != null)
        {
            Item item = inventory.equippedBoot_3;
            if (item.itemType == ItemType.Boot)
                SpawnEquipedBoot(item, bootSlot_3);
        }
        if (inventory.equippedArmor_4 != null)
        {
            Item item = inventory.equippedArmor_4;
            if (item.itemType == ItemType.Armor)
                SpawnEquipedArmor(item, armorSlot_4);
        }
        if (inventory.equippedHelmet_4 != null)
        {
            Item item = inventory.equippedHelmet_4;
            if (item.itemType == ItemType.Helmet)
                SpawnEquipedHelmet(item, helmetSlot_4);
        }
        if (inventory.equippedBoot_4 != null)
        {
            Item item = inventory.equippedBoot_1;
            if (item.itemType == ItemType.Boot)
                SpawnEquipedBoot(item, bootSlot_4);
        }

    }

    public void UpdateInventoryItems()
    {
       
        inventory.itemList.Clear();
        inventory.equippedHelmet_1= null;
        inventory.equippedArmor_1 = null;
        inventory.equippedBoot_1 = null;
        inventory.equippedHelmet_2 = null;
        inventory.equippedArmor_2 = null;
        inventory.equippedBoot_2 = null;
        inventory.equippedHelmet_3 = null;
        inventory.equippedArmor_3 = null;
        inventory.equippedBoot_3 = null;
        inventory.equippedHelmet_4 = null;
        inventory.equippedArmor_4 = null;
        inventory.equippedBoot_4 = null;
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                inventory.itemList.Add(itemInSlot.item);
            }
            else
            {
                
                inventory.itemList.Add(null);
            }
        }
        if (helmetSlot_1.transform.childCount != 0)
        {
            //Debug.Log("Player helmet");
            InventoryItem inventoryItem = helmetSlot_1.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipHelmet(inventoryItem.item, 0);
        }
        if (armorSlot_1.transform.childCount != 0)
        {
           // Debug.Log("Player Armor");
            InventoryItem inventoryItem = armorSlot_1.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipArmor(inventoryItem.item, 0);
        }
        if (bootSlot_1.transform.childCount != 0)
        {
            
            InventoryItem inventoryItem = bootSlot_1.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipBoot(inventoryItem.item, 0);
        }
        if (helmetSlot_2.transform.childCount != 0)
        {
             
            InventoryItem inventoryItem = helmetSlot_2.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipHelmet(inventoryItem.item, 1);
        }
        if (armorSlot_2.transform.childCount != 0)
        {
             
            InventoryItem inventoryItem = armorSlot_2.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipArmor(inventoryItem.item, 1);
        }
        if (bootSlot_2.transform.childCount != 0)
        {
       
            InventoryItem inventoryItem = bootSlot_2.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipBoot(inventoryItem.item, 1);
        }
        if (helmetSlot_3.transform.childCount != 0)
        {
           
            InventoryItem inventoryItem = helmetSlot_3.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipHelmet(inventoryItem.item, 1);
        }
        if (armorSlot_3.transform.childCount != 0)
        {
 
            InventoryItem inventoryItem = armorSlot_3.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipArmor(inventoryItem.item, 1);
        }
        if (bootSlot_3.transform.childCount != 0)
        {
           
            InventoryItem inventoryItem = bootSlot_3.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipBoot(inventoryItem.item, 1);
        }
        if (helmetSlot_4.transform.childCount != 0)
        {

            InventoryItem inventoryItem = helmetSlot_4.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipHelmet(inventoryItem.item, 1);
        }
        if (armorSlot_4.transform.childCount != 0)
        {

            InventoryItem inventoryItem = armorSlot_4.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipArmor(inventoryItem.item, 1);
        }
        if (bootSlot_4.transform.childCount != 0)
        {

            InventoryItem inventoryItem = bootSlot_4.transform.GetChild(0).GetComponent<InventoryItem>();
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
