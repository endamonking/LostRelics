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
    public int currentDefpoint;
    public int currentHP, currentSPD;
    public int baseArmorPen = 0, baseCritChance = 20, baseCritDMG = 0, baseATK = 30;

    public List<buff> activeBuffs = new List<buff>();
    public List<buff> activeDeBuffs = new List<buff>();

    private cardHandler cardHandler;

    private CharacterBar hpBar;

    private EquipmentStats equipmentStats;

    public stance myStance = stance.None;
    public stance myPreviousStance;
    private Dictionary<string, int> stanceValue = new Dictionary<string, int>();

    public int inComATK
    {
        get
        {
            float totalAttack = baseATK;
            if (stanceValue.ContainsKey("ATK"))
            {
                totalAttack = totalAttack + (stanceValue["ATK"] * baseATK / 100.0f);
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("ATK"))
                {
                    totalAttack = totalAttack + (buff.buffs["ATK"] * baseATK / 100.0f);
                }
            }

            int finalValue = Mathf.FloorToInt(totalAttack);
            return finalValue;
        }
    }

    public int inComDef
    {
        get
        {
            float totalDEF = currentDefpoint;
            if (stanceValue.ContainsKey("DEF"))
            {
                totalDEF = ( stanceValue["DEF"] * currentDefpoint /100.0f) + totalDEF;
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("DEF"))
                {
                    totalDEF = totalDEF + (buff.buffs["DEF"] * currentDefpoint / 100.0f);
                }
            }
            int finalDEF = Mathf.FloorToInt(totalDEF);
            Debug.Log(finalDEF);
            return finalDEF;
        }
    }

    public int inComSPD
    {
        get
        {
            float totalValue = currentSPD;
            if (stanceValue.ContainsKey("SPD"))
            {
                totalValue = totalValue + (stanceValue["SPD"]*currentSPD/100.0f);
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("SPD"))
                {
                    totalValue = totalValue + (buff.buffs["SPD"]*currentSPD/100.0f);
                }
            }
            int finalValue = Mathf.FloorToInt(totalValue);

            return finalValue;
        }
    }
    public int inComArmorPen
    {
        get
        {
            float totalValue = baseArmorPen;
            if (stanceValue.ContainsKey("AP"))
            {
                totalValue = totalValue + (stanceValue["AP"] * baseArmorPen / 100.0f);
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("AP"))
                {
                    totalValue = totalValue + (buff.buffs["AP"] * baseArmorPen / 100.0f);
                }
            }
            int finalValue = Mathf.FloorToInt(totalValue);
            return finalValue;
        }
    }
    public int inComCritChance
    {
        
        get
        {
            float totalValue = baseCritChance;
            if (stanceValue.ContainsKey("CRITChance"))
            {
                totalValue = totalValue + (stanceValue["CRITChance"] * baseCritChance / 100.0f);
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("CRITChance"))
                {
                    totalValue = totalValue + (buff.buffs["CRITChance"] * baseCritChance / 100.0f);
                }
            }
            int finalValue = Mathf.FloorToInt(totalValue);
            return finalValue;
        }
    }

    public int inComCritDMG
    {
        get
        {
            float totalValue = baseCritDMG;
            if (stanceValue.ContainsKey("CRITDMG"))
            {
                totalValue = totalValue + (stanceValue["CRITDMG"] * baseCritDMG / 100.0f);
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("CRITDMG"))
                {
                    totalValue = totalValue + (buff.buffs["CRITDMG"] * baseCritDMG / 100.0f);
                }
            }
            int finalValue = Mathf.FloorToInt(totalValue);
            return finalValue;
        }
    }

    public int inComDMGBonus
    {
        get
        {
            int totalValue = 0;
            if (stanceValue.ContainsKey("DMGBonus"))
            {
                totalValue += stanceValue["DMGBonus"];
            }
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
    
    public void changingStance(stance inTo)
    {
        myPreviousStance = myStance;
        myStance = inTo;
        stanceValue.Clear();
        switch (myStance)
        {
            case stance.None:
                return;
            case stance.Defence:
                stanceValue.Add("DEF", 30);
                return;

        }

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

    public void applyActiveBuff(buff activeBuff)
    {
        activeBuffs.Add(activeBuff);
    }

    public void applyActiveDeBuff(buff activeDeBuff)
    {
        activeDeBuffs.Add(activeDeBuff);
    }

    public void updateBuffAndDebuff()
    {

        for (int i = activeBuffs.Count - 1; i >= 0; i--)
        {
            buff buff = activeBuffs[i];
            buff.duration--;

            if (buff.duration <= 0)
            {
                activeBuffs.RemoveAt(i);
                // Handle any post-buff effects here
            }
        }

        for (int i = activeDeBuffs.Count - 1; i >= 0; i--)
        {
            buff debuff = activeDeBuffs[i];
            debuff.duration--;

            if (debuff.duration <= 0)
            {
                activeDeBuffs.RemoveAt(i);
                // Handle any post-buff effects here
            }
        }
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
