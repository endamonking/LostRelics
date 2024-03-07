using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineGuidance : cardEffect
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
        buff newBuff = new buff("Divine Guidance", 3, "EVADE_Up");
        newBuff.AddBuff("EVADE", 25);
        newBuff.AddBuff("CRITRate", 30);
        user.applyActiveBuff(newBuff, true);
        foreach (GameObject player in players)
        {
            if (player == combatManager.Instance.currentObjTurn) //Not current Character
                continue;
            Character targetBuff = player.GetComponent<Character>();
            buff other = new buff("Divine Guidance", 2, "EVADE_Up");
            other.AddBuff("EVADE", 25);
            other.AddBuff("CRITRate", 30);
            targetBuff.applyActiveBuff(other, true);
        }
        user.doCharacterSound();
        return true;
    }
}
