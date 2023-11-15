using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonVial : cardEffect
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
        buff deBuff = new buff("Poison vial", 3);
        int damageAmount = user.inComATK;

        deBuff.AddBuff("Poison", damageAmount);

        target.applyActiveDeBuff(deBuff);
        return true;
    }
}
