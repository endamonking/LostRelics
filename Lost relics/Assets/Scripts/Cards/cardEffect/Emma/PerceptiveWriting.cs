using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptiveWriting : cardEffect
{
    public int addNumber = 2;
    public Card tokenCard;
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
        cardHandler playerCardHand = user.gameObject.GetComponent<cardHandler>();
        for (int i= 0; i < addNumber; i++)
        {
            playerCardHand.createCardToHand(tokenCard);
        }

        return true;
    }
}
