using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWound : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 30;
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
        //Add card
        if (target.currentHP == target.inComMaxHP)
        {
            CH.createCardToHand(tokenCard);
            CH.updateCardInhand();
        }
        //Deal damage
        skillMulti = skillMulti / 100.0f;
        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        return true;
    }
}
