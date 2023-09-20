using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
 
public class PlayerStatsUI : MonoBehaviour
{
    public int character;
    public Inventory inventory;
    public object player;
    public TextMeshProUGUI hpText; 
    public TextMeshProUGUI atkText;
    //public TextMeshProUGUI healingText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI spdText;
    public GameObject PlayerSlot;
    //public TextMeshProUGUI resistanceText;
    //public TextMeshProUGUI evadeText;
    //public TextMeshProUGUI critText;
    //public TextMeshProUGUI critDmgText;

  

// Update is called once per frame
    void Update()
        {
             Item equippedArmor = null;
             Item equippedHelmet=null;
             Item equippedBoot=null;
        if (PlayerSlot.activeSelf)
            {
                character = 0;
            }
            else if (!PlayerSlot.activeSelf)
            {
                character = 1;
            }

            if (character == 0)
            {
                equippedArmor = inventory.playerEquippedArmor;
                equippedHelmet = inventory.playerEquippedHelmet;
                equippedBoot = inventory.playerEquippedBoot;
            }
            if(character ==1) 
            {
                equippedArmor = inventory.equippedArmor;
                equippedHelmet = inventory.equippedHelmet;
                equippedBoot = inventory.equippedBoot;
            }
            ;
            int HP=0;
            int SPD=0;
            int DEF=0;
            int ATK = 0;    
        
                if (equippedArmor != null)
                {
                    HP += (int)equippedArmor.GetItemStateValue("HP");
                    ATK += (int)equippedArmor.GetItemStateValue("ATK");
                    DEF += (int)equippedArmor.GetItemStateValue("DEF");
                    SPD += (int)equippedArmor.GetItemStateValue("SPD");
             
                }

                if (equippedHelmet != null)
                {
                    ATK += (int)equippedHelmet.GetItemStateValue("ATK");

                    HP += (int)equippedHelmet.GetItemStateValue("HP");

                    DEF += (int)equippedHelmet.GetItemStateValue("DEF");
                    SPD += (int)equippedHelmet.GetItemStateValue("SPD");
                }

                if (equippedBoot != null)
                {
                    ATK += (int)equippedBoot.GetItemStateValue("ATK");
                    HP += (int)equippedBoot.GetItemStateValue("HP");
                    DEF += (int)equippedBoot.GetItemStateValue("DEF");
                    SPD += (int)equippedBoot.GetItemStateValue("SPD");

                }
                else
                {
                    ATK += 0;
                    HP += 0;
                    DEF += 0;
                    SPD += 0;
                }

                // Update the UI text
                atkText.text = $"ATK: {ATK}";
                hpText.text = $"HP: {HP}";
                defText.text = $"DEF: {DEF}";
                spdText.text = $"SPD: {SPD}";
       
        }
}
