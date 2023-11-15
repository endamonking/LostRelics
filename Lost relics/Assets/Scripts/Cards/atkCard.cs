using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class atkCard : cardEffect
{

    public int damageAmount;

    void Start()
    {
        
    }

    public override bool applyEffect(Character target, Character user)
    {
        return true;
    }

}
