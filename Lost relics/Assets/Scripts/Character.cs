using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Character : MonoBehaviour
{
    [Header("Attribute")]
    public int basedefPoint;
    public int maxHP, baseSPD;
    public string characterName;
    public int maxPlayerHand = 7;
    public int maxMana = 10;
    public int currentDefpoint;
    public int currentHP, currentSPD;
    public int baseArmorPen = 0, baseCritRate = 20, baseCritDMG = 0, baseATK = 30, baseHeal = 10;

    public List<buff> activeBuffs = new List<buff>();
    public List<buff> activeDeBuffs = new List<buff>();

    private cardHandler cardHandler;
    
    private CharacterBar hpBar;
    private TextMeshProUGUI stanceText;

    private characterEquipment equipmentStats;

    public stance myStance = stance.None;
    public stance myPreviousStance;
    private Dictionary<string, int> stanceValue = new Dictionary<string, int>();

    private buffContainer buffContainer;

    public int inComATK
    {
        get
        {
            float totalAttack = baseATK + equipmentStats.bonusATK;
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
            foreach (buff buff in activeDeBuffs)
            {
                if (buff.buffs.ContainsKey("ATK"))
                {
                    totalAttack = totalAttack + (buff.buffs["ATK"] * baseATK / 100.0f);
                }
            }

            int finalValue = Mathf.FloorToInt(totalAttack);
            Debug.Log(finalValue);
            return finalValue;
        }
    }

    public int inComDef
    {
        get
        {
            float totalDEF = basedefPoint + equipmentStats.bonusDEF;
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
            foreach (buff buff in activeDeBuffs)
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
            float totalValue = baseSPD + equipmentStats.bonusSpeed;
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
            foreach (buff buff in activeDeBuffs)
            {
                if (buff.buffs.ContainsKey("SPD"))
                {
                    totalValue = totalValue + (buff.buffs["SPD"] * currentSPD / 100.0f);
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
                totalValue = totalValue + stanceValue["AP"];
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("AP"))
                {
                    totalValue = totalValue + buff.buffs["AP"];
                }
            }
            foreach (buff buff in activeDeBuffs)
            {
                if (buff.buffs.ContainsKey("AP"))
                {
                    totalValue = totalValue + buff.buffs["AP"];
                }
            }
            int finalValue = Mathf.FloorToInt(totalValue);
            return finalValue;
        }
    }
    public int inComCritRate
    {
        
        get
        {
            float totalValue = baseCritRate + equipmentStats.bonusCRITRATE;
            if (stanceValue.ContainsKey("CRITRate"))
            {
                totalValue = totalValue + stanceValue["CRITRate"];
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("CRITRate"))
                {
                    totalValue = totalValue + buff.buffs["CRITRate"];
                }
            }
            foreach (buff buff in activeDeBuffs)
            {
                if (buff.buffs.ContainsKey("CRITRate"))
                {
                    totalValue = totalValue + buff.buffs["CRITRate"];
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
                totalValue = totalValue + stanceValue["CRITDMG"];
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("CRITDMG"))
                {
                    totalValue = totalValue + buff.buffs["CRITDMG"];
                }
            }
            foreach (buff buff in activeDeBuffs)
            {
                if (buff.buffs.ContainsKey("CRITDMG"))
                {
                    totalValue = totalValue + buff.buffs["CRITDMG"];
                }
            }
            int finalValue = Mathf.FloorToInt(totalValue);
            return finalValue;
        }
    }

    public int inComMaxHP
    {
        get
        {
            int characterMaxHP = maxHP + equipmentStats.bonusMAXHP;
            float totalValue = characterMaxHP;
            if (stanceValue.ContainsKey("MAXHP"))
            {
                totalValue = totalValue + (stanceValue["MAXHP"] * characterMaxHP / 100.0f);
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("MAXHP"))
                {
                    totalValue = totalValue + (buff.buffs["MAXHP"] * characterMaxHP / 100.0f);
                }
            }
            foreach (buff buff in activeDeBuffs)
            {
                if (buff.buffs.ContainsKey("MAXHP"))
                {
                    totalValue = totalValue + (buff.buffs["MAXHP"] * characterMaxHP / 100.0f);
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

    public int inComCritRes
    {
        get
        {
            int totalValue = 0;
            if (stanceValue.ContainsKey("CRITRes"))
            {
                totalValue += stanceValue["CRITRes"];
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("CRITRes"))
                {
                    totalValue += buff.buffs["CRITRes"];
                }
            }
            return totalValue;
        }
    }
    public int inComHeal
    {

        get
        {
            float totalValue = baseHeal + equipmentStats.bonusHEAL;
            if (stanceValue.ContainsKey("HEAL"))
            {
                totalValue = totalValue + stanceValue["HEAL"];
            }
            foreach (buff buff in activeBuffs)
            {
                if (buff.buffs.ContainsKey("HEAL"))
                {
                    totalValue = totalValue + buff.buffs["HEAL"];
                }
            }
            foreach (buff buff in activeDeBuffs)
            {
                if (buff.buffs.ContainsKey("HEAL"))
                {
                    totalValue = totalValue + buff.buffs["HEAL"];
                }
            }
            int finalValue = Mathf.FloorToInt(totalValue);
            return finalValue;
        }
    }

    private void Awake()
    {
        //equipmentStats = GetComponent<EquipmentStats>();
    }

    void Start()
    {
        handleCharacterUI();
        combatManager comIns = combatManager.Instance;
        if (comIns == null)
            return;
        equipmentStats = GetComponent<characterEquipment>();
        /*currentSPD = baseSPD + equipmentStats.bonusSpeed;
        currentDefpoint = basedefPoint + equipmentStats.bonusSpeed;*/

        cardHandler = GetComponent<cardHandler>();
        hpBar = GetComponentInChildren<CharacterBar>();
        hpBar.updateHPBar(inComMaxHP, currentHP);

        //Update buff ui
        if (buffContainer == null)
            buffContainer = GetComponentInChildren<buffContainer>();
        List<buff> startBuff = new List<buff>();
        startBuff.AddRange(activeBuffs);
        startBuff.AddRange(activeDeBuffs);
        buffContainer.updateBuffIconUI(startBuff);
    }
    
    public void changingStance(stance inTo)
    {
        updateStanceText(inTo.ToString());
        //Do leave stance effect
        switch (myStance)
        {
            case stance.Exhausted:
                buff deBuff = new buff("Exhausted", 2, "ATK_Down");
                deBuff.AddBuff("SPD", -10);
                deBuff.AddBuff("ATK", -10);
                deBuff.AddBuff("DEF", -20);
                applyActiveDeBuff(deBuff);
                break;
            case stance.Panic:
                buff panic = new buff("Panic", 2,"Fear");
                panic.AddBuff("DEF", -20);
                applyActiveDeBuff(panic);
                break;

        }
        myPreviousStance = myStance;
        myStance = inTo;
        stanceValue.Clear();
        switch (myStance)
        {
            case stance.None:
                break;
            case stance.Defence:
                stanceValue.Add("DEF", 30);
                break;
            case stance.Disarm:
                stanceValue.Add("ATK", -35);
                break;
            case stance.Exhausted:
                stanceValue.Add("ATK", -20);
                stanceValue.Add("DEF", -30);
                stanceValue.Add("SPD", -25);
                break;
            case stance.Sprinting:
                stanceValue.Add("SPD", 25);
                break;
            case stance.Take_aim:
                stanceValue.Add("CRITRate", 20);
                stanceValue.Add("CRITDMG", 30);
                break;
            case stance.Panic:
                stanceValue.Add("DEF", -30);
                stanceValue.Add("SPD", -20);
                break;
            case stance.Preparation:
                stanceValue.Add("ATK", 50);
                stanceValue.Add("DEF", -20);
                break;
        }

    }

    public void characterSetup()
    {
        equipmentStats = GetComponent<characterEquipment>();
        currentHP = maxHP + equipmentStats.bonusMAXHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void applyActiveBuff(buff activeBuff)
    {
        if (buffContainer == null)
            buffContainer = GetComponentInChildren<buffContainer>();

        activeBuffs.Add(activeBuff);
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(activeBuffs);
        allBuff.AddRange(activeDeBuffs);
        if (buffContainer == null) // In case of apply buff in exploration
            return;
        buffContainer.updateBuffIconUI(allBuff);
    }

    public void applyActiveDeBuff(buff activeDeBuff)
    {
        if (buffContainer == null)
            buffContainer = GetComponentInChildren<buffContainer>();

        activeDeBuffs.Add(activeDeBuff);
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(activeBuffs);
        allBuff.AddRange(activeDeBuffs);
        Debug.Log(buffContainer);
        if (buffContainer == null) // In case of apply buff in exploration
            return;
        buffContainer.updateBuffIconUI(allBuff);
    }

    public void removeActiveBuff(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if (i >= activeBuffs.Count)
                break;
            activeBuffs.Remove(activeBuffs[i]);
        }
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(activeBuffs);
        allBuff.AddRange(activeDeBuffs);
        buffContainer.updateBuffIconUI(allBuff);
    }

    public void removeActiveDeBuff(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if (i >= activeDeBuffs.Count)
            {
                Debug.Log("No");
                break;
            }
            Debug.Log("remove " + activeDeBuffs[i].buffName);
            activeDeBuffs.Remove(activeDeBuffs[i]);
        }
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(activeBuffs);
        allBuff.AddRange(activeDeBuffs);
        buffContainer.updateBuffIconUI(allBuff);
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
            if (debuff.buffs.Count > 0)
            {
                foreach (string key in debuff.buffs.Keys) // Do effect
                {
                    switch (key)
                    {
                        case "Poison":
                            takeTrueDamage(debuff.buffs[key]);
                            break;
                        case "PoisonMaxHP":
                            int DMGAmount = debuff.buffs[key] * inComMaxHP / 100;
                            takeTrueDamage(DMGAmount);
                            break;
                        default:
                            break;
                    }
                }
            }

            debuff.duration--;
            if (debuff.duration <= 0)
            {
                activeDeBuffs.RemoveAt(i);
                // Handle any post-buff effects here
            }

        }
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(activeBuffs);
        allBuff.AddRange(activeDeBuffs);
        buffContainer.updateBuffIconUI(allBuff);
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
    public void takeDamage(int enemyATK, int enemyArmorPen, int enemyDamageBonus, float skillMutiplier, int enemyCritRate, int enemyCritDMG)
    {
        int damage = calcualteDamage(enemyATK, enemyArmorPen, enemyDamageBonus, skillMutiplier, enemyCritRate, enemyCritDMG);
        currentHP = currentHP - damage;
        hpBar.updateHPBar(maxHP, currentHP);
        Debug.Log(this.gameObject.name + "take " +damage+" "+ currentHP);
        if (currentHP <= 0)
            died();
    }

    //Usally use for turn base damage like poison
    public void takeTrueDamage(int damageAmount)
    {
        if (damageAmount <= 0)
            damageAmount = 0;
        currentHP = currentHP - damageAmount;
        hpBar.updateHPBar(maxHP, currentHP);
        Debug.Log(this.gameObject.name + "take " + damageAmount + " " + currentHP);
        if (currentHP <= 0)
            died();
    }


    private int calcualteDamage(int enemyATK, int enemyArmorPen, int enemyDamageBonus, float skillMutiplier, int enemyCritRate, int enemyCritDMG)
    {
        int finalDamage = 0;
        float damage = 0;
        int defReduction = GetDeBuffValue("DEFReduction");
        int damageReduction = GetBuffValue("DMGReduction");
        float randomNumber = Random.value;
        //Case AP exceed 100
        if (enemyArmorPen >= 100)
            enemyArmorPen = 100;

        if (randomNumber < enemyCritRate / 100.0f) //Critical hit
            damage = (enemyATK - inComDef * (1 - (enemyArmorPen / 100.0f)) * (1 - (defReduction / 100.0f))) * (1 + (enemyDamageBonus / 100.0f) - (damageReduction / 100.0f)) * skillMutiplier * (1.5f + (enemyCritDMG/100.0f) - (inComCritRes/100.0f));
        else
            damage = (enemyATK - inComDef * (1 - (enemyArmorPen / 100.0f)) * (1 - (defReduction / 100.0f))) * (1 + (enemyDamageBonus/ 100.0f) - (damageReduction/ 100.0f)) * skillMutiplier;


        finalDamage = Mathf.FloorToInt(damage);
        if (finalDamage <= (enemyATK * 0.2f))
        {
            damage = enemyATK * 0.2f;
            finalDamage = Mathf.FloorToInt(damage);
        }

        return finalDamage;
    }

    private void handleCharacterUI()
    {
        GameObject childObject = transform.Find("HPCanvas").gameObject;
        Scene currentScene = SceneManager.GetActiveScene();
        stanceText = childObject.GetComponentInChildren<TextMeshProUGUI>();
        if (currentScene.name == "TestRoom")
            childObject.SetActive(false);
        else
            childObject.SetActive(true);
    }

    private void updateStanceText(string newStance)
    {
        stanceText.text = newStance;
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

    /*private void OnMouseDown()
    {
        if (combatManager.Instance.state != BattleState.PLAYER || combatManager.Instance.isShowDiscard == true)
            return;

        Debug.Log(this.gameObject.name + "Clicked");
        combatManager.Instance.selectedTarget(this.gameObject);
    }*/
    


}
