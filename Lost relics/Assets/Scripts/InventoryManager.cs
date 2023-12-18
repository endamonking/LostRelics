using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject inventoryShopUI;
    [SerializeField] private GameObject PlayerEquipmentUI;
    [SerializeField] private GameObject inventoryItemPrefab;

    [SerializeField] private List<InventorySlot> inventorySlots = new List<InventorySlot>();
    [SerializeField] private List<InventorySlotHelmet> helmetSlot = new List<InventorySlotHelmet>();
    [SerializeField] private List<InventorySlotArmor> armorSlot = new List<InventorySlotArmor>();
    [SerializeField] private List<InventorySlotBoot> bootSlot = new List<InventorySlotBoot>();
    [SerializeField] private Bin binSlot;
    private int memberOfRow = 3;


    
    public InventorySlotHelmet helmetSlot_1;
    public InventorySlotArmor armorSlot_1;
    public InventorySlotBoot bootSlot_1;
    /*  
        public InventorySlotHelmet  helmetSlot_2;
        public InventorySlotArmor  armorSlot_2;
        public InventorySlotBoot  bootSlot_2;

       public InventorySlotHelmet helmetSlot_3;
       public InventorySlotArmor armorSlot_3;
       public InventorySlotBoot bootSlot_3;

       public InventorySlotHelmet helmetSlot_4;
       public InventorySlotArmor armorSlot_4;
       public InventorySlotBoot bootSlot_4;

        */

    private static InventoryManager instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set the instance to this object
            instance = this;

            // Make the game object persistent across scene changes
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }

    public void AddItem(Item item)
    {
        int succes = 0;

        //for(int i=0; i<inventorySlots.Length && succes ==0;i++)\
        //*
        for (int i = 0; i < inventorySlots.Count && succes == 0; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                succes++;
                SpawnNewItem(item, slot);

            }
        }

        LoadItemInventory();


    }

        void Start()
        {

            Transform parentTransform = inventoryUI.transform;
            int j = 1;
            for (int i = 1; i <= inventory.numberOfSlot; i++)
            {

                string slotName = "Row_" + j + "/InventorySlot_(" + i + ")";
                Transform slotTransform = parentTransform.Find(slotName);
                if (slotTransform != null)
                {
                    InventorySlot slot = slotTransform.GetComponent<InventorySlot>();
                    if (slot != null)
                    {
                        inventorySlots.Add(slot);

                    }
                    else
                    {
                        Debug.LogError("No InventorySlot component found on " + slotName);
                    }
                }
                else
                {
                    Debug.LogError("No GameObject found with name " + slotName);
                }
                if (i % memberOfRow == 0)
                {
                    j++;
                }

            }
            parentTransform = PlayerEquipmentUI.transform;
            for (int i = 1; i <= inventory.numberOfCharacter; i++)
            {
                //helmetSlot.Add(new InventorySlotHelmet());
                //armorSlot.Add(new InventorySlotArmor());
                //bootSlot.Add(new InventorySlotBoot());

                string helmetSlotName = "EquipmentSlot/Char" + i + "/HelmetSlot";
                string armorSlotName = "EquipmentSlot/Char" + i + "/ArmorSlot";
                string bootSlotName = "EquipmentSlot/Char" + i + "/BootSlot";

                Transform helmetSlotTransform = parentTransform.Find(helmetSlotName);
                Transform armorSlotTransform = parentTransform.Find(armorSlotName);
                Transform bootSlotTransform = parentTransform.Find(bootSlotName);

                if (helmetSlotTransform != null && armorSlotTransform != null && bootSlotTransform != null)
                {
                    InventorySlotHelmet helmet = helmetSlotTransform.GetComponent<InventorySlotHelmet>();
                    InventorySlotArmor armor = armorSlotTransform.GetComponent<InventorySlotArmor>();
                    InventorySlotBoot boot = bootSlotTransform.GetComponent<InventorySlotBoot>();

                    if (helmetSlot != null  )
                    {
                        helmetSlot.Add(helmet);
                      
                    }
                    if(armorSlot != null)
                    {
                        armorSlot.Add(armor);
                     }
                    if(bootSlot != null) 
                    {
                        bootSlot.Add(boot);
                    }
                    else
                    {
                        Debug.LogError("No InventorySlot component found on ");
                    }
                }
                else
                {
                    Debug.LogError("No GameObject found with name ");
                }


            }



            //Debug.Log("helmet list" + inventory.helmetList.Count);
            //Debug.Log("inventory.numberOfCharacter " + inventory.numberOfCharacter);

            LoadItemInventory();
        }
    public void SetInvetoryBacktoInventory()
    {
         
        inventorySlots.Clear();
        Transform parentTransform = inventoryUI.transform;
        int j = 1;
        for (int i = 1; i <= inventory.numberOfSlot; i++)
        {

            string slotName = "Row_" + j + "/InventorySlot_(" + i + ")";
            Transform slotTransform = parentTransform.Find(slotName);
            if (slotTransform != null)
            {
                InventorySlot slot = slotTransform.GetComponent<InventorySlot>();
                if (slot != null)
                {
                    inventorySlots.Add(slot);

                }
                else
                {
                    Debug.LogError("No InventorySlot component found on " + slotName);
                }
            }
            else
            {
                Debug.LogError("No GameObject found with name " + slotName);
            }
            if (i % memberOfRow == 0)
            {
                j++;
            }

        }
        LoadItemInventory();

    }
    public void SetInvetoryBacktoShop()
    {
        
        inventorySlots.Clear();
        Transform parentTransform = inventoryShopUI.transform;
        
        int j = 1;
        for (int i = 1; i <= inventory.numberOfSlot; i++)
        {
            //Debug.Log("i " + i);
            string slotName = "Row_" + j + "/InventorySlots_(" + i + ")";
            //Debug.Log("slotName = " + slotName);
            Transform slotTransform = parentTransform.Find(slotName);
            if (slotTransform != null)
            {
                InventorySlot slot = slotTransform.GetComponent<InventorySlot>();
                if (slot != null)
                {
                    //Debug.Log("Found slotName = " + slot);
                    inventorySlots.Add(slot);

                }
                else
                {
                    Debug.LogError("No InventorySlot component found on " + slotName);
                }
            }
            else
            {
                Debug.LogError("No GameObject found with name " + slotName);
            }
            if (i % memberOfRow == 0)
            {
                j++;
            }

        }

        LoadItemInventory();
    }

     
    public void LoadItemInventory()
    {
        
        for (int i = 0; i < inventory.numberOfSlot; i++)
          {
            if (inventory.itemList[i] != null)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                itemInSlot = null;
                Item item = inventory.itemList[i];
                SpawnNewItem(item, slot);
            }
            else if(inventory.itemList[i] == null){

                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
              
                if (itemInSlot != null)
                {
                    Debug.Log($"{i}");
                    Destroy(itemInSlot.gameObject);
                }

            }
          }
          for(int i = 0; i < inventory.numberOfCharacter; i++)
           {
           
            if (inventory.helmetList[i] != null)
              {
                  Item item = inventory.helmetList[i];
                  if (item.itemType == ItemType.Helmet)
                      SpawnHelmet(item, helmetSlot[i]);

              }
              if (inventory.armorList[i] != null)
              {
                  Item item = inventory.armorList[i];
                  if (item.itemType == ItemType.Armor)
                      SpawnArmor(item, armorSlot[i]);
              }
              if (inventory.bootList[i] != null)
              {
                  Item item = inventory.bootList[i];
                  if (item.itemType == ItemType.Boot)
                      SpawnBoot(item, bootSlot[i]);
              }
          }
       /* if (inventory.equippedArmor_1 != null)
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
       */
    }

    public void UpdateInventoryItems()
    {
       
        inventory.itemList.Clear();
       
        /*
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
        inventory.equippedBoot_4 = null;*/

        
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
        for (int i = 0; i < inventory.numberOfCharacter; i++)
        {
            inventory.helmetList[i] = null;
            inventory.armorList[i] = null;
            inventory.bootList[i] = null;
            if (helmetSlot[i].transform.childCount != 0)
            {
                InventoryItem inventoryItem = helmetSlot[i].transform.GetChild(0).GetComponent<InventoryItem>();
                inventory.EquipHelmet(inventoryItem.item, i);
            }
            if (armorSlot[i].transform.childCount != 0)
            {
                InventoryItem inventoryItem = armorSlot[i].transform.GetChild(0).GetComponent<InventoryItem>();
                inventory.EquipArmor(inventoryItem.item, i);
            }
            if (bootSlot[i].transform.childCount != 0)
            {

                InventoryItem inventoryItem = bootSlot[i].transform.GetChild(0).GetComponent<InventoryItem>();
                inventory.EquipBoot(inventoryItem.item, i);
            }
        }
        /*
        if (helmetSlot_1.transform.childCount != 0)
        {
            InventoryItem inventoryItem = helmetSlot_1.transform.GetChild(0).GetComponent<InventoryItem>();
            inventory.EquipHelmet(inventoryItem.item, 0);
        }
        if (armorSlot_1.transform.childCount != 0)
        {
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

        */

    }
    /*
    void SpawnEquipment<T>(Item item, T slot) where T : Component
    {
        if (slot.GetComponentInChildren<InventoryItem>() == null)
        {
            GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item);
        }
    }*/
    void SpawnHelmet(Item item, InventorySlotHelmet slot)
    {
        if (slot.GetComponentInChildren<InventoryItem>() == null)
        {
            GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item);
        }
    }
    void SpawnArmor(Item item, InventorySlotArmor slot)
    {
        if (slot.GetComponentInChildren<InventoryItem>() == null)
        {
            GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item);
        }
    }
    void SpawnBoot(Item item, InventorySlotBoot slot)
    {
        if (slot.GetComponentInChildren<InventoryItem>() == null)
        {
            GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item);
        }
    }
    /*void SpawnEquipedArmor(Item item, InventorySlotArmor slot)
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
    }  */
    void SpawnNewItem(Item item,InventorySlot slot){

        if (slot.GetComponentInChildren<InventoryItem>() == null)
        {
            GameObject spawnItemInSlot = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItem = spawnItemInSlot.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item);
        }   
    }
  

}
