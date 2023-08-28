using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class cardHandler : MonoBehaviour
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
    public combatManager comIns;
    public Character player;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        comIns = combatManager.Instance;
        player = this.gameObject.GetComponent<Character>();
        currentMana = player.maxMana;

        if (comIns.state == BattleState.START)
        {
            initCard();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateTurnGuage()
    {
        if (comIns.state == BattleState.NORMAL)
        {
            turnGauge = turnGauge - Time.deltaTime * 10 * player.currentSPD;
        }
    } 

    protected virtual void displayInhandCard()
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

    public void drawCard()
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