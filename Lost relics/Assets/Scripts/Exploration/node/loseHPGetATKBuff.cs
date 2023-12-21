using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseHPGetATKBuff : nodeEfffect
{
    [SerializeField]
    private int ATKAmount = 40, duration = 3, loseHP = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void doEffect()
    {

        List<GameObject> playersCha = exploration_sceneManager.Instance.playerPool;

        foreach (GameObject character in playersCha)
        {
            Character pCha = character.GetComponent<Character>();
            int amount = pCha.inComMaxHP * loseHP / 100;
            pCha.currentHP = pCha.currentHP - amount;
            if (pCha.currentHP <= 0)
                pCha.currentHP = 1;
        }

        buff ATKBuff = new buff("Attack", duration);
        ATKBuff.AddBuff("ATK", ATKAmount);
        exploration_sceneManager.Instance.applyExploBuff(ATKBuff,1);
        base.closeEvenCanvas();
    }
}
