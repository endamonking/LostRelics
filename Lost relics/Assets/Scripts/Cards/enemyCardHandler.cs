using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCardHandler : cardHandler
{

    private bool test = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine(test1());
    }

    // Update is called once per frame
    void Update()
    {
        updateTurnGuage();
        if (turnGauge <= 0 && comIns.state == BattleState.NORMAL)
        {
            comIns.changeTurn(BattleState.ENEMY);
            comIns.currentObjTurn = this.gameObject;
            drawCard();
            //displayInhandCard();
            doAction();
        }

    }

    private void doAction()
    {
        Debug.Log(this.gameObject.name);
        if (test == false)
        {
            test = true;
            StartCoroutine(test1());
        }
    }

    IEnumerator test1()
    {
        while (test == true)
        {
            yield return new WaitForSeconds(2.0f);
            test = false;
        }

        comIns.endTurn();

    }

}
