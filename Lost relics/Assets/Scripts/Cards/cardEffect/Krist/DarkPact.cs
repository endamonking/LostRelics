using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkPact : cardEffect
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
        if (user.currentHP > user.inComMaxHP * 0.2f)
        {
            int dmg = Mathf.FloorToInt(user.inComMaxHP * 0.2f);
            user.takeTrueDamageIgnoreOnHit(dmg);

            buff Darkpact = new buff("Dark pact", 2, "ATK_Up");
            Darkpact.AddBuff("DEF", 50);
            Darkpact.AddBuff("ATK", 50);
            Darkpact.AddBuff("SPD", 20);

            user.applyActiveBuff(Darkpact, false);
            user.doCharacterSound();
            return true;
        }
        else
            return false;
    }
}
