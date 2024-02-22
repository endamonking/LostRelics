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
        buff ancientWard = new buff("Ancient Ward", 2, "RES_Up");
        ancientWard.AddBuff("RESISTANCE", skillMuliplier);
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        foreach (GameObject player in players)
        {
            Character chara = player.GetComponent<Character>();
            chara.applyActiveBuff(ancientWard, false);

        }
        return true;
    }
}
