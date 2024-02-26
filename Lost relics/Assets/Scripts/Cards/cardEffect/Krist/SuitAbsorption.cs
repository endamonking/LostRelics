using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitAbsorption : cardEffect
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
        //Add def down debuff
        buff deBuff = new buff("Suit Absorption", 2, "DEF_Down");
        deBuff.AddBuff("DEF", 20);
        user.applyActiveDeBuff(deBuff, false);
        //Heal
        int lostHP = user.inComMaxHP - user.currentHP;
        user.getHeal(lostHP / 2, 1);

        return true;
    }
}
