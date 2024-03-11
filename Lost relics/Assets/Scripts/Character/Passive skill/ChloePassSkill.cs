using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChloePassSkill : uniquePassSkill, IStartturnEffect, IBeforeUseCard
{
    [SerializeField]
    private string buffName = "Lock地 loaded";
    buff passiveBuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onStartTurn()
    {
        Character Chloe = characterGO.GetComponent<Character>();
        if (Chloe.GetBuffByName(buffName) == null)
        {
            string des = "Lock地 loaded : 0 Stacks";
            buff ChloeBuff = new buff("Lock地 loaded", 99, "SPECIAL", this.gameObject.GetComponent<IBeforeUseCard>(),des);
            ChloeBuff.AddBuff("STACK", 0);
            passiveBuff = ChloeBuff;
            Chloe.applyActiveBuff(ChloeBuff, true);
        }

    }
    public void onBeforeUseCard(Card usingCard)
    {
        passiveBuff.buffs["STACK"]++;
        if (passiveBuff.buffs["STACK"] >= 6)
        {
            Character Chloe = characterGO.GetComponent<Character>();
            cardHandler ch = characterGO.GetComponent<cardHandler>();
            ch.drawCard();
            passiveBuff.buffs["STACK"] = 0;
            Chloe.changingStance(stance.Reloading, false);
        }
        string des = "Lock地 loaded : " + passiveBuff.buffs["STACK"].ToString() + " Stacks";
        passiveBuff.updateDescription(des);
    }
}
