using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summersBlessing : cardEffect
{
    [SerializeField]
    private int atkMulti = 20, spdMulti = 20;
    [SerializeField]
    private Card EmmaToken;
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

        buff summerBless = new buff("Summer’s blessing", 2, "ATK_Up");
        summerBless.AddBuff("ATK", atkMulti);

        //Add buff
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        foreach (GameObject remainingplayer in players)
        {
            Character pCharacter = remainingplayer.GetComponent<Character>();
            pCharacter.applyActiveBuff(summerBless, false);
        }
        //SPD
        if (playerCardHanlder.cardInHand.Contains(EmmaToken))
        {
            foreach (GameObject remainingplayer in players)
            {
                Character pCharacter = remainingplayer.GetComponent<Character>();
                summerBless.AddBuff("SPD", spdMulti);
                pCharacter.applyActiveBuff(summerBless, false);
            }
            playerCardHanlder.cardInHand.Remove(EmmaToken);
            playerCardHanlder.updateCardInhand();
        }

        return true;
    }
}
