using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Spilling : cardEffect
{
    [SerializeField]
    int skillMultiplier = 30, burnMultiplier = 50; //Percent unit
    
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
        string des = "Receive true damage at the start of the turn";
        buff deBuff = new buff("Spilling", 2, "Burn", des);
        int damageAmount = Mathf.FloorToInt(user.inComATK * (burnMultiplier / 100.0f));

        deBuff.AddBuff("Burn", damageAmount);

        target.applyActiveDeBuff(deBuff, false);
        return true;
    }
}
