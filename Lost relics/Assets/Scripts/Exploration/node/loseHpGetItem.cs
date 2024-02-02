using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseHpGetItem : nodeEfffect
{
    [SerializeField]
    private int loseHP = 35, maxGetItem = 1;
    public List<GameObject> itemSpawnList = new List<GameObject>();
    
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
        List<GameObject> itemsSpawned = new List<GameObject>();

        foreach (GameObject character in playersCha)
        {
            Character pCha = character.GetComponent<Character>();
            int amount = pCha.inComMaxHP * loseHP / 100;
            pCha.currentHP = pCha.currentHP - amount;
            if (pCha.currentHP <= 0)
                pCha.currentHP = 1;
        }
        for (int i =0; i < maxGetItem; i++)
        {
            int randNum = Random.Range(0, itemSpawnList.Count);
            GameObject item = Instantiate(itemSpawnList[randNum], new Vector3(0,0,0), transform.rotation);
            itemsSpawned.Add(item);
            inventoryManager.Instance.addItem(item);
        }
        base.closeEvenCanvas();
        exploration_sceneManager.Instance.showingGetItem(itemsSpawned);
    }
}
