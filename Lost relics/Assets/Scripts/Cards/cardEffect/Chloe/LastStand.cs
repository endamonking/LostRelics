using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStand : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 100;
    [SerializeField]
    private int addSkillMultiplier = 80;
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
        float skillMulti = baseSkillMultiplier / 100.0f;

        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        if (user.myStance == stance.Showdown)
        {
            float addskillMulti = addSkillMultiplier / 100.0f;
            target.takeDamage(userDamage, userAP, userDMGBonus, addskillMulti, userCritRate, userCritDMG);
            //play animation and sound
            user.doCharacterAnimationAndSound(target.gameObject);
        }
        return true;
    }
}
