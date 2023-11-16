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
        foreach (usingCardQ obj in usingCard)
        {
            if (obj.card.GetComponent<cardDisplay>().card.effect == this)
            {
                skillMulti = skillMulti + 20;
            }
        }
        foreach (Card card in playerCardHanlder.cardInHand)
        {
            if (card.effect == this)
            {
                skillMulti = skillMulti + 20;
            }
        }
        skillMulti = skillMulti / 100.0f;
        Debug.Log(skillMulti);
        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        return true;
    }
}
