using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stanceDefence : cardEffect
{
    [SerializeField]
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
        string des = "Increase DEF by 20%";
        buff stanceDefence = new buff("Stance Defence", 2,"DEF_Up", des);
        stanceDefence.AddBuff("DEF", skillMuliplier);

        user.applyActiveBuff(stanceDefence,false);
        user.doCharacterSound();
        return true;
    }

}
