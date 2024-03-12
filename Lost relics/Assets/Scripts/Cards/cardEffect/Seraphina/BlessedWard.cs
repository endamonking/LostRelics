using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessedWard : cardEffect
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
        string des = "Increase Damage reduction by 20%";
        buff newBuff = new buff("Protective ward", 3, "DEF_Up", des);
        newBuff.AddBuff("DMGReduction", 20);
        user.applyActiveBuff(newBuff, true);
        foreach (GameObject player in players)
        {
            if (player == combatManager.Instance.currentObjTurn) //Not current Character
                continue;
            buff otherBuff = new buff("Protective ward", 2, "DEF_Up", des);
            otherBuff.AddBuff("DMGReduction", 20);
            Character targetBuff = player.GetComponent<Character>();
            targetBuff.applyActiveBuff(otherBuff, true);
        }
        user.doCharacterAnimationAndSound();
        return true;
    }
}
