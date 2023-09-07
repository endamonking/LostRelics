using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterNode : node
{
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnMouseDown()
    {
        if (exploration_sceneManager.Instance.playerLocation.nextNode.Contains(this))
        {
            exploration_sceneManager.Instance.enemyPool.AddRange(enemies);
            base.OnMouseDown();
            exploration_sceneManager.Instance.loadCombatScene();
        }
    }
}