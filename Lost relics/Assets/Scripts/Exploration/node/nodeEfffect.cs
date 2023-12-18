using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class nodeEfffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void doEffect();

    public void closeEvenCanvas()
    {
        exploration_sceneManager.Instance.turnOffEvenCanvas();
    }

}
