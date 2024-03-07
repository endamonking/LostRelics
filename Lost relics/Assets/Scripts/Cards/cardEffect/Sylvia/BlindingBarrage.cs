using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindingBarrage : cardEffect
{
    [SerializeField]
    int skillMultiplier = 60; //Percent unit
    [SerializeField]
    int additionalDMG = 10; //Flat
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
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        //Addition damage
        int count = (user.inComSPD - 30) / 10;
        for (int i =0; i < count; i++)
        {
            target.takeTrueDamage(additionalDMG);
            //play animation and sound
            user.doCharacterAnimationAndSound(target.gameObject);
        }


        return true;
    }
}
