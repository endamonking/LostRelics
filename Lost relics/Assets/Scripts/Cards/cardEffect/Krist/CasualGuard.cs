using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasualGuard : cardEffect
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
        buff newBuff = new buff("Casual guard", 2, "DEF_Up");
        newBuff.AddBuff("DEF", 30);
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        foreach (GameObject player in players)
        {
            if (player == combatManager.Instance.currentObjTurn)
                continue;

            Character playerTarget = player.GetComponent<Character>();
            playerTarget.applyActiveBuff(newBuff, false);
        }
        user.doCharacterSound();


        return true;
    }
}
