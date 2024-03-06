using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScabbardKnock : cardEffect
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

        //create debuff
        buff deBuff = new buff("Scabbard knock", 3, "HEAL_Down");
        deBuff.AddBuff("HEALReduction", 30);

        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        target.applyActiveDeBuff(deBuff, false);
        return true;
    }
}