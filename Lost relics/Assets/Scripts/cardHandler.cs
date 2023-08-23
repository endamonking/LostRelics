using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardHandler : MonoBehaviour
{
    public float turnGauge = 100f;
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
    [Header("Attribute")]
    public int currentMana;

    [SerializeField]
    private int handLimit = 7;
    private combatManager comIns;
    private Character player;
    // Start is called before the first frame update
    void Start()
    {
        comIns = combatManager.Instance;
        player = GetComponent<Character>();
        currentMana = player.maxMana;

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
            comIns.changeTurn(BattleState.PLAYER);
            comIns.currentObjTurn = this.gameObject;
            drawCard();
            displayInhandCard();
        }
    }

    private void displayInhandCard()
    {  
        for (int i = 0; i < cardInHand.Count; i++)
        {
            GameObject pCard = Instantiate(cardTemplate, cardParent);
            pCard.transform.position = pCard.transform.position + new Vector3(-i*110, 0,0);
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
            if (cardParent.GetChild(i).tag == "Card")
                Destroy(cardParent.GetChild(i).gameObject);
        }
    }


}
