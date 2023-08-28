using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class PlayerStatsUI : MonoBehaviour
{
    public Stats stats;
    public Inventory inventory;

    public TextMeshProUGUI hpText; // Use the correct type for TextMesh Pro objects 
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI healingText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI spdText;
    public TextMeshProUGUI resistanceText;
    public TextMeshProUGUI evadeText;
    public TextMeshProUGUI critText;
    public TextMeshProUGUI critDmgText;


    // Start is called before the first frame update
     void Start()
    {
          

    }

    // Update is called once per frame
    void Update()
    {

        
        Item equippedArmor = inventory.equippedArmor;
        Item equippedHelmet = inventory.equippedHelmet;
        Item equippedBoot = inventory.equippedBoot;

         
        float hp = stats.GetStateValue("HP");
        float atk = stats.GetStateValue("ATK");
        float healing = stats.GetStateValue("Healing");
        float def = stats.GetStateValue("DEF");
        float spd = stats.GetStateValue("SPD");
        float res = stats.GetStateValue("Resistance");
        float evade = stats.GetStateValue("Evade");
        float crit = stats.GetStateValue("Crit");
        float critDmg = stats.GetStateValue("Crit DMG");

        if (equippedArmor != null)
        {
            hp += equippedArmor.GetItemStateValue("HP");
            atk += equippedArmor.GetItemStateValue("ATK");
            healing += equippedArmor.GetItemStateValue("Healing");
            def += equippedArmor.GetItemStateValue("DEF");
            spd += equippedArmor.GetItemStateValue("SPD");
            res += equippedArmor.GetItemStateValue("Resistance");
            evade += equippedArmor.GetItemStateValue("Evade");
            crit += equippedArmor.GetItemStateValue("Crit");
            critDmg += equippedArmor.GetItemStateValue("Crit DMG");
        }

        if (equippedHelmet != null)
        {
            hp += equippedHelmet.GetItemStateValue("HP");
            atk += equippedHelmet.GetItemStateValue("ATK");
            healing += equippedHelmet.GetItemStateValue("Healing");
            def += equippedHelmet.GetItemStateValue("DEF");
            spd += equippedHelmet.GetItemStateValue("SPD");
            res += equippedHelmet.GetItemStateValue("Resistance");
            evade += equippedHelmet.GetItemStateValue("Evade");
            crit += equippedHelmet.GetItemStateValue("Crit");
            critDmg += equippedHelmet.GetItemStateValue("Crit DMG");
        }

        if (equippedBoot != null)
        {
            hp += equippedBoot.GetItemStateValue("HP");
            atk += equippedBoot.GetItemStateValue("ATK");
            healing += equippedBoot.GetItemStateValue("Healing");
            def += equippedBoot.GetItemStateValue("DEF");
            spd += equippedBoot.GetItemStateValue("SPD");
            res += equippedBoot.GetItemStateValue("Resistance");
            evade += equippedBoot.GetItemStateValue("Evade");
            crit += equippedBoot.GetItemStateValue("Crit");
            critDmg += equippedBoot.GetItemStateValue("Crit DMG");
        }

        // Update the UI text
        hpText.text = $"HP: {hp}";
        atkText.text = $"ATK: {atk}";
        healingText.text = $"Healing: {healing}";
        defText.text = $"DEF: {def}";
        spdText.text = $"SPD: {spd}";
        resistanceText.text = $"Res: {res}";
        evadeText.text = $"Evade: {evade}";
        critText.text = $"Crit: {crit}";
        critDmgText.text = $"Crit DMG: {critDmg}";
    }
}
