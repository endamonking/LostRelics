using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class atkCard : cardEffect
{

    public int damageAmount;

    void Start()
    {
        
    }

    public override void applyEffect(Character character)
    {
        character.takeDamage(damageAmount);
    }

}
