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
        buff newBuff = new buff("Strengthening bullet", 2, "CRIT_Up");
        newBuff.AddBuff("CRITDMG", 30);
        user.applyActiveBuff(newBuff, false);

        return true;
    }
}
