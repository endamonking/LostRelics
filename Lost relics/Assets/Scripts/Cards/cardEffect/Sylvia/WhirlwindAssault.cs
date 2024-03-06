using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlwindAssault : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool applyEffect(Character target, Character user)
    {
        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(combatManager.Instance.getAllEnemies());
        int userDamage = user.inComATK;
        int userAP = user.inComArmorPen;
        int userDMGBonus = user.inComDMGBonus;
        int userCritRate = user.inComCritRate;
        int userCritDMG = user.inComCritDMG;
        float skillMulti = baseSkillMultiplier;
        skillMulti = skillMulti / 100.0f;

        //Create debuff
        buff deBuff = new buff("Whirlwind Assault", 2, "Poison");
        int damageAmount = user.inComATK;

        deBuff.AddBuff("Poison", damageAmount);
        foreach (GameObject enemy in enemies)
        {
            Character targetCharac = enemy.GetComponent<Character>();
            targetCharac.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
            //Add debuf 
            if (user.myStance == stance.Phantom_Assault)
            {
                targetCharac.applyActiveDeBuff(deBuff, false);
            }
        }
        return true;
    }
}