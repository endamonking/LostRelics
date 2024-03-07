using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingCut : cardEffect
{
    [SerializeField]
    int skillMultiplier = 100; //Percent unit
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
       

        if (user.myStance == stance.Frenzy)
        {
            target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, 200, userCritDMG);
            float lostHP = user.inComMaxHP * 0.2f;
            int heal = Mathf.FloorToInt(lostHP);
            user.getHeal(heal, 1);
        }
        else
            target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);

        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        return true;
    }
}
