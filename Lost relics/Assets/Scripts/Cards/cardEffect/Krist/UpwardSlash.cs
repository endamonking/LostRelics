using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardSlash : cardEffect
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
        if (user.currentHP > user.inComMaxHP / 2)
        {
            cardHandler CH = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>();
            CH.currentMana++;
        }
        float haftHP = user.currentHP / 2.0f;
        int dmg = Mathf.FloorToInt(haftHP);
        user.takeTrueDamageIgnoreOnHit(dmg);
        target.takeTrueDamage(dmg);


        return true;
    }
}
