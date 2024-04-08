using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public List<Card> _currentDeck;
    public List<Card> cardInHand;
    public Card drawedCard;
    public int cardDrawedThisTurn = 0;
    [Header("Attribute")]
    public int currentMana;

    [SerializeField]
    private int handLimit = 7;
    [Header("Object")]
    public combatManager comIns;
    public Character player;
    [Header("Turn guage")]
    [SerializeField]
    private Scrollbar turnGuagePrefab;
    public Scrollbar turnGuageUI;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        comIns = combatManager.Instance;
        if (comIns == null)
            return;
        cardParent = GameObject.FindGameObjectWithTag("MainCanvas").gameObject.transform;
        player = this.gameObject.GetComponent<Character>();
        currentMana = player.maxMana;
        turnGuageUI = Instantiate(turnGuagePrefab, cardParent);
        turnGuageUI.GetComponentInChildren<GuagePic>().changeCharacterImage(player.characterName);
        initCard();
        turnGuageUI.name = this.gameObject.name + " Bar";
        turnGuageUI.value = 1.0f;
        /*
        if (comIns.state == BattleState.START)
        {
            initCard();
            turnGuageUI.name = this.gameObject.name + " Bar";
            turnGuageUI.value = 1.0f;
        }*/

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateTurnGuage()
    {
        if (comIns == null)
            return;

        if (comIns.state == BattleState.NORMAL)
        {
            turnGauge = turnGauge -  10 * player.inComSPD * Time.deltaTime;
            turnGuageUI.value = Mathf.InverseLerp(0f, 100f, turnGauge);
            
        }
    } 

    protected virtual void displayInhandCard()
    {
        for (int i = 0; i < cardInHand.Count; i++)
        {
            GameObject pCard = Instantiate(cardTemplate, cardParent);
            pCard.transform.position = new Vector3(0, 0, 0);
            pCard.transform.position = pCard.transform.position + new Vector3(1000, 0, 0);
            pCard.transform.position = pCard.transform.position + new Vector3(-i*130, 0,0);
            pCard.GetComponent<cardDisplay>().card = cardInHand[i];
            pCard.name = pCard.name + " " + i.ToString();
        }

    }

    public void updateCardInhand()
    {
        setFalseCard();
        displayInhandCard();
    }

    public void setFalseCard()
    {
        if (cardParent == null)
            return;

        for (int i = 0; i < cardParent.childCount; i++)
        {
            if (cardParent.GetChild(i).tag == "Card")
                cardParent.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void displayDiscardedCard(GameObject box)
    {
        if (discardedDeck.Count == 0)
            return;

        for (int i = 0; i < discardedDeck.Count; i++)
        {
            GameObject dCard = Instantiate(cardTemplate, box.transform);
            //dCard.transform.position = dCard.transform.position + new Vector3(-i * 110, 500, 0);
            dCard.GetComponent<cardDisplay>().card = discardedDeck[i];
            dCard.GetComponent<cardDisplay>().showOnly = true;
            dCard.name = dCard.name + " " + i.ToString();
        }
    }

    private void initCard()
    {
        //_currentDeck.AddRange(playerDeck);
        foreach (Card card in playerDeck)
        {
            Card newCard = Instantiate(card);
            _currentDeck.Add(newCard);
        }
        //Shuffle
        shuffle(_currentDeck);
        for (int i = 0; i < 3; i++)
        {
            if (_currentDeck.Count <= i)
                break;
            cardInHand.Add(_currentDeck[i]);
            _currentDeck.RemoveAt(i);       
        }

    }
    //use to add card to hand not via deck ( similar to draw but usally use on Token card )
    public void createCardToHand(Card createdCard)
    {
        if (cardInHand.Count >= handLimit) // card in hand reach hand limit
        {
            if (cardInHand[0].isToken == false)
                discardedDeck.Add(cardInHand[0]);

            cardInHand.RemoveAt(0);
        }
        cardInHand.Add(createdCard);
    }

    public void drawCard()
    {
        cardDrawedThisTurn++;
        if (cardInHand.Count >= handLimit) // card in hand reach hand limit
        {
            if (cardInHand[0].isToken == false)
                discardedDeck.Add(cardInHand[0]);
            cardInHand.RemoveAt(0);
            addCardTohand();
        }
        else
        {
            addCardTohand();
        }
        player.doStanceOnDrawEffect();
    
    }
    private void addCardTohand()
    {
        if (_currentDeck.Count <= 0)
        {
            if (resetCurrentDeck())
            {
                //Why i do like this????? spageti code
                cardInHand.Add(_currentDeck[0]);
                drawedCard = _currentDeck[0];
                _currentDeck.RemoveAt(0);
                return;
            }
            else
                return;
        }
        //normal draw case
        cardInHand.Add(_currentDeck[0]);
        drawedCard = _currentDeck[0];
        _currentDeck.RemoveAt(0);
    }

    public Card drawCardWithReturnDrawCard()
    {
        Card returnCard;
        cardDrawedThisTurn++;
        if (cardInHand.Count >= handLimit) // card in hand reach hand limit
        {
            if (cardInHand[0].isToken == false)
                discardedDeck.Add(cardInHand[0]);
            cardInHand.RemoveAt(0);
            returnCard = addCardTohandWithReturn();
        }
        else
        {
            returnCard = addCardTohandWithReturn();
        }
        player.doStanceOnDrawEffect();
        return returnCard;
    }

    private Card addCardTohandWithReturn()
    {
        Card returnCard;
        if (_currentDeck.Count <= 0)
        {
            if (resetCurrentDeck())
            {
                //Why i do like this????? spageti code
                cardInHand.Add(_currentDeck[0]);
                drawedCard = _currentDeck[0];
                returnCard = _currentDeck[0];
                _currentDeck.RemoveAt(0);
                return drawedCard;
            }
            else
                return null;
        }
        //normal draw case
        cardInHand.Add(_currentDeck[0]);
        drawedCard = _currentDeck[0];
        returnCard = _currentDeck[0];
        _currentDeck.RemoveAt(0);
        return returnCard;
    }

    //Use to make card in hand = max hand if it exceed the hand limit
    //Will use it at the end of turn;
    public void resetCardInHand()
    {
        int exceedNumber = cardInHand.Count- handLimit;
        if (exceedNumber > 0) // card in hand reach hand limit
        {
            for (int i = 0; i < exceedNumber; i++)
            {
                if (cardInHand[0].isToken == false)
                {
                    discardedDeck.Add(cardInHand[0]);

                }

                cardInHand.RemoveAt(0);
            }
        }
    }

    // use to restore current deck
    // True = when successfull restrore (There is discared deck)
    // false = no discard deck
    private bool resetCurrentDeck()
    {
        if (discardedDeck.Count <= 0)
        {
            return false;
        }
        _currentDeck.AddRange(discardedDeck);
        discardedDeck.Clear();
        //shuffle
        shuffle(_currentDeck);

        return true;
    }

    public void shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }

    public void destroyInHandCard()
    {
        if (cardParent == null)
            return;

        for (int i =0; i < cardParent.childCount; i++)
        {
            if (cardParent.GetChild(i).tag == "Card")
                Destroy(cardParent.GetChild(i).gameObject);
        }
    }

    public void showDeckList(GameObject container)
    {
        if (playerDeck.Count == 0)
            return;

        for (int i = 0; i < playerDeck.Count; i++)
        {
            GameObject dCard = Instantiate(cardTemplate, container.transform);
            //dCard.transform.position = dCard.transform.position + new Vector3(-i * 110, 500, 0);
            dCard.GetComponent<cardDisplay>().card = playerDeck[i];
            dCard.GetComponent<cardDisplay>().showOnly = true;
            dCard.name = dCard.name + " " + i.ToString();
        }
    }
    public List<GameObject> showDeckListAndReturnList(GameObject container)
    {
        if (playerDeck.Count == 0)
            return null;
        List<GameObject> cardGOList = new List<GameObject>();

        for (int i = 0; i < playerDeck.Count; i++)
        {
            GameObject dCard = Instantiate(cardTemplate, container.transform);
            //dCard.transform.position = dCard.transform.position + new Vector3(-i * 110, 500, 0);
            dCard.GetComponent<cardDisplay>().card = playerDeck[i];
            dCard.GetComponent<cardDisplay>().showOnly = true;
            dCard.name = dCard.name + " " + i.ToString();
            cardGOList.Add(dCard);
        }
        return cardGOList;
    }

    public void deleteCard(Card selectedCard)
    {
        List<Card> cardList = new List<Card>();
        cardList.AddRange(playerDeck);
        for (int i = 0; i < cardList.Count; i++)
        {
            if (cardList[i] == selectedCard)
            {
                playerDeck.RemoveAt(i);
                break;
            }
        }
    }

    public void resedDrawCounter()
    {
        cardDrawedThisTurn = 0;
    }

}
