using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelGrace : cardEffect
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
        string des = "Increase AP by 50%, and Damage bonus by 30%";
        buff newbuff = new buff("Angel grace", 2, "AP_Up", des);
        newbuff.AddBuff("AP", 50);
        newbuff.AddBuff("DMGBonus", 30);
        target.applyActiveBuff(newbuff, true);
        user.doCharacterAnimationAndSound();
        return true;
    }
}
