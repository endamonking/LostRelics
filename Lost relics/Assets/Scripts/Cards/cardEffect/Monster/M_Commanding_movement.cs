using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Commanding_movement : cardEffect
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
        string des2 = "Increase SPD by 20%";
        buff buff;
        buff otherBuff;
        //self
        buff = new buff("Commanding movement", 3, "SPD_Up", des2);
        buff.AddBuff("SPD", 20);
        user.applyActiveBuff(buff, false);
        //Other
        List<GameObject> allies = new List<GameObject>();
        allies.AddRange(combatManager.Instance.getAllEnemies());
        otherBuff = new buff("Commanding movement", 2, "SPD_Up", des2);
        otherBuff.AddBuff("SPD", 20);

        foreach (GameObject remainingplayer in allies)
        {
            if (remainingplayer == combatManager.Instance.currentObjTurn) //Not current Character
                continue;
            Character pCharacter = remainingplayer.GetComponent<Character>();
            pCharacter.applyActiveBuff(otherBuff, false);
        }

        return true;
    }
}
