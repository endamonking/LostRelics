using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicCure : cardEffect
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
        int number = 1;
        target.removeActiveDeBuff(number);
        return true;
    }
}
