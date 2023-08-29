using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCarHandler : cardHandler
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        updateTurnGuage();
        if (turnGauge <= 0 && comIns.state == BattleState.NORMAL)
        {
            Debug.Log(this.gameObject.name);
            comIns.changeTurn(BattleState.PLAYER);
            comIns.currentObjTurn = this.gameObject;
            drawCard();
            displayInhandCard();
        }
    }

    protected override void displayInhandCard()
    {
        base.displayInhandCard();
        comIns.endTurnButton.SetActive(true);
        comIns.updateManaText();
    }

}
