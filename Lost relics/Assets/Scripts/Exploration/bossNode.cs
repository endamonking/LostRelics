using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossNode : node
{
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();
    public bool isLastNode = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Character>().characterSetup();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnMouseDown()
    {
        if (exploration_sceneManager.Instance.isLerping == true || exploration_sceneManager.Instance.isEvent == true)
            return;

        if (exploration_sceneManager.Instance.playerLocation.nextNode.Contains(this))
        {
            if (isLastNode)
                exploration_sceneManager.Instance.isReachBoss = true;

            exploration_sceneManager.Instance.enemyPool.AddRange(enemies);
            base.OnMouseDown();
            StageCounter.instance.thisIsBossNode();
            StartCoroutine(lerpingNode(1));
        }
    }

    protected override IEnumerator lerpingNode(float duration)
    {
        yield return base.lerpingNode(duration);
        exploration_sceneManager.Instance.loadCombatScene();

    }

}
