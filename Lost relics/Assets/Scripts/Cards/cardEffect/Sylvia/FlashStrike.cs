using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashStrike : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 150;
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
        int userDamage = user.inComATK;
        int userAP = user.inComArmorPen;
        int userDMGBonus = user.inComDMGBonus;
        int userCritRate = user.inComCritRate;
        int userCritDMG = user.inComCritDMG;
        float skillMulti = baseSkillMultiplier;

        skillMulti = skillMulti / 100.0f;
        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        if (user.myStance == stance.Blade_Dance)
        {
            buff newbuff = new buff("Flash Strike", 3, "EVADE_Up");
            newbuff.AddBuff("EVADE", 20);
            user.applyActiveBuff(newbuff, false);
        }
        return true;
    }
}
