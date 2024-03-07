using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class approachingDeadlines : cardEffect
{
    [SerializeField]
    private Card tokenCard;
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
        cardHandler CH = user.gameObject.GetComponent<cardHandler>();
        int addNumber = 0;
        foreach (Card card in CH.cardInHand)
        {
            if (card == tokenCard)
                addNumber++;
        }
        // Restore mana
        float number = addNumber / 2.0f;
        int manaRecover = Mathf.FloorToInt(number);
        CH.currentMana = manaRecover + CH.currentMana;
        if (CH.currentMana >= user.maxMana)
            CH.currentMana = user.maxMana;
        //Duplicate card
        for (int i = 0; i < addNumber; i++)
        {
            CH.createCardToHand(tokenCard);
        }
        CH.drawCard();
        user.doCharacterSound();

        return true;
    }
}
