using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iaido : cardEffect
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
        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();

        user.doCharacterSound();
        for (int i = 0; i < 1; i++)
        {
            playerCardHanlder.drawCard();
        }
        combatManager.Instance.isForceEndturn = true;
        return true;
    }
}
