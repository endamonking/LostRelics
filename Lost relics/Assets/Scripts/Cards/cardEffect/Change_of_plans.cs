using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_of_plans : cardEffect
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool applyEffect(Character target, Character user)
    {
        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();


        for (int i = 0; i < 2; i++)
        {
            int randomIndex = Random.Range(0, playerCardHanlder.cardInHand.Count);

            if (playerCardHanlder.cardInHand.Count <= 0) //no card to discard Then change to panic and continue
            {
                target.changingStance(stance.Panic, false);
                continue;
            }
            Card discardCard = playerCardHanlder.cardInHand[randomIndex];

            if (discardCard != null)
            {
                Debug.Log(discardCard.name);
                playerCardHanlder.discardedDeck.Add(discardCard);
                playerCardHanlder.cardInHand.Remove(discardCard);
            }

        }

        for (int i = 0; i < 3; i++)
        {
            playerCardHanlder.drawCard();
        }

        return true;
    }
}
