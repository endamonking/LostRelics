using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssasinResolve : cardEffect, IStartturnEffect
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
        //Add mana buff
        string des2 = "2 extra mana next turn";
        buff manaBuff = new buff("Extra Mana", 2, "MANA_Up", this.gameObject.GetComponent<IStartturnEffect>(), des2);
        user.applyActiveBuff(manaBuff, true);
        
        combatManager.Instance.isForceEndturn = true;
        return true;
    }
    public void onStartTurn()
    {
        cardHandler user = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>();
        user.currentMana += 2;
    }
}
