using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentStats : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public int Def;
    public int ATK;
    public int HP;
    public int SPD;

    /*public void UpdateStat(int character)
    {

        Def = 0;
        HP = 0;
        SPD = 0;
        ATK = 0;

        HP += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("HP");
        HP += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("HP");
        HP += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("HP");

        SPD += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("SPD");
        SPD += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("SPD");
        SPD += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("SPD");

        Def += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("DEF");
        Def += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("DEF");
        Def += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("DEF");

        ATK += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("ATK");
        ATK += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("ATK");
        ATK += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("ATK");
        /*
        if (character == 0)
        {
            if (inventory.equippedArmor_1 != null)
            {
                HP += (int)inventory.equippedArmor_1.GetItemStateValue("HP");
                SPD += (int)inventory.equippedArmor_1.GetItemStateValue("SPD");
                Def += (int)inventory.equippedArmor_1.GetItemStateValue("DEF");
            }
            if (inventory.equippedBoot_1 != null)
            {
                HP += (int)inventory.equippedBoot_1.GetItemStateValue("HP");
                SPD += (int)inventory.equippedBoot_1.GetItemStateValue("SPD");
                Def += (int)inventory.equippedBoot_1.GetItemStateValue("DEF");
            }
            if (inventory.equippedHelmet_1 != null)
            {
                HP += (int)inventory.equippedHelmet_1.GetItemStateValue("HP");
                SPD += (int)inventory.equippedHelmet_1.GetItemStateValue("SPD");
                Def += (int)inventory.equippedHelmet_1.GetItemStateValue("DEF");
            }



        }
        else if (character == 1)
        {
            if (inventory.equippedArmor_2 != null)
            {
                HP += (int)inventory.equippedArmor_2.GetItemStateValue("HP");
                SPD += (int)inventory.equippedArmor_2.GetItemStateValue("SPD");
                Def += (int)inventory.equippedArmor_2.GetItemStateValue("DEF");
            }
            if (inventory.equippedBoot_2 != null)
            {
                HP += (int)inventory.equippedBoot_2.GetItemStateValue("HP");
                SPD += (int)inventory.equippedBoot_2.GetItemStateValue("SPD");
                Def += (int)inventory.equippedBoot_2.GetItemStateValue("DEF");
            }
            if (inventory.equippedHelmet_2 != null)
            {
                HP += (int)inventory.equippedHelmet_2.GetItemStateValue("HP");
                SPD += (int)inventory.equippedHelmet_2.GetItemStateValue("SPD");
                Def += (int)inventory.equippedHelmet_2.GetItemStateValue("DEF");
            }

        }
        else if (character == 2)
        {
            if (inventory.equippedArmor_3 != null)
            {
                HP += (int)inventory.equippedArmor_3.GetItemStateValue("HP");
                SPD += (int)inventory.equippedArmor_3.GetItemStateValue("SPD");
                Def += (int)inventory.equippedArmor_3.GetItemStateValue("DEF");
            }
            if (inventory.equippedBoot_3 != null)
            {
                HP += (int)inventory.equippedBoot_3.GetItemStateValue("HP");
                SPD += (int)inventory.equippedBoot_3.GetItemStateValue("SPD");
                Def += (int)inventory.equippedBoot_3.GetItemStateValue("DEF");
            }
            if (inventory.equippedHelmet_3 != null)
            {
                HP += (int)inventory.equippedHelmet_3.GetItemStateValue("HP");
                SPD += (int)inventory.equippedHelmet_3.GetItemStateValue("SPD");
                Def += (int)inventory.equippedHelmet_3.GetItemStateValue("DEF");
            }

        }
        else if (character == 3)
        {
            if (inventory.equippedArmor_4 != null)
            {
                HP += (int)inventory.equippedArmor_4.GetItemStateValue("HP");
                SPD += (int)inventory.equippedArmor_4.GetItemStateValue("SPD");
                Def += (int)inventory.equippedArmor_4.GetItemStateValue("DEF");
            }
            if (inventory.equippedBoot_4 != null)
            {
                HP += (int)inventory.equippedBoot_4.GetItemStateValue("HP");
                SPD += (int)inventory.equippedBoot_4.GetItemStateValue("SPD");
                Def += (int)inventory.equippedBoot_4.GetItemStateValue("DEF");
            }
            if (inventory.equippedHelmet_4 != null)
            {
                HP += (int)inventory.equippedHelmet_4.GetItemStateValue("HP");
                SPD += (int)inventory.equippedHelmet_4.GetItemStateValue("SPD");
                Def += (int)inventory.equippedHelmet_4.GetItemStateValue("DEF");
            }

        } 
    }*/
    public void UpdateStat(int character)
    {
        if (inventoryManager == null || inventoryManager.inventory == null)
        {
            Debug.LogError("InventoryManager or its inventory is null");
            return;
        }

        Def = 0;
        HP = 0;
        SPD = 0;
        ATK = 0;

        if (inventoryManager.inventory.helmetList[character] != null)
        {
            HP += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("HP");
            SPD += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("SPD");
            Def += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("DEF");
            ATK += (int)inventoryManager.inventory.helmetList[character].GetItemStateValue("ATK");
        }

        if (inventoryManager.inventory.armorList[character] != null)
        {
            HP += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("HP");
            SPD += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("SPD");
            Def += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("DEF");
            ATK += (int)inventoryManager.inventory.armorList[character].GetItemStateValue("ATK");
        }

        if (inventoryManager.inventory.bootList[character] != null)
        {
            HP += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("HP");
            SPD += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("SPD");
            Def += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("DEF");
            ATK += (int)inventoryManager.inventory.bootList[character].GetItemStateValue("ATK");
        }
    }
}
