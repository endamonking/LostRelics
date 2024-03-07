using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stance_Preparation : cardEffect
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
        combatManager.Instance.isForceEndturn = true;
        user.doCharacterSound();
        return true;
    }
}
