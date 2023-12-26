using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRunData", menuName = "ScriptableObjects/PlayerRunData", order = 1)]
public class CharacterStatsScriptableObject : ScriptableObject
{
    public int UnitID;
    public string UnitName;
    public int ATK;
    public int Healing;
    public int DEF;
    public int SPD;
    public int CritChance;
    public int Evade;
    public int CritDamage;
    public int Resistance;
    public int MaxHP;
    public int CurrentHP;
 
}
