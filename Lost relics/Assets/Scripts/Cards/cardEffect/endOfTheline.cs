using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endOfTheline : cardEffect
{

    int skillMultiplier = 170; //Percent unit
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void applyEffect(Character target, Character user)
    {
        int userDamage = user.inComATK;
        int userAP = user.inComArmorPen;
        int userDMGBonus = user.inComDMGBonus;
        float skillMulti = 0;

        if (user.currentHP >= (user.inComMaxHP * 35 / 100.0f))
        {
            skillMulti = skillMultiplier / 100.0f;

        }
        else
        {
            skillMulti = (skillMultiplier + 50) / 100.0f;
        }

        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti);

    }

}
