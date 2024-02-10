using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCardHandler : cardHandler
{
    private bool isAction = false;
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
            comIns.changeTurn(BattleState.ENEMY, this.gameObject);
            drawCard();
            if (isAction == false)
                StartCoroutine(doAction());
        }

    }

    private IEnumerator doAction()
    {
        isAction = true;
        List<Card> currentCardInHand = new List<Card>(cardInHand);
        while (currentMana > 0)
        {
            foreach (Card card in currentCardInHand)
            {
                if (currentMana >= card.cardCost)
                {
                    GameObject target = GameObject.FindWithTag("Player");
                    if (target == null)
                        continue;
                    currentMana = currentMana - card.cardCost;
                    card.doCardEffect(this.player, target.GetComponent<Character>());
                    comIns.doCharacterAnimationAndSound(this.gameObject);
                    cardInHand.Remove(card);
                    //Token check
                    float delayTime = card.delayAction;
                    if (card.isToken == false)
                        discardedDeck.Add(card);
                    yield return new WaitForSeconds(delayTime);
                }
            }
            
            break;
        }

        isAction = false;
        comIns.endTurn();
    }

    IEnumerator delayAction(float time)
    {
        Debug.Log("delayed");
        yield return new WaitForSeconds(time);
    }

}
