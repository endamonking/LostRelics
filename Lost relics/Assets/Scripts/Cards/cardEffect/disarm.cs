using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disarm : cardEffect
{
    [SerializeField]
    int skillMultiplier = 60; 
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

        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        target.changingStance(stance.Disarm, false);
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);

        return true;
    }
}
