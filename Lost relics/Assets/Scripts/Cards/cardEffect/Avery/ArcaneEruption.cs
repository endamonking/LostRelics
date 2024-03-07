using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneEruption : cardEffect, IEndturnEffect
{
    [SerializeField]
    private int skillMultiplier = 80; //Percent unit
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
        //Add debuff
        if (user.myStance == stance.Ethereal)
        {
            buff deBuff = new buff("Restraint", 1, "SPECIAL", this.gameObject.GetComponent<IEndturnEffect>());
            deBuff.AddBuff("Restraint", 1);
            deBuff.AddBuff("ATK", -20);
            target.applyActiveDeBuff(deBuff, false);
        }
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        return true;
    }
    public void onEndTurn()
    {
        Character chara = combatManager.Instance.currentObjTurn.GetComponent<Character>();
        chara.changingStance(stance.Rage, true);
    }
}
