using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stanceDefence : cardEffect
{
    int skillMuliplier = 20;
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
        buff stanceDefence = new buff("Stance Defence", 2,"DEF_Up");
        stanceDefence.AddBuff("DEF", skillMuliplier);

        user.applyActiveBuff(stanceDefence);
        return true;
    }

}
