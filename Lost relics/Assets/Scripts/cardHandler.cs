using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardHandler : MonoBehaviour
{
    public float turnGauge = 100f;
    public stance myStatnce;
    [Header("Card")]
    [SerializeField]
    private Transform cardParent;
    [SerializeField]
    private GameObject cardTemplate;
    public List<Card> playerDeck;
    public List<Card> discardedDeck;
    [SerializeField]
    private List<Card> _currentDeck;
    public List<Card> cardInHand;

    [SerializeField]
    private int handLimit = 7;
    private combatManager comIns;
    private player player;
    // Start is called before the first frame update
    void Start()
    {
        comIns = combatManager.Instance;
        player = GetComponent<player>();

        if (comIns.state == BattleState.START)
        {
            initCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (comIns.state == BattleState.NORMAL)
        {
            turnGauge = turnGauge - Time.deltaTime * 30;
        }
        if (turnGauge <= 0 && comIns.state == BattleState.NORMAL)
        {
            comIns.state = BattleState.PLAYER;
            comIns.currentObjTurn = this.gameObject;
            drawCard();
            displayInhandCard();
        }
    }

    private void displayInhandCard()
    {  
        for (int i = 0; i < cardInHand.Count; i++)
        {
            GameObject pCard = Instantiate(cardTemplate, cardParent.position + new Vector3(-i*100,0,0), Quaternion.identity, cardParent);
            pCard.GetComponent<cardDisplay>().card = cardInHand[i];
            //cardInHandObj.Add(pCard.gameObject);
            pCard.name = pCard.name + " " + i.ToString();
        }

    }

    private void initCard()
    {
        _currentDeck.AddRange(playerDeck);

        for (int i = 0; i < player.maxPlayerHand; i++)
        {
            cardInHand.Add(_currentDeck[i]);
            _currentDeck.RemoveAt(i);       
        }

    }

    private void drawCard()
    {
        if (cardInHand.Count >= handLimit) // card in hand reach hand limit
        {
            discardedDeck.Add(cardInHand[0]);
            cardInHand.RemoveAt(0);
            addCardTohand();
        }
        else
        {
            addCardTohand();

        }
    
    }
    
    private void addCardTohand()
    {
        if (_currentDeck.Count <= 0)
        {
            resetCurrentDeck();
        }
        cardInHand.Add(_currentDeck[0]);
        _currentDeck.RemoveAt(0);
    }

    private void resetCurrentDeck()
    {
        _currentDeck.AddRange(discardedDeck);
        discardedDeck.Clear();
        //shuffle
    }

    public void destroyInHandCard()
    {
        for (int i =0; i < cardParent.childCount; i++)
        {
            Destroy(cardParent.GetChild(i).gameObject);
        }
    }


}
