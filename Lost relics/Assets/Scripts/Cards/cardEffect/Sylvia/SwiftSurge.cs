using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiftSurge : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 50;
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
        string des = "Increase SPD by 30%";
        buff newBuff = new buff("Swift Surge", 3, "SPD,Up",des);
        newBuff.AddBuff("SPD", 30);
        user.applyActiveBuff(newBuff, false);
        //Dead damage
        if (user.myStance == stance.Blade_Dance)
        {
            int userDamage = user.inComATK;
            int userAP = user.inComArmorPen;
            int userDMGBonus = user.inComDMGBonus;
            int userCritRate = user.inComCritRate;
            int userCritDMG = user.inComCritDMG;
            float skillMulti = baseSkillMultiplier;

            skillMulti = skillMulti / 100.0f;
            GameObject enemyGO = combatManager.Instance.getRandomEnemy();
            Character enemy = enemyGO.GetComponent<Character>();
            enemy.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
            //play animation and sound
            user.doCharacterAnimationAndSound(enemyGO);
        }


        return true;
    }
}
