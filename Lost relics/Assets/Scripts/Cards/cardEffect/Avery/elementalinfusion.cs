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
        /*buff newBuff = new buff("Elemental Infusion", 3, "SPECIAL");
        buff otherBuff = new buff("Elemental Infusion", 2, "SPECIAL");*/
        buff newBuff;
        buff otherBuff;
        switch (user.myStance)
        {
            case stance.None:
                string des1 = "Increase ATK by 20%";
                newBuff = new buff("Elemental Infusion", 3, "ATK_Up", des1);
                otherBuff = new buff("Elemental Infusion", 2, "ATK_Up", des1);
                newBuff.AddBuff("ATK", 20);
                otherBuff.AddBuff("ATK", 20);
                break;
            case stance.Temporal:
                string des2 = "Increase SPD by 20%";
                newBuff = new buff("Elemental Infusion", 3, "SPD_Up", des2);
                otherBuff = new buff("Elemental Infusion", 2, "SPD_Up", des2);
                newBuff.AddBuff("SPD", 20);
                otherBuff.AddBuff("SPD", 20);
                break;
            case stance.Ethereal:
                string des3 = "Increase Evade by 20%";
                newBuff = new buff("Elemental Infusion", 3, "EVADE_Up", des3);
                otherBuff = new buff("Elemental Infusion", 2, "EVADE_Up", des3);
                newBuff.AddBuff("EVADE", 20);
                otherBuff.AddBuff("EVADE", 20);
                break;
            default:
                string des4 = "Increase DEF by 20%";
                newBuff = new buff("Elemental Infusion", 3, "DEF_Up", des4);
                otherBuff = new buff("Elemental Infusion", 2, "DEF_Up", des4);
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
