using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentStats : MonoBehaviour
{
    public Inventory inventory;
    public int character;
    
    
    public int  Def;
    public int  HP;
    public int  SPD;
    public void UpdateStat()
    {
  
         Def = 0;
         HP = 0;
         SPD = 0;
        if (character == 0)
        {
            if (inventory.playerEquippedArmor != null)
            {
                HP += (int)inventory.playerEquippedArmor.GetItemStateValue("HP");
                SPD += (int)inventory.playerEquippedArmor.GetItemStateValue("SPD");
                Def += (int)inventory.playerEquippedArmor.GetItemStateValue("DEF");
            }
            if (inventory.playerEquippedHelmet != null)
            {
                HP += (int)inventory.playerEquippedHelmet.GetItemStateValue("HP");
                SPD += (int)inventory.playerEquippedHelmet.GetItemStateValue("SPD");
                Def += (int)inventory.playerEquippedHelmet.GetItemStateValue("DEF");
            }
            if (inventory.playerEquippedBoot != null)
            {
                HP += (int)inventory.playerEquippedBoot.GetItemStateValue("HP");
                SPD += (int)inventory.playerEquippedBoot.GetItemStateValue("SPD");
                Def += (int)inventory.playerEquippedBoot.GetItemStateValue("DEF");
            }

            if (inventory.equippedArmor != null)
            {
                HP += (int)inventory.equippedArmor.GetItemStateValue("HP");
                SPD += (int)inventory.equippedArmor.GetItemStateValue("SPD");
                Def += (int)inventory.equippedArmor.GetItemStateValue("DEF");
            }

        }
        else if (character == 1)
        {
            if (inventory.equippedHelmet != null)
            {
                HP = (int)inventory.equippedHelmet.GetItemStateValue("HP");
                SPD += (int)inventory.equippedHelmet.GetItemStateValue("SPD");
                Def += (int)inventory.equippedHelmet.GetItemStateValue("DEF");

            }

            if (inventory.equippedArmor != null)
            {
                HP += (int)inventory.equippedBoot.GetItemStateValue("HP");
                SPD += (int)inventory.equippedBoot.GetItemStateValue("SPD");
                Def += (int)inventory.equippedBoot.GetItemStateValue("DEF");
            }
        }
    }

  
   
}
