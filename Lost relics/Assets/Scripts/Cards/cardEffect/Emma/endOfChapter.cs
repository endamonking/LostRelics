using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endOfChapter : cardEffect
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
        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler CH = player.GetComponent<cardHandler>();
        float number = CH.cardDrawedThisTurn / 2.0f;
        int manaRecover = Mathf.FloorToInt(number);
        CH.currentMana = manaRecover + CH.currentMana;
        if (CH.currentMana >= user.maxMana)
            CH.currentMana = user.maxMana;
        // Draw
        if (user.myStance == stance.Flow)
        {
            CH.drawCard();
            CH.drawCard();
        }
        user.doCharacterSound();
        return true;
    }
}
