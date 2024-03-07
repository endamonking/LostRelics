using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBeauty : cardEffect
{
    [SerializeField]
    private int skillMultiplier = 100;
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
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        int healPower = user.inComHeal;
        float skillMuti = skillMultiplier / 100.0f;

        if (playerCardHanlder.cardInHand.Contains(EmmaToken))
        {
            playerCardHanlder.cardInHand.Remove(EmmaToken);
            foreach (GameObject go in players)
            {
                go.GetComponent<Character>().getHeal(healPower, skillMuti);
            }

        }
        user.doCharacterSound();
        return true;
    }
}
