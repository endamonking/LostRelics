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

    public override void applyEffect(Character target, Character user)
    {
        buff stanceDefence = new buff("Stance Defence", 2);
        stanceDefence.AddBuff("DEF", skillMuliplier);

        user.applyActiveBuff(stanceDefence);

    }

}
