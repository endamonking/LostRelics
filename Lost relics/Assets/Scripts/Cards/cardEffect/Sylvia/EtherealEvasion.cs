using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtherealEvasion : cardEffect
{
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
        //Add buff
        string des = "Increase Evade by 50%";
        buff newBuff = new buff("Ethereal Evasion", 2, "EVADE_Up", des);
        newBuff.AddBuff("EVADE", 60);
        user.applyActiveBuff(newBuff, false);
        //Draw
        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();

        if (playerCardHanlder.cardInHand.Count <= 2)
        {
            playerCardHanlder.drawCard();
        }
        user.doCharacterSound();
        return true;
    }
}
