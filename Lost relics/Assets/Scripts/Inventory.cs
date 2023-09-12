using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>(20);

    [Header("Player Equipment")]
    public Item playerEquippedArmor;
    public Item playerEquippedHelmet;
    public Item playerEquippedBoot;

    [Header("Character Equipment")]
    public Item equippedArmor;
    public Item equippedHelmet;
    public Item equippedBoot;

  
    public void MoveItem(Item item, int newSlot)
    {
        Debug.Log("Moving item to slot: " + newSlot);

         
            int oldSlot = itemList.IndexOf(item);
            if (newSlot >= 0 && newSlot < itemList.Count)
            {
                // If the new slot already contains an item, swap them
                if (itemList[newSlot] != null)
                {
                    Item tempItem = itemList[newSlot];
                    tempItem.currentSlot = oldSlot;
                    itemList[oldSlot] = tempItem;
                }

                // Move the item to the new slot
                itemList[newSlot] = item;
                item.currentSlot = newSlot;
            }
            else
            {
                Debug.LogError("New slot index is out of range");
            }
         

    }
 
    public void RemoveItem(Item item)
    {
        int index = itemList.IndexOf(item);
        if (index != -1)
        {
            itemList[index] = null;   
        }
    }
    public void EquipHelmet(Item helmet, int character)
    {
        if (itemList.Contains(helmet))
        {
            // Equip the helmet for the specified character
            if (character == 0)
            {
                playerEquippedHelmet = helmet;
            }
            else if (character == 1)
            {
                equippedHelmet = helmet;
            }
            

        }
    }
    public void EquipArmor(Item armor, int character)
    {
            if (itemList.Contains(armor))
            {
                // Equip the helmet for the specified character
                if (character == 0)
                {
                    playerEquippedArmor = armor;
                }
                else if (character == 1)
                {
                    equippedArmor = armor;
                }
            }
    }
    public void EquipBoot(Item boot, int character)
    {
        if (itemList.Contains(boot))
        {
            // Equip the helmet for the specified character
            if (character == 0)
            {
                playerEquippedBoot = boot;
            }
            else if (character == 1)
            {
               equippedBoot = boot;
            }
        }
    }

}