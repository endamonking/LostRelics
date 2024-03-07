using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickReload : cardEffect
{
    [SerializeField]
    private int recoveryAmounts = 3;
    [SerializeField]
    private string buffName = "Lock’n loaded";
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
        buff lockNLoad = user.GetBuffByName(buffName);
        if (lockNLoad != null)
        {
            if (lockNLoad.buffs["STACK"] >= 4)
            {
                //Remana
                GameObject player = combatManager.Instance.currentObjTurn;
                cardHandler CH = player.GetComponent<cardHandler>();
                CH.currentMana = recoveryAmounts + CH.currentMana;
                if (CH.currentMana >= user.maxMana)
                    CH.currentMana = user.maxMana;
                //reduce stack
                lockNLoad.buffs["STACK"] -= 4;
                if (lockNLoad.buffs["STACK"] < 0)
                    lockNLoad.buffs["STACK"] = 0;
            }
        }
        user.doCharacterSound();
        return true;
    }
}
