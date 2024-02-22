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
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        buff newBuff = new buff("Arcane Channeling", 1, "ATK_Up");
        newBuff.AddBuff("ATK", 30);
        buff manaBuff = new buff("Arcane Channeling : Mana", 2, "MANA_Up", this.gameObject.GetComponent<IStartturnEffect>());
        if (target != combatManager.Instance.currentObjTurn.GetComponent<Character>()) //Not current Character
            manaBuff.duration = 1;

        target.applyActiveBuff(newBuff, true);
        target.applyActiveBuff(manaBuff, true);

        return true;
    }
    public void onStartTurn()
    {
        cardHandler user = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>();
        user.currentMana += 2;

    }

}
