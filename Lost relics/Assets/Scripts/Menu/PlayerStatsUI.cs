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
    public GameObject slot_1;

    public GameObject slot_2;
    public GameObject slot_3;
    public GameObject slot_4;

    public TextMeshProUGUI hpText; 
    public TextMeshProUGUI atkText;
    //public TextMeshProUGUI healingText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI spdText;

    //public TextMeshProUGUI resistanceText;
    //public TextMeshProUGUI evadeText;
    //public TextMeshProUGUI critText;
    //public TextMeshProUGUI critDmgText;



    // Update is called once per frame
    void Update()
        {
           
        if (slot_1.activeSelf)
            {
                character = 0;
            }
        else if (slot_2.activeSelf)
            {
                character = 1;
            }
        else if (slot_3.activeSelf)
            {
                character = 2;
            }
        else if (slot_4.activeSelf)
            {
                character = 3;
            }
 
          Item  equippedHelmet = inventory.helmetList[character];
          Item equippedArmor = inventory.armorList[character];
          Item equippedBoot = inventory.bootList[character];
                
          
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
