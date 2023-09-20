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

     

    public void EquipHelmet(Item helmet, int character)
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
    public void EquipArmor(Item armor, int character)
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
    public void EquipBoot(Item boot, int character)
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