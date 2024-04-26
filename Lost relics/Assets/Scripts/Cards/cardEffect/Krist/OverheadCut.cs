using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadCut : cardEffect
{
    [SerializeField]
    int skillMultiplier = 100; //Percent unit
    [SerializeField]
    int bonusSkillMultiplier = 150; //Percent unit
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
        float skillMulti = skillMultiplier / 100.0f;

        if (user.myStance == stance.Frenzy && user.currentHP > user.inComMaxHP * 0.1f)
        {
            int dmg = Mathf.FloorToInt(user.inComMaxHP * 0.1f);
            user.takeTrueDamageIgnoreOnHit(dmg);
            skillMulti = bonusSkillMultiplier / 100.0f;
            target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        }
        else
            target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        return true;
    }
}
