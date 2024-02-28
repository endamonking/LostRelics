using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeraphinaPassSkill : uniquePassSkill, IStartturnEffect
{
    public Card tokenCard;
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
        cardHandler playerCardHand = characterGO.GetComponent<cardHandler>();
        playerCardHand.createCardToHand(tokenCard);
    }
}
