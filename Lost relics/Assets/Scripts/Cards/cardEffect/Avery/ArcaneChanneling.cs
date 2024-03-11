using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneChanneling : cardEffect, IStartturnEffect
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
        string des = "Increase ATK by 30%";
        buff newBuff = new buff("Arcane Channeling", 1, "ATK_Up", des);
        newBuff.AddBuff("ATK", 30);
        string des2 = "2 extra mana next turn";
        buff manaBuff = new buff("Arcane Channeling : Mana", 2, "MANA_Up", this.gameObject.GetComponent<IStartturnEffect>(),des2);
        if (target != combatManager.Instance.currentObjTurn.GetComponent<Character>()) //Not current Character
            manaBuff.duration = 1;

        target.applyActiveBuff(newBuff, true);
        target.applyActiveBuff(manaBuff, true);
        user.doCharacterSound();

        return true;
    }
    public void onStartTurn()
    {
        cardHandler user = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>();
        user.currentMana += 2;

    }

}
