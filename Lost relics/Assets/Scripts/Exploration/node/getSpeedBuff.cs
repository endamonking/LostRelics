using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getSpeedBuff : nodeEfffect
{
    [SerializeField]
    private int speedAmount = 20, duration = 2;

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
        buff spdBuff = new buff("Speed", duration);
        spdBuff.AddBuff("SPD", speedAmount);

        exploration_sceneManager.Instance.applyExploBuff(spdBuff);

        base.closeEvenCanvas();
    }
}
