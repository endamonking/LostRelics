using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalSurge : cardEffect
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
        //Add buff
        string des1 = "Increase Critical damage by 30%";
        buff newBuff = new buff("Strengthening bullet", 2, "CRIT_Up", des1);
        newBuff.AddBuff("CRITDMG", 30);
        user.applyActiveBuff(newBuff, false);
        user.doCharacterSound();
        return true;
    }
}
