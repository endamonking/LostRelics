using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowStep : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 70;
    [SerializeField]
    private Card tokenCard;
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
        cardHandler CH = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>();
        int userDamage = user.inComATK;
        int userAP = user.inComArmorPen;
        int userDMGBonus = user.inComDMGBonus;
        int userCritRate = user.inComCritRate;
        int userCritDMG = user.inComCritDMG;
        float skillMulti = baseSkillMultiplier;

        skillMulti = skillMulti / 100.0f;
        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        if (user.myStance == stance.Phantom_Assault)
        {
            buff debuff = new buff("Shadow Step", 2, "SPD_Down");
            debuff.AddBuff("SPD", -10);
            user.applyActiveDeBuff(debuff, false);
            CH.currentMana += 2;
        }
        if (user.inComSPD >= 50)
        {
            CH.createCardToHand(tokenCard);
            CH.updateCardInhand();
        }
        return true;
    }
}
