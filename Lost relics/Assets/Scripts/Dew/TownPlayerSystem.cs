using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownPlayerSystem : MonoBehaviour
{

    public Transform PlayerSlot;
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacterID = GameManager.Instance.selectedCharacterID;
        Debug.Log(selectedCharacterID);
        GameObject characterPrefab = Resources.Load<GameObject>("Prefabs/Town/Character" + selectedCharacterID);
        Debug.Log(characterPrefab);
        GameObject MainCharacter = Instantiate(characterPrefab, PlayerSlot);
        MainCharacter.name = "Character";

        CharacterStatsScriptableObject characterStats = ScriptableObject.CreateInstance<CharacterStatsScriptableObject>();
        Unit unitComponent = MainCharacter.GetComponent<Unit>();
        Debug.Log("PlayerController: " + unitComponent);
        if (unitComponent != null)
        {

            characterStats.UnitID = unitComponent.UnitID;
            characterStats.UnitName = unitComponent.UnitName;
            characterStats.ATK = unitComponent.ATK;
            characterStats.Healing = unitComponent.Healing;
            characterStats.DEF = unitComponent.DEF;
            characterStats.SPD = unitComponent.SPD;
            characterStats.CritChance = unitComponent.CritChance;
            characterStats.Evade = unitComponent.Evade;
            characterStats.CritDamage = unitComponent.CritDamage;
            characterStats.Resistance = unitComponent.Resistance;
            characterStats.MaxHP = unitComponent.MaxHP;
            characterStats.CurrentHP = unitComponent.CurrentHP;

            GameManager.Instance.characterStats = characterStats;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
