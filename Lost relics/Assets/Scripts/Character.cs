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
    public int baseArmorPen = 0, baseCritChance = 20, baseCritDMG = 0, baseATK = 30;

    public List<buff> activeBuffs = new List<buff>();
    public List<buff> activeDeBuffs = new List<buff>();

    private cardHandler cardHandler;

    private CharacterBar hpBar;

    private EquipmentStats equipmentStats;
    public int inComATK
    {
        get
        {
            int totalAttack = baseATK;
            foreach(buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("ATK"))
                {
                    totalAttack += buff.buffs["ATK"];
                }
            }
            return totalAttack;
        }
    }

    public int inComDef
    {
        get
        {
            int totalDEF = currentDefpoint;
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("DEF"))
                {
                    totalDEF += buff.buffs["DEF"];
                }
            }
            return totalDEF;
        }
    }

    public int inComSPD
    {
        get
        {
            int totalValue = currentSPD;
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("SPD"))
                {
                    totalValue += buff.buffs["SPD"];
                }
            }
            return totalValue;
        }
    }
    public int inComArmorPen
    {
        get
        {
            int totalValue = baseArmorPen;
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("AP"))
                {
                    totalValue += buff.buffs["AP"];
                }
            }
            return totalValue;
        }
    }
    public int inComCritChance
    {
        get
        {
            int totalValue = baseCritChance;
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("CRITChance"))
                {
                    totalValue += buff.buffs["CRITChance"];
                }
            }
            return totalValue;
        }
    }

    public int inComCritDMG
    {
        get
        {
            int totalValue = baseCritDMG;
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("CRITDMG"))
                {
                    totalValue += buff.buffs["CRITDMG"];
                }
            }
            return totalValue;
        }
    }

    public int inComDMGBonus
    {
        get
        {
            int totalValue = 0;
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("DMGBonus"))
                {
                    totalValue += buff.buffs["DMGBonus"];
                }
            }
            return totalValue;
        }
    }

    private void Awake()
    {
        
    }

    void Start()
    {        
        equipmentStats = GetComponent<EquipmentStats>();
        currentSPD = baseSPD + equipmentStats.SPD;
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

    public int GetBuffValue(string propertyName)
    {
        int totalBuffValue = 0;

        foreach (buff buff in activeBuffs)
        {
            if (buff.buffs.ContainsKey(propertyName))
            {
                totalBuffValue += buff.buffs[propertyName];
            }
        }

        return totalBuffValue;
    }

    public int GetDeBuffValue(string propertyName)
    {
        int totalBuffValue = 0;

        foreach (buff buff in activeDeBuffs)
        {
            if (buff.buffs.ContainsKey(propertyName))
            {
                totalBuffValue += buff.buffs[propertyName];
            }
        }

        return totalBuffValue;
    }

    [System.Obsolete]
    public void takeDamage(int enemyATK, int enemyArmorPen, int enemyDamageBonus, float skillMutiplier)
    {
        int damage = calcualteDamage(enemyATK, enemyArmorPen, enemyDamageBonus, skillMutiplier);
        currentHP = currentHP - damage;
        hpBar.updateHPBar(maxHP, currentHP);
        Debug.Log(this.gameObject.name + "take " +damage+" "+ currentHP);
        if (currentHP <= 0)
            died();
    }


    private int calcualteDamage(int enemyATK, int enemyArmorPen, int enemyDamageBonus, float skillMutiplier)
    {
        int finalDamage = 0;
        float damage = 0;
        int defReduction = GetDeBuffValue("DEFReduction");
        int damageReduction = GetBuffValue("DMGReduction");
        damage = (enemyATK - inComDef * (1 - (enemyArmorPen / 100)) * (1 - (defReduction / 100))) * (1 + (enemyDamageBonus/100) - (damageReduction/100)) * skillMutiplier;

        finalDamage = Mathf.FloorToInt(damage);
        if (finalDamage <= (enemyATK * 0.2f))
        {
            damage = enemyATK * 0.2f;
            finalDamage = Mathf.FloorToInt(damage);
        }

        return finalDamage;
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
