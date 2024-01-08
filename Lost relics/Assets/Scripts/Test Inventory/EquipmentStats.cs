using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentStats : MonoBehaviour
{
   // public InventoryManager inventoryManager;

    public int Def;
    public int ATK;
    public int HP;
    public int SPD;
    public int Res;
    public int Crit;
    public int Evade;


    void Start()
    {

      /*  inventoryManager = FindObjectOfType<InventoryManager>();

        if (inventoryManager == null)
        {
            Debug.LogError("No InventoryManager found in the scene.");
        }*/
    }
    public void UpdateStat(int character)
    {
        /*if (inventoryManager == null || inventoryManager.inventory == null)
        {
            Debug.LogError("InventoryManager or its inventory is null");
            return;
        }

        Def = 0;
        HP = 0;
        SPD = 0;
        ATK = 0;
        Crit = 0;
        Evade = 0;
        Res = 0;

        if (inventoryManager.inventory.helmetList[character] != null)
        {
            HP += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("HP");
            SPD += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("SPD");
            Def += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("DEF");
            ATK += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("ATK");
            Crit += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("Crit");
            Evade += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("Evade");
            Res += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("Resistance");
        }

        if (inventoryManager.inventory.armorList[character] != null)
        {
            HP += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("HP");
            SPD += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("SPD");
            Def += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("DEF");
            ATK += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("ATK");
            Crit += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("Crit");
            Evade += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("Evade");
            Res += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("Resistance");
        }

        if (inventoryManager.inventory.bootList[character] != null)
        {
            HP += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("HP");
            SPD += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("SPD");
            Def += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("DEF");
            ATK += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("ATK");
            Crit += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("Crit");
            Evade += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("Evade");
            Res += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("Resistance");
        }*/
    }
}
