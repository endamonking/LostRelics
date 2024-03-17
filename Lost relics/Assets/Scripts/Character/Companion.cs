using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Companion : MonoBehaviour
{
    public int companionNumber;
    private Rigidbody rb;
    [SerializeField]
    private BoxCollider footCollider;
    // Start is called before the first frame update
    void Start()
    {
        GameObject characterPrefab = Resources.Load<GameObject>("Prefabs/Town/Companion/Companion" + companionNumber.ToString());
        Transform childTranform = this.transform.Find("Character");
        if (childTranform == null) //Will do only once
        {
            GameObject MainCharacter = Instantiate(characterPrefab, this.gameObject.transform);
            MainCharacter.name = "Character";
            Unit unitComponent = MainCharacter.GetComponent<Unit>();
            assignStatToCharacterScript(unitComponent);
        }
        Scene currentScene = SceneManager.GetActiveScene();
        rb = GetComponent<Rigidbody>();
        if (currentScene.name != "TestRoom")
        {
            Destroy(rb);
        }
        else
        {
            footCollider.center = new Vector3(0, -1f, 0);

        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void assignStatToCharacterScript(Unit unit)
    {
        Character character = GetComponentInParent<Character>();
        character.characterName = unit.UnitName;
        character.baseATK = unit.ATK;
        character.baseHeal = unit.Healing;
        character.basedefPoint = unit.DEF;
        character.baseSPD = unit.SPD;
        character.baseCritRate = unit.CritChance;
        character.baseCritDMG = unit.CritDamage;
        character.baseEvade = unit.Evade;
        character.maxHP = unit.MaxHP;
        character.baseResistance = unit.Resistance;
        character.maxMana = unit.maxMana;
        character.characterPassiveSkill = unit.passivSkill;
        character.isMelee = unit.isMelee;
    }
}
