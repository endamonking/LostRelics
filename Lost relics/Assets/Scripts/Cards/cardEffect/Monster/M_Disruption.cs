using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Disruption : cardEffect
{
    [SerializeField]
    private int skillMultiplier = 30;
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
        float targetskill = skillMultiplier / 100.0f;
        target.takeDamage(userDamage, userAP, userDMGBonus, targetskill, userCritRate, userCritDMG);
        //Changing stance
        //if it negative do nothing and positive change to disarm
        //Target negative status bcoz it less than positive
        switch (target.myStance)
        {
            case stance.Panic:
                break;
            case stance.Disarm:
                break;
            case stance.Exhausted:
                break;
            case stance.Exposed:
                break;
            default:
                target.changingStance(stance.Disarm, false);
                break;
        }

        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        return true;
    }
}
