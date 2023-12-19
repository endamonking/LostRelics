using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipp : nodeEfffect
{
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
        base.closeEvenCanvas();
    }
}
