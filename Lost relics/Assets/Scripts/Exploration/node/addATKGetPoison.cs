using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addATKGetPoison : nodeEfffect
{
    [SerializeField]
    private int ATKAmount = 5, poisonPercenATK = 5;
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
            pCha.baseATK += ATKAmount;
        }
        //Add debuff
        string des = "Receive true damage at the start of the turn";
        buff deBuff = new buff("Poison", 99, "Poison", des);
        int damageAmount = poisonPercenATK;

        deBuff.AddBuff("PoisonMaxHP", damageAmount);
        exploration_sceneManager.Instance.applyExploDeBuff(deBuff,1);
        base.closeEvenCanvas();
    }
}
