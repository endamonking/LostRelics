using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField]
    private int basedefPoint;
    [SerializeField]
    public int maxHP, baseSPD;

    public int maxPlayerHand = 7;
    public int maxMana = 10;
    public stance myStatnce;

    public int currentDefpoint;
    public int currentHP, currentSPD;
    private cardHandler cardHandler;

    private CharacterBar hpBar;

    private EquipmentStats equipmentStats;

    private void Awake()
    {
        
    }

    void Start()
    {        
        equipmentStats = GetComponent<EquipmentStats>();
        currentSPD = baseSPD + equipmentStats.SPD;
        //currentHP = maxHP + equipmentStats.HP; 
        currentDefpoint = basedefPoint + equipmentStats.Def;
        cardHandler = GetComponent<cardHandler>();
        hpBar = GetComponentInChildren<CharacterBar>();
        hpBar.updateHPBar(maxHP, currentHP);
    }
    
    public void characterSetup()
    {
        equipmentStats = GetComponent<EquipmentStats>();
        currentHP = maxHP + equipmentStats.HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    public void takeDamage(int damage)
    {
        currentHP = currentHP - damage;
        hpBar.updateHPBar(maxHP, currentHP);
        Debug.Log(this.gameObject.name + "take " +damage+" "+ currentHP);
        if (currentHP <= 0)
            died();
    }

    [System.Obsolete]
    private void died()
    {
        combatManager.Instance.target = null;
        combatManager.Instance.returnEffectPosition();
        combatManager.Instance.checkWinLose(this.gameObject);
        Destroy(cardHandler.turnGuageUI.gameObject);
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        if (combatManager.Instance.state != BattleState.PLAYER || combatManager.Instance.isShowDiscard == true)
            return;

        Debug.Log(this.gameObject.name + "Clicked");
        combatManager.Instance.selectedTarget(this.gameObject);
    }

}
