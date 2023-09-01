using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList;
    
    public Item equippedArmor;
    public Item equippedHelmet;
    public Item equippedBoot;

 

    public void AddItem(Item item)
    {

        Item newItem = Instantiate(item);
        newItem.name = item.name;
        AssetDatabase.CreateAsset(newItem, $"Assets/Inventory/{newItem.itemName}.asset");
        itemList.Add(newItem);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }

    public void EquipItem(Item item)
    {
        if (itemList.Contains(item))
        {
            // Equip the item
            switch (item.itemType)
            {
                case ItemType.Armor:
                    equippedArmor = item;
                    break;
                case ItemType.Helmet:
                    equippedHelmet = item;
                    break;
                case ItemType.Boot:
                    equippedBoot = item;
                    break;
            }
        }
    }
}