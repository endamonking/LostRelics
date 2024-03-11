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
        string des2 = "Increase ATK by 30%";
        buff summerBless;
        buff otherSummerBless;

        //Add buff
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        //SPD
        if (playerCardHanlder.cardInHand.Contains(EmmaToken))
        {
            des2 = "Increase ATK by 30%, and SPD by 20%";
            summerBless = new buff("Summer’s blessing", 3, "ATK_Up",des2);
            summerBless.AddBuff("ATK", atkMulti);
            otherSummerBless = new buff("Summer’s blessing", 2, "ATK_Up",des2);
            otherSummerBless.AddBuff("ATK", atkMulti);
            summerBless.AddBuff("SPD", spdMulti);
            otherSummerBless.AddBuff("SPD", spdMulti);
            user.applyActiveBuff(summerBless,false);
            foreach (GameObject remainingplayer in players)
            {
                if (remainingplayer == combatManager.Instance.currentObjTurn) //Not current Character
                    continue;
                Character pCharacter = remainingplayer.GetComponent<Character>();
                pCharacter.applyActiveBuff(otherSummerBless, false);
            }
            playerCardHanlder.cardInHand.Remove(EmmaToken);
            playerCardHanlder.updateCardInhand();
        }
        else
        {
            summerBless = new buff("Summer’s blessing", 3, "ATK_Up", des2);
            summerBless.AddBuff("ATK", atkMulti);
            otherSummerBless = new buff("Summer’s blessing", 2, "ATK_Up", des2);
            otherSummerBless.AddBuff("ATK", atkMulti);
            user.applyActiveBuff(summerBless, false);
            foreach (GameObject remainingplayer in players)
            {
                if (remainingplayer == combatManager.Instance.currentObjTurn) //Not current Character
                    continue;
                Character pCharacter = remainingplayer.GetComponent<Character>();
                pCharacter.applyActiveBuff(otherSummerBless, false);
            }
        }
        user.doCharacterSound();
        return true;
    }
}
