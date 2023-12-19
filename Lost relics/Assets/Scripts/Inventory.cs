using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
    public int money;
    public int numberOfSlot = 20;
    public int numberOfCharacter = 1 ;
    
    [Header("Inventory Item")]
    public List<Item> itemList = new List<Item>();
    public List<Item> keyItemList = new List<Item>();

    [Header("Equipment")]
    public List<Item> helmetList = new List<Item>();
    public List<Item> armorList = new List<Item>();
    public List<Item> bootList = new List<Item>();
    
    
    public void EquipHelmet(Item helmet, int character)
    {
        helmetList[character] = helmet;
    }

    public void EquipArmor(Item armor, int character)
    {
        armorList[character] = armor;     
    }
    public void EquipBoot(Item boot, int character)
    {
        bootList[character] = boot; 
    }

}