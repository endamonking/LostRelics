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
            if (inventory.equippedBoot_3 != null)
            {
                HP += (int)inventory.equippedBoot_4.GetItemStateValue("HP");
                SPD += (int)inventory.equippedBoot_4.GetItemStateValue("SPD");
                Def += (int)inventory.equippedBoot_4.GetItemStateValue("DEF");
            }
            if (inventory.equippedHelmet_3 != null)
            {
                HP += (int)inventory.equippedHelmet_4.GetItemStateValue("HP");
                SPD += (int)inventory.equippedHelmet_4.GetItemStateValue("SPD");
                Def += (int)inventory.equippedHelmet_4.GetItemStateValue("DEF");
            }

        }
    }

  
   
}
