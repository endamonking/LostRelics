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
        List<GameObject> players = combatManager.Instance.getAllPlayer();
        buff newBuff = new buff("Elemental Infusion", 2, "SPECIAL");
        switch (user.myStance)
        {
            case stance.None:
                newBuff.AddBuff("ATK", 20);
                break;
            case stance.Temporal:
                newBuff.AddBuff("SPD", 20);
                break;
            case stance.Ethereal:
                newBuff.AddBuff("EVADE", 20);
                break;
            default:
                newBuff.AddBuff("DEF", 10);
                break;
        }
        foreach (GameObject player in players)
        {
            Character cha = player.GetComponent<Character>();
            cha.applyActiveBuff(newBuff, false);
        }
        return true;
    }
}
