using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashStep : cardEffect
{
    [SerializeField]
    int skillMultiplier = 30; //Percent unit
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

        if (target.inComSPD < user.inComSPD)
        {
            target.takeDamage(userDamage, 100, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        }
        else
            target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        return true;
    }
}
