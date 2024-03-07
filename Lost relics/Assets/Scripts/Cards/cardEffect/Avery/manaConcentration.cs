using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaConcentration : cardEffect
{
    int skillMultiplier = 50; //Percent unit
    int additionalDMGMultiplier = 10;
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
        //Additional damage
        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();
        int currentMana = playerCardHanlder.currentMana;
        float additionalDMG = (additionalDMGMultiplier * currentMana) / 100.0f;
        target.takeDamage(userDamage, userAP, userDMGBonus, additionalDMG, userCritRate, userCritDMG);

        return true;
    }
}
