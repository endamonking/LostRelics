using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pileOfGarbage : cardEffect
{
    int skillMultiplier = 30; //Percent unit
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
        //Add debuff if condition met
        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();
        buff deBuff = new buff("Pile of garbage", 3, "Burn");
        int damageAmount = user.inComATK;
        deBuff.AddBuff("Burn", damageAmount);

        if (playerCardHanlder.cardInHand.Contains(EmmaToken))
        {
            target.applyActiveDeBuff(deBuff, false);
            playerCardHanlder.cardInHand.Remove(EmmaToken);
            //playerCardHanlder.updateCardInhand();
        }

        return true;
    }
}
