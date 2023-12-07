using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{   
   
    public int numberOfSlot = 20;
    public int numberOfCharacter = 1 ;
    public List<Item> itemList = new List<Item>();

    [Header("Equipment")]
    public List<Item> helmetList = new List<Item>();
    public List<Item> armorList = new List<Item>();
    public List<Item> bootList = new List<Item>();
    
    
 
     
    [HideInInspector] public Item equippedArmor_1;
    [HideInInspector] public Item equippedHelmet_1;
    [HideInInspector] public Item equippedBoot_1;
 
    [HideInInspector] public Item equippedArmor_2;
    [HideInInspector] public Item equippedHelmet_2;
    [HideInInspector] public Item equippedBoot_2;
 
    [HideInInspector] public Item equippedArmor_3;
    [HideInInspector] public Item equippedHelmet_3;
    [HideInInspector] public Item equippedBoot_3;

 
    [HideInInspector] public Item equippedArmor_4;
    [HideInInspector] public Item equippedHelmet_4;
    [HideInInspector] public Item equippedBoot_4;

     
    public void EquipHelmet(Item helmet, int character)
    {
        helmetList[character] = helmet;

        /*    if (character == 0)
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


        */
    }

    public void EquipArmor(Item armor, int character)
    {
        armorList[character] = armor;
        // Equip the helmet for the specified character
          /*      if(character == 0)
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
                }*/
    }
    public void EquipBoot(Item boot, int character)
    {
        bootList[character] = boot;
            // Equip the helmet for the specified character
           /* if (character == 0)
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
           */

    }

}