using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidRetaliation : cardEffect
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
        user.doCharacterSound();
        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();

        for (int i = 0; i < 2; i++)
        {
            playerCardHanlder.drawCard();
        }
        //Add buf
        string des = "Increase ATK by 20%";
        buff newbuff = new buff("Rapid Retaliation", 2, "ATK_Up", des);
        newbuff.AddBuff("ATK", 20);
        user.applyActiveBuff(newbuff, false);

        combatManager.Instance.isForceEndturn = true;
        return true;
    }
}
