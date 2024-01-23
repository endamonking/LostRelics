using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killEnemyQuest : quest
{
    [Header("Kill type")]
    public string targetName;
    public int targetCounts;
    public int killCounts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fullfillCondition(string enemyName)
    {
        if (isComplete)
            return;

        if (enemyName == targetName)
        {
            killCounts++;
        }

        if (killCounts >= targetCounts)
            isComplete = true;

    }
}
