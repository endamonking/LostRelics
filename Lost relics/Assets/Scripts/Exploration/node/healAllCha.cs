using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healAllCha : nodeEfffect
{
    [SerializeField]
    private int amount = 15;

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

        foreach(GameObject character in playersCha)
        {
            Character pCha = character.GetComponent<Character>();
            pCha.currentHP = pCha.currentHP + amount;
            if (pCha.currentHP >= pCha.inComMaxHP)
                pCha.currentHP = pCha.inComMaxHP;
        }

        base.closeEvenCanvas();
    }

}
