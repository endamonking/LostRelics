using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementalinfusion : cardEffect
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
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        buff newBuff = new buff("Elemental Infusion", 3, "SPECIAL");
        buff otherBuff = new buff("Elemental Infusion", 2, "SPECIAL");
        switch (user.myStance)
        {
            case stance.None:
                newBuff.AddBuff("ATK", 20);
                otherBuff.AddBuff("ATK", 20);
                break;
            case stance.Temporal:
                newBuff.AddBuff("SPD", 20);
                otherBuff.AddBuff("SPD", 20);
                break;
            case stance.Ethereal:
                newBuff.AddBuff("EVADE", 20);
                otherBuff.AddBuff("EVADE", 20);
                break;
            default:
                newBuff.AddBuff("DEF", 10);
                otherBuff.AddBuff("DEF", 10);
                break;
        }
        user.applyActiveBuff(newBuff, false);
        foreach (GameObject player in players)
        {
            if (player == combatManager.Instance.currentObjTurn) //Not current Character
                continue;
            Character cha = player.GetComponent<Character>();
            cha.applyActiveBuff(otherBuff, false);
        }
        user.doCharacterSound();
        return true;
    }
}
