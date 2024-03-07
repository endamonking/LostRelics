using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurifyingLight : cardEffect
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
        int number = user.activeDeBuffs.Count;
        target.removeActiveDeBuff(number);
        user.doCharacterSound();
        return true;
    }
}
