using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoingResonance : cardEffect, IBeforeUseCard
{
    private buff currentBuff;
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
        //Buff
        string des2 = "Refund the next mana cost of next card used";
        buff newBuff = new buff("Echoing Resonance", 1, "SPECAIL", this.gameObject.GetComponent<IBeforeUseCard>(),des2);
        string des = "Increase AP by 50%";
        buff APBuff = new buff("Echoing Resonance: AP", 2, "ATK_Up", des);
        APBuff.AddBuff("AP", 50);
        user.applyActiveBuff(newBuff, true);
        user.applyActiveBuff(APBuff, true);
        user.doCharacterSound();
        return true;
    }
    
    public void onBeforeUseCard(Card usingCard)
    {
        cardHandler CH = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>();
        Character chara = combatManager.Instance.currentObjTurn.GetComponent<Character>();
        CH.currentMana += usingCard.cardCost;
        chara.removeBuff(currentBuff);
    }
}
