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
        buff newbuff = new buff("Angel grace", 2, "AP_Up");
        newbuff.AddBuff("AP", 50);
        newbuff.AddBuff("DMGBonus", 30);
        target.applyActiveBuff(newbuff, true);
        return true;
    }
}
