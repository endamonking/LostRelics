using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThouShallHalt : cardEffect
{
    [SerializeField]
    int skillMultiplier = 50;
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
        float skillMulti = skillMultiplier / 100.0f;

        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);

        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();
        int i = 0;
        
        foreach (Card card in playerCardHanlder.cardInHand)
        {
            if (card == EmmaToken)
                i++;
        }

        if (i >= 2)
        {
            for (int a = 0; a < 2; a++)
            {
                playerCardHanlder.cardInHand.Remove(EmmaToken);
            }
            target.changingStance(stance.Exhausted,false);
        }
        else
            target.changingStance(stance.Disarm,false);

        return true;
    }
}
