using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicAttack : cardEffect
{
    int skillMultiplier = 120; //Percent unit

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void applyEffect(Character target, Character user)
    {
        int userDamage = user.inComATK;
        int userAP = user.inComArmorPen;
        int userDMGBonus = user.inComDMGBonus;
        float skillMulti = skillMultiplier / 100.0f;

        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti);
    }
}
