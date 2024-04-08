using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacredGround : cardEffect, IStartturnEffect
{
    [SerializeField]
    private int mutiplier = 30;
    private int healPower = 0;
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
        string des = "At the start of turn, regenerate HP";
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        buff newBuff = new buff("Sacred Ground", 4, "Special", this.gameObject.GetComponent<IStartturnEffect>(), des);
        healPower = user.inComHeal;
        user.applyActiveBuff(newBuff, true);
        foreach (GameObject player in players)
        {
            if (player == combatManager.Instance.currentObjTurn) //Not current Character
                continue;
            buff otherBuff = new buff("Sacred Ground", 3, "Special", this.gameObject.GetComponent<IStartturnEffect>(), des);
            Character targetBuff = player.GetComponent<Character>();
            targetBuff.applyActiveBuff(otherBuff, true);
        }
        user.doCharacterAnimationAndSound();
        return true;
    }
    public void onStartTurn()
    {
        Character player = combatManager.Instance.currentObjTurn.GetComponent<Character>();
        player.getHeal(healPower, mutiplier / 100.0f);

    }
}
