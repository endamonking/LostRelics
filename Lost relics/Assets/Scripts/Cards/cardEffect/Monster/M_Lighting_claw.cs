using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Lighting_claw : cardEffect
{
    [SerializeField]
    int skillMultiplier = 60; //Percent unit
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
        // Additional dmg
        int addDMG = Mathf.FloorToInt(user.inComSPD * 0.2f);
        target.takeDamage(addDMG, userAP, userDMGBonus, 1, userCritRate, userCritDMG);
        return true;
    }
}
