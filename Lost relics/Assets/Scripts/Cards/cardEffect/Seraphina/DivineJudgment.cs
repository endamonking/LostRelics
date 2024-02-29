using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineJudgment : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 70;
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
        int userDamage = user.inComHeal;
        int userAP = user.inComArmorPen;
        int userDMGBonus = user.inComDMGBonus;
        int userCritRate = user.inComCritRate;
        int userCritDMG = user.inComCritDMG;
        float skillMulti = baseSkillMultiplier;
        skillMulti = skillMulti / 100.0f;
        if (user.myStance == stance.Purification)
            target.takeDamage(userDamage, 100, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        else
            target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        return true;
    }
}
