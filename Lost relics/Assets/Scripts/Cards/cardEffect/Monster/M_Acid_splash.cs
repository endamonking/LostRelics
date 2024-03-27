using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Acid_splash : cardEffect
{
    [SerializeField]
    int skillMultiplier = 80; //Percent unit
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
        string des = "Decrease DEF by 25%";
        buff deBuff = new buff("Acid splash", 2, "DEF_Down", des);
        deBuff.AddBuff("DEV", -25);

        target.applyActiveDeBuff(deBuff, false);
        return true;
    }
}
