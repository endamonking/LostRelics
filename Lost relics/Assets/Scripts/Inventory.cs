using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>(20);

    [Header("Player Equipment")]
    public Item PlayerEquippedArmor;
    public Item PlayerEquippedHelmet;
    public Item PlayerEquippedBoot;

    [Header("Character Equipment")]
    public Item equippedArmor;
    public Item equippedHelmet;
    public Item equippedBoot;


    public void MoveItem(Item item, int newSlot)
    {
        if (itemList.Contains(item))
        {

            item.currentSlot = newSlot;
        }
    }
    public void EquipHelmet(Item helmet, int character)
    {
        if (itemList.Contains(helmet))
        {
            // Equip the helmet for the specified character
            if (character == 0)
            {
                PlayerEquippedHelmet = helmet;
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
                    PlayerEquippedArmor = armor;
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
                PlayerEquippedBoot = boot;
            }
            else if (character == 1)
            {
               equippedBoot = boot;
            }
        }
    }

}