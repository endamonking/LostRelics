using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwingKnife : cardEffect
{
    [SerializeField]
    int skillMultiplier = 100;
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
        float skillMulti = skillMultiplier;
        
        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();
        List<usingCardQ> usingCard = combatManager.Instance.getInUseCard();
        skillMulti = skillMulti / 100.0f;
        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        foreach (usingCardQ obj in usingCard)
        {
            if (obj.card.GetComponent<cardDisplay>().card.effect == this)
            {
                float additiveskillMulti = 20 / 100.0f; ;
                target.takeDamage(userDamage, userAP, userDMGBonus, additiveskillMulti, userCritRate, userCritDMG);
            }
        }
        foreach (Card card in playerCardHanlder.cardInHand)
        {
            if (card.effect == this)
            {
                float additiveskillMulti = 20 / 100.0f; ;
                target.takeDamage(userDamage, userAP, userDMGBonus, additiveskillMulti, userCritRate, userCritDMG);
            }
        }
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        return true;
    }
}
