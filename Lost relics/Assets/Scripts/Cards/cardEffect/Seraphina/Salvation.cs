using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salvation : cardEffect
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
        string des = "Increase ATK by 20%";
        buff salvation = new buff("Salvation", 2, "ATK_Up", des);
        salvation.AddBuff("ATK", 20);
        target.applyActiveBuff(salvation, false);
        user.doCharacterAnimationAndSound();
        return true;
    }
}
