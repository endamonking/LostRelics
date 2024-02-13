using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sweepKick : cardEffect
{
    [SerializeField]
    int skillMultiplier = 80;
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
        //Apply debuf
        buff deBuff = new buff("Sweep Kick", 2, "SPD_Down");
        deBuff.AddBuff("SPD", -10);

        target.applyActiveDeBuff(deBuff,false);
        return true;
    }
}
