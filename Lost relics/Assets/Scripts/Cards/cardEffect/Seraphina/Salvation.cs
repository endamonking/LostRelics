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
        buff salvation = new buff("Salvation", 2, "ATK_Up");
        salvation.AddBuff("ATK", 20);
        target.applyActiveBuff(salvation, false);
        return true;
    }
}
