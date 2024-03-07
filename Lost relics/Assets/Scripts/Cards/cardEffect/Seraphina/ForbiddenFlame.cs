using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbiddenFlame : cardEffect
{
    [SerializeField]
    private int damage = 20;
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
        target.takeTrueDamage(damage);
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        return true;
    }
}
