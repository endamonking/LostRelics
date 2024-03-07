using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALine : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 60, flowSkillMultiplier = 80;
    [SerializeField]
    private Card EmmaToken;
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
        float skillMulti = user.myStance == stance.Flow ? flowSkillMultiplier : baseSkillMultiplier;

        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();
        List<usingCardQ> usingCard = combatManager.Instance.getInUseCard();

        foreach (usingCardQ obj in usingCard)
        {
            if (obj.card.GetComponent<cardDisplay>().card.effect == EmmaToken.effect)
            {
                float additiveskillMulti = skillMulti / 100.0f; ;
                target.takeDamage(userDamage, userAP, userDMGBonus, additiveskillMulti, userCritRate, userCritDMG);
                //play animation and sound
                user.doCharacterAnimationAndSound(target.gameObject);
            }
        }
        foreach (Card card in playerCardHanlder.cardInHand)
        {
            if (card.effect == EmmaToken.effect)
            {
                float additiveskillMulti = skillMulti / 100.0f; ;
                target.takeDamage(userDamage, userAP, userDMGBonus, additiveskillMulti, userCritRate, userCritDMG);
                //play animation and sound
                user.doCharacterAnimationAndSound(target.gameObject);
            }
        }

        return true;
    }
}
