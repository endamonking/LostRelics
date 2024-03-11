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
        string des = "Receive true damage at the start of the turn";
        buff deBuff = new buff("Poison vial", 3, "Poison", des);
        int damageAmount = user.inComATK;

        deBuff.AddBuff("Poison", damageAmount);

        target.applyActiveDeBuff(deBuff,false);
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        return true;
    }
}
