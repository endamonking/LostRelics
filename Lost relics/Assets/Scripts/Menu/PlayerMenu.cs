using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMenu : MonoBehaviour
{

    public Stats stats;
    public Text hpText;
    public Text atkText;
    public Text healingText;
    public Text defText;
    public Text spdText;
    public Text resistanceText;
    public Text evadeText;
    public Text critText;
    public Text critDmgText;

    private void Update()
    {
        // Update UI elements with player state data
        hpText.text = $"HP: {stats.GetStateValue("HP")}";
        atkText.text = $"ATK: {stats.GetStateValue("ATK")}";
        healingText.text = $"Healing: {stats.GetStateValue("Healing")}";
        defText.text = $"DEF: {stats.GetStateValue("DEF")}";
        spdText.text = $"SPD: {stats.GetStateValue("SPD")}";
        resistanceText.text = $"Res: {stats.GetStateValue("Resistance")}";
        evadeText.text = $"Evade: {stats.GetStateValue("Evade")}";
        critText.text = $"Crit: {stats.GetStateValue("Crit")}";
        critDmgText.text = $"Crit DMG: {stats.GetStateValue("Crit DMG")}";
    }
}
