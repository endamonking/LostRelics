using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownPlayerSystem : MonoBehaviour
{

    public Transform PlayerSlot;
    private void Awake()
    {
        int selectedCharacterID = GameManager.Instance.selectedCharacterID;
        Debug.Log(selectedCharacterID);
        GameObject characterPrefab = Resources.Load<GameObject>("Prefabs/Town/Character" + selectedCharacterID);
        Debug.Log(characterPrefab);
        Transform childTranform = this.transform.Find("Character");
        if (childTranform == null) //Will do only once
        {
            GameObject MainCharacter = Instantiate(characterPrefab, PlayerSlot);
            MainCharacter.name = "Character";
            Unit unitComponent = MainCharacter.GetComponent<Unit>();
            assignStatToCharacterScript(unitComponent);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void assignStatToCharacterScript(Unit unit)
    {
        Character character = GetComponentInParent<Character>();
        character.characterName = unit.UnitName;
        character.baseATK = unit.ATK + PlayerPrefs.GetInt("PPATK", 0);
        character.baseHeal = unit.Healing + PlayerPrefs.GetInt("PPHEAL", 0);
        character.basedefPoint = unit.DEF + PlayerPrefs.GetInt("PPDEF", 0);
        character.baseSPD = unit.SPD + PlayerPrefs.GetInt("PPSPD", 0);
        character.baseCritRate = unit.CritChance + PlayerPrefs.GetInt("PPCRATE", 0);
        character.baseCritDMG = unit.CritDamage + PlayerPrefs.GetInt("PPCDMG", 0);
        character.baseEvade = unit.Evade + PlayerPrefs.GetInt("PPEVADE", 0);
        character.maxHP = unit.MaxHP + PlayerPrefs.GetInt("PPMAXHP", 0);
        character.currentHP = character.maxHP;
        character.baseResistance = unit.Resistance + PlayerPrefs.GetInt("PPRES", 0);
        character.maxMana = unit.maxMana + PlayerPrefs.GetInt("PPMANA", 0);
        character.characterPassiveSkillPrefab = unit.passivSkill;
        character.isMelee = unit.isMelee;
    }


}
