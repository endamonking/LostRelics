using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>(20);

    [Header("1_Equipment")]
    public Item equippedArmor_1;
    public Item equippedHelmet_1;
    public Item equippedBoot_1;

    [Header("2_Equipment")]
    public Item equippedArmor_2;
    public Item equippedHelmet_2;
    public Item equippedBoot_2;

    [Header("3_Equipment")]
    public Item equippedArmor_3;
    public Item equippedHelmet_3;
    public Item equippedBoot_3;

    [Header("4_Equipment")]
    public Item equippedArmor_4;
    public Item equippedHelmet_4;
    public Item equippedBoot_4;


    public void EquipHelmet(Item helmet, int character)
    {
       
             
            if (character == 0)
            {
                equippedHelmet_1 = helmet;
            }
            else if (character == 1)
            {
                equippedHelmet_2 = helmet;
            }
            else if (character == 2)
            {
                equippedHelmet_3 = helmet;
            }
            else if (character == 3)
            {
                equippedHelmet_4 = helmet;
            }



    }
    public void EquipArmor(Item armor, int character)
    {
            
                // Equip the helmet for the specified character
                if (character == 0)
                {
                    equippedArmor_1 = armor;
                }
                else if (character == 1)
                {
                    equippedArmor_2 = armor;
                }
                else if (character == 2)
                {
                    equippedArmor_3 = armor;
                }
                else if (character == 3)
                {
                    equippedArmor_4 = armor;
                }
    }
    public void EquipBoot(Item boot, int character)
    {
        
            // Equip the helmet for the specified character
            if (character == 0)
            {
                equippedBoot_1 = boot;
            }
            else if (character == 1)
            {
               equippedBoot_2 = boot;
            }
            else if (character == 2)
            {
                equippedBoot_3 = boot;
            }
            else if (character == 3)
            {
                equippedBoot_4 = boot;
            }


    }

}