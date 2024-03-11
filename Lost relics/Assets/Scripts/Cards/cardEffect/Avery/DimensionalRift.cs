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
        string des = "Can't action";
        buff deBuff = new buff("Dimensional Rift", 1, "Stun", des);
        deBuff.AddBuff("Stun", 1);
        target.applyActiveDeBuff(deBuff, false);
        //Add debuf Resis
        if (user.myStance == stance.Temporal)
        {
            string des1 = "Decrease RES by 30%";
            buff resisDebuf = new buff("Dimensional Rift", 2, "RES_Down", des1);
            resisDebuf.AddBuff("RESISTANCE", -30);
            target.applyActiveDeBuff(resisDebuf, false);
        }
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);

        return true;
    }
}
