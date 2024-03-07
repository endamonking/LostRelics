using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_aim : cardEffect
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
        playerCardHanlder.drawCard();
        user.doCharacterSound();
        return true;

    }
}
