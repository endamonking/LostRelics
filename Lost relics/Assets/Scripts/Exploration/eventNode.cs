using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventNode : node
{
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
            Debug.Log("EventNode");
            base.OnMouseDown();
            StartCoroutine(lerpingNode(2));
        }
    }


}
