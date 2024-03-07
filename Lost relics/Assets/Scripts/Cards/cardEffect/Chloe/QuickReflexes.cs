using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickReflexes : cardEffect
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
        //Add buff
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        buff newBuff = new buff("Quick Reflexes", 2, "EVADE_Up");
        newBuff.AddBuff("EVADE", 20);
        user.applyActiveBuff(newBuff, true);
        foreach (GameObject player in players)
        {
            if (player == combatManager.Instance.currentObjTurn) //Not current Character
                continue;
            buff otherBuff = new buff("Quick Reflexes", 1, "DEF_Up");
            otherBuff.AddBuff("EVADE", 20);
            Character targetBuff = player.GetComponent<Character>();
            targetBuff.applyActiveBuff(otherBuff, true);
        }
        user.doCharacterSound();
        return true;
    }
}
