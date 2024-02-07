using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmaPassSkill : uniquePassSkill, IStartturnEffect
{
    public Card tokenCard;
    private cardHandler playerCardHand;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStartTurn()
    {
        playerCardHand = characterGO.GetComponent<cardHandler>();
        playerCardHand.createCardToHand(tokenCard);
        playerCardHand.drawCard();
    }

}
