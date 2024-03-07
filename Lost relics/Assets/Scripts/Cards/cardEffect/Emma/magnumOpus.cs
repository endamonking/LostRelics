using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnumOpus : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 30;
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
        int userDamage = user.inComATK;
        int userAP = user.inComArmorPen;
        int userDMGBonus = user.inComDMGBonus;
        int userCritRate = user.inComCritRate;
        int userCritDMG = user.inComCritDMG;
        float skillMulti = baseSkillMultiplier;

        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();
        List<Card> tokenList = new List<Card>();

        foreach (Card card in playerCardHanlder.cardInHand) // Card in hand only
        {
            if (card.effect == EmmaToken.effect)
            {
                tokenList.Add(card);
            }
        }

        skillMulti = skillMulti * tokenList.Count;
        skillMulti = skillMulti / 100.0f;
        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        //Remove all token in hand
        playerCardHanlder.cardInHand.RemoveAll(card => tokenList.Contains(card));

        return true;
    }
}
