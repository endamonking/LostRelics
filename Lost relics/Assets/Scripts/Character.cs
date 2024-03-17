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
    //New evade and resis(Get debuff rate)
    public int baseArmorPen = 0, baseCritRate = 20, baseCritDMG = 0, baseATK = 30, baseHeal = 10, baseEvade = 0, 
        baseResistance = 0;
    [Header("Buff")]
    public List<buff> activeBuffs = new List<buff>();
    public List<buff> activeDeBuffs = new List<buff>();
    public List<buff> activeUnClearBuffs = new List<buff>();
    public List<buff> activeUnClearDeBuffs = new List<buff>();

    [Header("Stance")]
    public stance myStance = stance.None;
    public stance myPreviousStance;
    private Dictionary<string, int> stanceValue = new Dictionary<string, int>();
    private buffContainer buffContainer;
    private TextMeshProUGUI stanceText;
    [Header("Passive skill")]
    public uniquePassSkill characterPassiveSkill;
    //Script
    private CharacterBar hpBar;
    private characterEquipment equipmentStats;
    private cardHandler cardHandler;
    [HideInInspector]
    public animationController animController;
    [HideInInspector]
    public characterAudioControl characterAudio;
    [Header("Other")]
    [SerializeField]
    private GameObject dmgPopupPrefab;
    public bool isMelee; //Is this character use melee?
    public int inComATK
    {
        get
        {
            float totalAttack = baseATK + equipmentStats.bonusATK;
            if (stanceValue.ContainsKey("ATK"))
            {
                totalAttack = totalAttack + (stanceValue["ATK"] * baseATK / 100.0f);
            }
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
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
                totalDEF = ( stanceValue["DEF"] * basedefPoint / 100.0f) + totalDEF;
            }
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
            {
                if (buff.buffs.ContainsKey("DEF"))
                {
                    totalDEF = totalDEF + (buff.buffs["DEF"] * basedefPoint / 100.0f);
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
                totalValue = totalValue + (stanceValue["SPD"]* baseSPD / 100.0f);
            }
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
            {
                if (buff.buffs.ContainsKey("SPD"))
                {
                    totalValue = totalValue + (buff.buffs["SPD"] * baseSPD / 100.0f);
                }
            }
            int finalValue = Mathf.FloorToInt(totalValue);
            if (finalValue <= 0)
                finalValue = 1;
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
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
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
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
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
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
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
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
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
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
            {
                if (buff.buffs.ContainsKey("DMGBonus"))
                {
                    totalValue = totalValue + buff.buffs["DMGBonus"];
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
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
            {
                if (buff.buffs.ContainsKey("CRITRes"))
                {
                    totalValue = totalValue + buff.buffs["CRITRes"];
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
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
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
    public int inComEvade
    {

        get
        {
            float totalValue = baseEvade + equipmentStats.bonusEvade;
            if (stanceValue.ContainsKey("EVADE"))
            {
                totalValue = totalValue + stanceValue["EVADE"];
            }
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
            {
                if (buff.buffs.ContainsKey("EVADE"))
                {
                    totalValue = totalValue + buff.buffs["EVADE"];
                }
            }
            int finalValue = Mathf.FloorToInt(totalValue);
            return finalValue;
        }
    }
    public int inComResistance
    {

        get
        {
            float totalValue = baseResistance + equipmentStats.bonusResistance;
            if (stanceValue.ContainsKey("RESISTANCE"))
            {
                totalValue = totalValue + stanceValue["RESISTANCE"];
            }
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
            {
                if (buff.buffs.ContainsKey("RESISTANCE"))
                {
                    totalValue = totalValue + buff.buffs["RESISTANCE"];
                }
            }
            int finalValue = Mathf.FloorToInt(totalValue);
            if (finalValue < 0)
                finalValue = 0;
            return finalValue;
        }
    }
    public int inComDMGReduction
    {
        get
        {
            float totalValue = 0;
            if (stanceValue.ContainsKey("DMGReduction"))
            {
                totalValue = totalValue + stanceValue["DMGReduction"];
            }
            List<buff> allBuff = getAllBuffs();
            foreach (buff buff in allBuff)
            {
                if (buff.buffs.ContainsKey("DMGReduction"))
                {
                    totalValue = totalValue + buff.buffs["DMGReduction"];
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

        cardHandler = GetComponent<cardHandler>();
        hpBar = GetComponentInChildren<CharacterBar>();
        animController = GetComponentInChildren<animationController>();
        characterAudio = GetComponentInChildren<characterAudioControl>();
        hpBar.updateHPBar(inComMaxHP, currentHP);

        //Update buff ui
        if (buffContainer == null)
            buffContainer = GetComponentInChildren<buffContainer>();
        List<buff> startBuff = getAllBuffs();
        buffContainer.updateBuffIconUI(startBuff);
        //Passive
        if (characterPassiveSkill != null)
            characterPassiveSkill.initPassive(this.gameObject);
    }
    
    public void changingStance(stance inTo, bool isForce)
    {

        if (GetDeBuffValue("Restraint") > 0 && isForce != true)
            return;
        updateStanceText(inTo.ToString());
        //Do leave stance effect
        switch (myStance)
        {
            case stance.Exhausted:
                string des = "Decrease DEF for 20%, SPD for 10%, and ATK for 10%";
                buff deBuff = new buff("Exhausted", 2, "ATK_Down",des);
                deBuff.AddBuff("SPD", -10);
                deBuff.AddBuff("ATK", -10);
                deBuff.AddBuff("DEF", -20);
                applyActiveDeBuff(deBuff,false);
                break;
            case stance.Panic:
                string des1 = "Decrease DEF for 20%";
                buff panic = new buff("Panic", 2, "DEF_Down", des1);
                panic.AddBuff("DEF", -20);
                applyActiveDeBuff(panic,false);
                break;

        }
        myPreviousStance = myStance;
        myStance = inTo;
        stanceValue.Clear();
        //Stance effect
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
            case stance.Exposed:
                stanceValue.Add("DEF", -30);
                break;
            case stance.Flow:
                int atkpower = cardHandler.cardDrawedThisTurn * 10;
                stanceValue.Add("ATK", atkpower);
                break;
            case stance.Temporal:
                stanceValue.Add("SPD", 25);
                break;
            case stance.Ethereal:
                stanceValue.Add("EVADE", 50);
                stanceValue.Add("DEF", -100);
                break;
            case stance.Rage:
                stanceValue.Add("ATK", 20);
                break;
            case stance.Blade_Dance:
                stanceValue.Add("SPD", 20);
                stanceValue.Add("CRITRate", 10);
                break;
            case stance.Phantom_Assault:
                stanceValue.Add("SPD", 30);
                stanceValue.Add("EVADE", 20);
                break;
            case stance.Counter:
                stanceValue.Add("DEF", 20);
                break;
            case stance.Frenzy:
                stanceValue.Add("ATK",20);
                stanceValue.Add("CRITDMG", 50);
                break;
            case stance.Zan:
                stanceValue.Add("DMGReduction", 100);
                break;
            case stance.Purification:
                stanceValue.Add("EVADE", 10);
                stanceValue.Add("DEF", 25);
                break;
            case stance.Showdown:
                stanceValue.Add("CRITRate", 50);
                stanceValue.Add("DEF", -40);
                break;
            case stance.Reloading:
                stanceValue.Add("SPD", 20);
                stanceValue.Add("ATK", -50);
                break;

        }

    }
    public void doStanceOnDrawEffect()
    {

        switch (myStance)
        {
            case stance.Flow:
                stanceValue.Clear();
                int atkpower = cardHandler.cardDrawedThisTurn * 10;
                stanceValue.Add("ATK", atkpower);
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

    public void applyActiveBuff(buff activeBuff, bool isUnclear)
    {
        if (buffContainer == null)
            buffContainer = GetComponentInChildren<buffContainer>();
        if (equipmentStats == null)
            equipmentStats = GetComponent<characterEquipment>();
        //Check if the same buff
        buff currentBuff = findBuffContainByName(activeBuff.buffName);
        if (currentBuff != null)
        {
            removeBuff(currentBuff);
        }
        //apply
        if (isUnclear)
            activeUnClearBuffs.Add(activeBuff);
        else
            activeBuffs.Add(activeBuff);

        List<buff> allBuff = getAllBuffs();
        if (buffContainer == null) // In case of apply buff in exploration
            return;
        buffContainer.updateBuffIconUI(allBuff);
    }

    public void applyActiveDeBuff(buff activeDeBuff, bool isUnclear)
    {
        if (buffContainer == null)
            buffContainer = GetComponentInChildren<buffContainer>();
        if (equipmentStats == null)
            equipmentStats = GetComponent<characterEquipment>();

        if (isUnclear)
        {
            float debuffNumber = Random.value;
            float debuffRes = 100 * (1 - inComResistance / 100.0f);
            if (debuffNumber < debuffRes / 100.0f) 
                activeUnClearDeBuffs.Add(activeDeBuff);

        }
        else
        {
            float debuffNumber = Random.value;
            float debuffRes = 100.0f * (1 - inComResistance / 100.0f);
            if (debuffNumber < debuffRes / 100.0f)
                activeDeBuffs.Add(activeDeBuff);
        }

        List<buff> allBuff = getAllBuffs();
        if (buffContainer == null) // In case of apply buff in exploration
            return;
        buffContainer.updateBuffIconUI(allBuff);
    }

    public void removeActiveBuff(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Debug.Log("remove " + activeBuffs[0].buffName);
            activeBuffs.RemoveAt(0);
        }
        List<buff> allBuff = getAllBuffs();
        buffContainer.updateBuffIconUI(allBuff);
    }

    public void removeActiveDeBuff(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Debug.Log("remove " + activeDeBuffs[0].buffName);
            activeDeBuffs.RemoveAt(0);
        }

        List<buff> allBuff = getAllBuffs();
        buffContainer.updateBuffIconUI(allBuff);
    }
    //Unlike removeActiveBuff and Debuff this function use to remove buff from activeBuff and Unclear buff to make
    //The effect of buff only active at one Example in ArcaneChanneling.cs
    public void removeBuff(buff thisBuff)
    {

        if (activeBuffs.Contains(thisBuff))
            activeBuffs.Remove(thisBuff);
        if (activeDeBuffs.Contains(thisBuff))
            activeDeBuffs.Remove(thisBuff);
        if (activeUnClearBuffs.Contains(thisBuff))
            activeUnClearBuffs.Remove(thisBuff);
        if (activeUnClearDeBuffs.Contains(thisBuff))
            activeUnClearDeBuffs.Remove(thisBuff);
        Debug.Log(thisBuff);
        updateBuffContainer();

    }
    public buff findBuffContainByName(string buffName)
    {
        List<buff> allBuff = getAllBuffs();

        foreach (buff b in allBuff)
        {
            if (b.buffName == buffName)
                return b;
               
        }
        return null;
    }

    //If buff has duration more than 90 that mean it permanantBuff
    public void updateBuffAndDebuff()
    {
        for (int i = activeBuffs.Count - 1; i >= 0; i--)
        {
            buff buff = activeBuffs[i];
            if (buff.duration >= 90)
                continue;
            buff.duration--;
            if (buff.duration <= 0)
            {
                activeBuffs.RemoveAt(i);
                // Handle any post-buff effects here
            }
        }
        for (int i = activeUnClearBuffs.Count - 1; i >= 0; i--)
        {
            buff buff = activeUnClearBuffs[i];
            if (buff.duration >= 90)
                continue;
            buff.duration--;
            if (buff.duration <= 0)
            {
                activeUnClearBuffs.RemoveAt(i);
                // Handle any post-buff effects here
            }
        }

        for (int i = activeDeBuffs.Count - 1; i >= 0; i--)
        {
            buff debuff = activeDeBuffs[i];
            if (debuff.duration >= 90)
                continue;
            debuff.duration--;
            if (debuff.duration <= 0)
            {
                activeDeBuffs.RemoveAt(i);
                // Handle any post-buff effects here
            }

        }

        for (int i = activeUnClearDeBuffs.Count - 1; i >= 0; i--)
        {
            buff debuff = activeUnClearDeBuffs[i];
            if (debuff.duration >= 90)
                continue;
            debuff.duration--;
            if (debuff.duration <= 0)
            {
                activeUnClearDeBuffs.RemoveAt(i);
                // Handle any post-buff effects here
            }

        }

        updateBuffContainer();
    }
    public void applyDebuffEffect()
    {
        List<buff> allActiveDebuff = new List<buff>();
        allActiveDebuff.AddRange(activeDeBuffs);
        allActiveDebuff.AddRange(activeUnClearDeBuffs);

        for (int i = allActiveDebuff.Count - 1; i >= 0; i--)
        {
            buff debuff = allActiveDebuff[i];
            if (debuff.buffs.Count > 0)
            {
                foreach (string key in debuff.buffs.Keys) // Do effect
                {
                    switch (key)
                    {
                        case "Poison":
                            takeTrueDamage(debuff.buffs[key]);
                            break;
                        case "Burn":
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

        }
    }
    //Do buff efffect when dead 
    //right now is has only bomb
    public void applyOnDeadEffect()
    {
        List<buff> allActiveDebuff = new List<buff>();
        allActiveDebuff.AddRange(activeDeBuffs);
        allActiveDebuff.AddRange(activeUnClearDeBuffs);

        for (int i = allActiveDebuff.Count - 1; i >= 0; i--)
        {
            buff aBuff = allActiveDebuff[i];
            if (aBuff.buffs.Count > 0)
            {
                foreach (string key in aBuff.buffs.Keys) // Do effect
                {
                    switch (key)
                    {
                        case "Bomb":
                            List<GameObject> enemies = new List<GameObject>();
                            combatManager cm = combatManager.Instance;
                            //Find is player turn or enemy
                            if (this.gameObject.tag == "Player")
                            {
                                enemies.AddRange(cm.getAllPlayer());
                            }
                            else
                                enemies.AddRange(cm.getAllEnemies());
                            foreach (GameObject enemy in enemies)
                            {
                                Character target = enemy.GetComponent<Character>();
                                target.takeTrueDamage(aBuff.buffs[key]);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

        }
    }

    public void updateBuffContainer()
    {
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(activeBuffs);
        allBuff.AddRange(activeDeBuffs);
        allBuff.AddRange(activeUnClearBuffs);
        allBuff.AddRange(activeUnClearDeBuffs);
        buffContainer.updateBuffIconUI(allBuff);
    }
    public buff GetBuffByName(string BuffName)
    {
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(activeBuffs);
        allBuff.AddRange(activeUnClearBuffs);
        foreach (buff b in allBuff)
        {
            if (b.buffName == BuffName)
            {
                return b;
            }
        }

        return null;
    }

    public int GetBuffValue(string propertyName)
    {
        int totalBuffValue = 0;
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(activeBuffs);
        allBuff.AddRange(activeUnClearBuffs);
        foreach (buff buff in allBuff)
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
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(activeDeBuffs);
        allBuff.AddRange(activeUnClearDeBuffs);
        foreach (buff buff in allBuff)
        {
            if (buff.buffs.ContainsKey(propertyName))
            {
                totalBuffValue += buff.buffs[propertyName];
            }
        }

        return totalBuffValue;
    }
    public int takeDamageWithDMGReturn(int enemyATK, int enemyArmorPen, int enemyDamageBonus, float skillMutiplier, int enemyCritRate, int enemyCritDMG)
    {
        int damage = calcualteDamage(enemyATK, enemyArmorPen, enemyDamageBonus, skillMutiplier, enemyCritRate, enemyCritDMG);
        if (damage > 0) // hit
        {
            currentHP = currentHP - damage;
            doOnHitEffect();
            hpBar.updateHPBar(inComMaxHP, currentHP);
            Debug.Log(this.gameObject.name + "take " + damage + " " + currentHP);
            //Play animation and sound
            if (animController)
                animController.playHurtAnim();

            if (characterAudio != null)
                characterAudio.playHurtSound();
            //Show dmg popup
            if (dmgPopupPrefab != null)
            {
                GameObject popup = Instantiate(dmgPopupPrefab, transform.position, Quaternion.identity);
                popup.GetComponent<popUpDMG>().popUpDamage(damage);

            }
        }
        else //Evaded
        {
            //Play animation and sound
            if (animController)
                animController.playEvadeAnim();

            if (characterAudio != null)
                characterAudio.playDodgeSound();

            //Show dmg popup
            if (dmgPopupPrefab != null)
            {
                GameObject popup = Instantiate(dmgPopupPrefab, transform.position, Quaternion.identity);
                popup.GetComponent<popUpDMG>().popUpDamage(0);

            }
        }
        if (currentHP <= 0)
            died();
        return damage;
    }

    [System.Obsolete]
    public void takeDamage(int enemyATK, int enemyArmorPen, int enemyDamageBonus, float skillMutiplier, int enemyCritRate, int enemyCritDMG)
    {
        int damage = calcualteDamage(enemyATK, enemyArmorPen, enemyDamageBonus, skillMutiplier, enemyCritRate, enemyCritDMG);
        if (damage > 0) // hit
        {
            currentHP = currentHP - damage;
            doOnHitEffect();
            hpBar.updateHPBar(inComMaxHP, currentHP);
            Debug.Log(this.gameObject.name + "take " + damage + " " + currentHP);
            //Play animation and sound
            if (animController)
                animController.playHurtAnim();

            if (characterAudio != null)
                characterAudio.playHurtSound();

            //Show dmg popup
            if (dmgPopupPrefab != null)
            {
                GameObject popup = Instantiate(dmgPopupPrefab, transform.position, Quaternion.identity);
                popup.GetComponent<popUpDMG>().popUpDamage(damage);

            }
        }
        else //Evaded
        {
            //Play animation and sound
            if (animController)
                animController.playEvadeAnim();

            if (characterAudio != null)
                characterAudio.playDodgeSound();

            //Show dmg popup
            if (dmgPopupPrefab != null)
            {
                GameObject popup = Instantiate(dmgPopupPrefab, transform.position, Quaternion.identity);
                popup.GetComponent<popUpDMG>().popUpDamage(0);

            }
        }
        if (currentHP <= 0)
            died();
    }
    // use when effect on hit cause infinit loop
    //By not call on hit effect in original funtion
    //Note it will ingore other on hit effect (Such as take extra damage, reduce damage)
    [System.Obsolete]
    public void takeDamageIgnoreOnHit(int enemyATK, int enemyArmorPen, int enemyDamageBonus, float skillMutiplier, int enemyCritRate, int enemyCritDMG)
    {

        int damage = calcualteDamage(enemyATK, enemyArmorPen, enemyDamageBonus, skillMutiplier, enemyCritRate, enemyCritDMG);
        if (damage > 0) // hit
        {
            currentHP = currentHP - damage;
            doOnHitEffect();
            hpBar.updateHPBar(inComMaxHP, currentHP);
            Debug.Log(this.gameObject.name + "take " + damage + " " + currentHP);
            //Play animation and sound
            if (animController)
                animController.playHurtAnim();

            if (characterAudio != null)
                characterAudio.playHurtSound();
            //Show dmg popup
            if (dmgPopupPrefab != null)
            {
                GameObject popup = Instantiate(dmgPopupPrefab, transform.position, Quaternion.identity);
                popup.GetComponent<popUpDMG>().popUpDamage(damage);

            }
        }
        else //Evaded
        {

        }
        if (currentHP <= 0)
            died();
    }

    //Usally use for turn base damage like poison
    public void takeTrueDamage(int damageAmount)
    {
        if (damageAmount <= 0)
            damageAmount = 0;

        //Play animation and sound
        if (animController)
            animController.playHurtAnim();

        if (characterAudio != null)
            characterAudio.playHurtSound();

        //Show dmg popup
        if (dmgPopupPrefab != null)
        {
            GameObject popup = Instantiate(dmgPopupPrefab, transform.position, Quaternion.identity);
            popup.GetComponent<popUpDMG>().popUpDamage(damageAmount);

        }

        currentHP = currentHP - damageAmount;
        doOnHitEffect();
        hpBar.updateHPBar(inComMaxHP, currentHP);
        Debug.Log(this.gameObject.name + "take " + damageAmount + " " + currentHP);
        if (currentHP <= 0)
            died();
    }
    //Usally use for turn base damage like poison
    //Use when effect on hit cause infinit loop
    //By not call on hit effect in original funtion
    //Note it will ingore other on hit effect (Such as take extra damage, reduce damage)
    public void takeTrueDamageIgnoreOnHit(int damageAmount)
    {

        if (damageAmount <= 0)
            damageAmount = 0;

        //Play animation and sound
        if (animController)
            animController.playHurtAnim();

        if (characterAudio != null)
            characterAudio.playHurtSound();
        //Show dmg popup
        if (dmgPopupPrefab != null)
        {
            GameObject popup = Instantiate(dmgPopupPrefab, transform.position, Quaternion.identity);
            popup.GetComponent<popUpDMG>().popUpDamage(damageAmount);

        }
        currentHP = currentHP - damageAmount;
        hpBar.updateHPBar(inComMaxHP, currentHP);
        Debug.Log(this.gameObject.name + "take " + damageAmount + " " + currentHP);
        if (currentHP <= 0)
            died();
    }

    private void doOnHitEffect()
    {
        //Stance on hit Effect
        switch (myStance)
        {
            case stance.Counter:
                Character target = combatManager.Instance.currentObjTurn.GetComponent<Character>(); //
                if (target != this) //Only enemy 
                {
                    int userDamage = inComATK;
                    int userAP = inComArmorPen;
                    int userDMGBonus = inComDMGBonus;
                    int userCritRate = inComCritRate;
                    int userCritDMG = inComCritDMG;
                    float skillMulti = 20 / 100.0f;
                    target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
                    changingStance(stance.None, false);
                }
                break;
            case stance.Zan:
                Character zanTarget = combatManager.Instance.currentObjTurn.GetComponent<Character>(); //
                if (zanTarget != this) //Only enemy 
                {
                    int dmg = inComMaxHP - currentHP;
                    zanTarget.takeTrueDamage(dmg);
                    changingStance(stance.None, false);
                }
                break;
        }
        //Buff
        List<buff> allBuff = getAllBuffs();
        foreach (buff a in allBuff)
        {
            if (a.doOnHitFuntion != null)
            {
                a.doOnHitFuntion(this);
            }
        }
    }

    public void getHeal(int healPower, float skillMutiplier)
    {
        if (healPower <= 0)
            healPower = 0;
        float healReduction = GetDeBuffValue("HEALReduction");
        if (healReduction >= 100.0f)
            healReduction = 100.0f;
        float value = (healPower * (1 - (healReduction / 100.0f))) * skillMutiplier;
        int finalValue = Mathf.FloorToInt(value);
        currentHP = currentHP + finalValue;
        if (currentHP >= inComMaxHP)
            currentHP = inComMaxHP;
        hpBar.updateHPBar(inComMaxHP, currentHP);
        Debug.Log(this.gameObject.name + "Heal " + finalValue + " " + currentHP);
        if (currentHP <= 0)
            died();
    }

    //use to calculate damagae in normal use case
    //Has some speical use case liek weaknessExploitation.cs
    //If want to force crit just assign crit rate = 200
    //If want ignore def put AP = 100
    private int calcualteDamage(int enemyATK, int enemyArmorPen, int enemyDamageBonus, float skillMutiplier, int enemyCritRate, int enemyCritDMG)
    {
        int finalDamage = 0;
        //Evade 
        float evadenumber = Random.value;
        if (evadenumber < inComEvade / 100.0f) // Evade
            return finalDamage = 0;

        float damage = 0;
        float randomNumber = Random.value;
        //Case AP exceed 100
        if (enemyArmorPen >= 100)
            enemyArmorPen = 100;
        int defReduction = GetDeBuffValue("DEFReduction");
        if (defReduction >= 100.0f)
            defReduction = 0;

        if (randomNumber < enemyCritRate / 100.0f) //Critical hit
            damage = (enemyATK - inComDef * (1 - (enemyArmorPen / 100.0f)) * (1 - (defReduction / 100.0f))) * (1 + (enemyDamageBonus / 100.0f) - (inComDMGReduction / 100.0f)) * skillMutiplier * ((enemyCritDMG/100.0f) - (inComCritRes/100.0f));
        else
            damage = (enemyATK - inComDef * (1 - (enemyArmorPen / 100.0f)) * (1 - (defReduction / 100.0f))) * (1 + (enemyDamageBonus/ 100.0f) - (inComDMGReduction / 100.0f)) * skillMutiplier;


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
        string modifiedString = newStance.Replace("_", " ");
        stanceText.text = modifiedString;
    }

    [System.Obsolete]
    private void died()
    {
        combatManager.Instance.target = null;
        combatManager.Instance.returnEffectPosition();
        combatManager.Instance.checkWinLose(this.gameObject);
        applyOnDeadEffect();
        if (combatManager.Instance.currentObjTurn == this.gameObject)
            combatManager.Instance.forceEndTurnWitOutTriggerEndTurnEffect();
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
    
    public List<buff> getAllBuffs()
    {
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(activeBuffs);
        allBuff.AddRange(activeDeBuffs);
        allBuff.AddRange(activeUnClearBuffs);
        allBuff.AddRange(activeUnClearDeBuffs);
        return allBuff;
    }

    public void characterUpDateHpBar()
    {
        if (currentHP >= inComMaxHP)
            currentHP = inComMaxHP;
        hpBar.updateHPBar(inComMaxHP, currentHP);
    }

    // Animation and sound
    public void doCharacterAnimationAndSound(GameObject target)
    {
        if (animController != null)
        {
            if (isMelee)
                animController.playMeleeAttackAnim(target.transform);
            else
                animController.playAttackAnim(target.transform);
        }

        if (characterAudio != null)
            characterAudio.playAttackSound();

    }
    public void doCharacterAnimationAndSound()
    {
        if (animController != null)
            animController.playAttackAnim();

        if (characterAudio != null)
            characterAudio.playAttackSound();

    }
    public void doCharacterSound()
    {
        if (characterAudio != null)
            characterAudio.playAttackSound();

    }
    public void spawnHitEffect(GameObject target)
    {
        if (animController != null)
            animController.spawnHitEffect(target.transform);
    }
}
