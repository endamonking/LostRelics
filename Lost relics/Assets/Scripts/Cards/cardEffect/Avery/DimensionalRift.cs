using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionalRift : cardEffect
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
        //Add stun
        buff deBuff = new buff("Dimensional Rift", 1, "Stun");
        deBuff.AddBuff("Stun", 1);
        target.applyActiveDeBuff(deBuff, false);
        //Add debuf Resis
        if (user.myStance == stance.Temporal)
        {
            buff resisDebuf = new buff("Dimensional Rift", 2, "RES_Down");
            resisDebuf.AddBuff("RESISTANCE", 30);
            target.applyActiveDeBuff(resisDebuf, false);
        }
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);

        return true;
    }
}
