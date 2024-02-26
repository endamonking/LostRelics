using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KristPassSkill : uniquePassSkill, IStartturnEffect
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onStartTurn()
    {
        Character chara = characterGO.GetComponent<Character>();
        if (chara.currentHP <= chara.maxHP * 0.5f)
        {
            //Change stance
            chara.changingStance(stance.Frenzy, false);
            //Draw
            cardHandler playerCardHand = characterGO.GetComponent<cardHandler>();
            playerCardHand.drawCard();

        }
    }
}
