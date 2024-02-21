using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingInspiration : cardEffect, IEndturnEffect
{
    private Character cardUser;
    private buff currentBuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onEndTurn()
    {
        cardUser.changingStance(stance.Exposed,false);
    }
    public override bool applyEffect(Character target, Character user)
    {
        //this.gameObject.GetComponent<IEndturnEffect>()
        cardUser = user;
        buff deBuff = new buff("Finding inspiration", 1, "SPECIAL", this.gameObject.GetComponent<IEndturnEffect>());
        if (!user.findBuffContainByName(deBuff.buffName))
        {
            user.applyActiveDeBuff(deBuff,true);
            currentBuff = deBuff;
        }
            
        //Draw card
        GameObject player = user.gameObject;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();
        for (int i = 0; i < 2; i++)
        {
            playerCardHanlder.drawCard();
        }
        return true;
    }
}
