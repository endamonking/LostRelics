using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalRedistribution : cardEffect
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
        if (target == combatManager.Instance.currentObjTurn.GetComponent<Character>())
            return false;

        int dmg = Mathf.FloorToInt(user.currentHP * 0.3f);
        user.takeTrueDamageIgnoreOnHit(dmg);
        target.getHeal(dmg, 1);
        user.doCharacterSound();
        return true;
    }
}
