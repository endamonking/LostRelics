using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harden : cardEffect
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
        buff newBuff = new buff("Harden", 3, "HP_Up");
        newBuff.AddBuff("MAXHP", 20);
        user.applyActiveBuff(newBuff, false);
        user.characterUpDateHpBar();
        user.doCharacterSound();
        return true;
    }
}
