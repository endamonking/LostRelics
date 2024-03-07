using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineIntervention : cardEffect
{
    [SerializeField]
    int skillMuliplier = 30;
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
        buff newBuff = new buff("Divine Intervention", 3, "DEF_Up");
        newBuff.AddBuff("DEF", skillMuliplier);
        user.applyActiveBuff(newBuff, false);
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        foreach (GameObject player in players)
        {
            if (player == combatManager.Instance.currentObjTurn) //Not current Character
                continue;
            Character ally = player.GetComponent<Character>();
            buff otherBuff = new buff("Divine Intervention", 2, "DEF_Up");
            otherBuff.AddBuff("DEF", skillMuliplier);
            ally.applyActiveBuff(otherBuff, false);
        }
        user.doCharacterSound();
        return true;
    }
}
