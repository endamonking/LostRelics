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

        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.itemName = "MyItem";
        AssetDatabase.CreateAsset(newItem, $"Assets/Items/ItemInInventory/{newItem.itemName}.asset");

        newItem.itemName = item.itemName;
        newItem.itemType = item.itemType;
        newItem.icon = item.icon;
        newItem.description = item.description;
        newItem.ItemStateDataList = new List<ItemStateData>(item.ItemStateDataList);
        itemList.Add(newItem);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }

    public void EquipItem(Item item)
    {
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