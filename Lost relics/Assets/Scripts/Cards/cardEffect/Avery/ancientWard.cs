using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ancientWard : cardEffect
{
    int skillMuliplier = 20;
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
        buff ancientWard = new buff("Ancient Ward", 3, "RES_Up");
        ancientWard.AddBuff("RESISTANCE", skillMuliplier);
        user.applyActiveBuff(ancientWard, false);
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        foreach (GameObject player in players)
        {
            if (player == combatManager.Instance.currentObjTurn) //Not current Character
                continue;
            Character chara = player.GetComponent<Character>();
            buff otherAncientWard = new buff("Ancient Ward", 2, "RES_Up");
            otherAncientWard.AddBuff("RESISTANCE", skillMuliplier);
            chara.applyActiveBuff(otherAncientWard, false);

        }
        user.doCharacterSound();
        return true;
    }
}
