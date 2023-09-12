using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class PlayerStatsUI : MonoBehaviour
{
    public Character character;
    public Inventory inventory;
    public object player;
    public TextMeshProUGUI hpText; 
    public TextMeshProUGUI atkText;
    //public TextMeshProUGUI healingText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI spdText;
    // Use the correct type for TextMesh Pro objects 
    //public TextMeshProUGUI resistanceText;
    //public TextMeshProUGUI evadeText;
    //public TextMeshProUGUI critText;
    //public TextMeshProUGUI critDmgText;


    // Start is called before the first frame update
    void Start()
    {
          

    }

    // Update is called once per frame
    void Update()
    {
         

        Item equippedArmor = inventory.playerEquippedArmor;
        Item equippedHelmet = inventory.playerEquippedHelmet;
        Item equippedBoot = inventory.playerEquippedBoot;

        // int HP = character.maxHP;
        // int SPD= character.baseSPD;
        //int DEF = character.currentDefpoint;
        int HP=0;
        int SPD=0;
        int DEF=0;
        if (equippedArmor != null)
        {
            HP += (int)equippedArmor.GetItemStateValue("HP");
            DEF += (int)equippedArmor.GetItemStateValue("DEF");
            SPD += (int)equippedArmor.GetItemStateValue("SPD");
             
        }

        if (equippedHelmet != null)
        {

            HP += (int)equippedHelmet.GetItemStateValue("HP");

            DEF += (int)equippedHelmet.GetItemStateValue("DEF");
            SPD += (int)equippedHelmet.GetItemStateValue("SPD");
        }

        if (equippedBoot != null)
        {
            HP += (int)equippedBoot.GetItemStateValue("HP");
            DEF += (int)equippedBoot.GetItemStateValue("DEF");
            SPD += (int)equippedBoot.GetItemStateValue("SPD");

        }

        // Update the UI text
        hpText.text = $"HP: {HP}";
        defText.text = $"DEF: {DEF}";
        spdText.text = $"SPD: {SPD}";
       
    }
}
