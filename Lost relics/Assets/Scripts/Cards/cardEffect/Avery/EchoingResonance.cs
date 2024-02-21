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
        buff newBuff = new buff("Echoing Resonance", 1, "SPECAIL", this.gameObject.GetComponent<IBeforeUseCard>());
        buff APBuff = new buff("Echoing Resonance", 2, "AP_Up");
        APBuff.AddBuff("AP", 50);
        if (!user.findBuffContainByName(newBuff.buffName))
        {
            user.applyActiveBuff(newBuff, true);
            user.applyActiveBuff(APBuff, true);
            currentBuff = newBuff;
        }
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
