using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class trainingGround : MonoBehaviour
{
    public GameObject[] playerList;
    [Header("Over all UI")]
    //tg = training ground
    public GameObject tgCanvas;
    public GameObject mainTab;
    public GameObject deleteCardTab;
    public GameObject buyCardTab;
    [Header("Delete card")]
    public Button openDeleteTabButton;
    public GameObject deckBox;
    public Image characterDeckPortrait;
    public int maxDeleteCount = 1;
    private int deleteCount = 0;
    private GameObject selectedCard;
    [Header("Buy card")]
    public List<GameObject> cardGOList = new List<GameObject>();
    public GameObject chooseCharacter;
    public GameObject chooseCardToBuy;
    public GameObject buyCardButtonPrefab;
    public GameObject descriptionGo;
    public GameObject moneyTextGo;
    public TextMeshProUGUI buyCardDescription;
    public int baseCost = 200;
    public int costTobuy = 200;
    private int buyCardCount = 0;
    private Card choosedCard = null;
    private GameObject choosedCharacter;

    private int characterIndex = 0;
    private bool isPlayerNear = false;
    private bool isOpen = false;
    private bool forceCantClose = false; //Use to make player cant leave to screen by pressing F
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        tgCanvas.SetActive(false);
        mainTab.SetActive(false);
        deleteCardTab.SetActive(false);
        buyCardTab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerNear == true)
        {
            inventoryManager.Instance.closePlayerCanvas();
            doTraining();
        }
    }

    private void doTraining()
    {
        if (isOpen && forceCantClose == false)
            closeTraining();
        else if (forceCantClose == false)
            openTraining();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNear = true;
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNear = false;
            player = null;
        }
    }

    private void checkCondition()
    {
        //Delete
        if (deleteCount >= maxDeleteCount)
        {
            openDeleteTabButton.interactable = false;
        }

    }

    private void openTraining()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        isOpen = true;
        player.GetComponent<PlayerControl>().stopPlaterMovement();
        tgCanvas.SetActive(true);
        mainTab.SetActive(true);
        checkCondition();
    }

    public void closeTraining()
    {
        tgCanvas.SetActive(false);
        mainTab.SetActive(false);
        deleteCardTab.SetActive(false);
        buyCardTab.SetActive(false);
        player.GetComponent<PlayerControl>().resumePlaterMovement();
        isOpen = false;
        forceCantClose = false;
    }

    public void nextDeck(int number)
    {
        Debug.Log(characterIndex);
        characterIndex += number;
        Debug.Log(characterIndex);
        if (characterIndex >= playerList.Length)
        {
            characterIndex = 0;
            Debug.Log(playerList.Length);
            Debug.Log(playerList.Length - 1);
            Debug.Log(characterIndex);
        }
        else if (characterIndex < 0)
        {
            characterIndex = playerList.Length - 1;
            Debug.Log(playerList.Length);
            Debug.Log(playerList.Length - 1);
            Debug.Log(characterIndex);
        }

        opendeleteCard();
    }

    public void opendeleteCard()
    {
        Debug.Log("d");
        mainTab.SetActive(false);
        deleteCardTab.SetActive(true);
        //Reset value
        selectedCard = null;
        //UI
        Debug.Log(characterIndex);
        characterDeckPortrait.sprite = playerList[characterIndex].GetComponentInChildren<Unit>().portrait;
        generateCard();
    }

    private void generateCard()
    {
        clearDeckBox();
        Character player = playerList[characterIndex].GetComponent<Character>();
        //Generate card
        List<GameObject> cardList = new List<GameObject>();
        cardList = playerList[characterIndex].GetComponent<cardHandler>().showDeckListAndReturnList(deckBox);
        foreach (GameObject thisCard in cardList)
        {
            if (thisCard.GetComponent<Button>() == null)
            {
                thisCard.AddComponent<Button>();
            }
            Button but = thisCard.GetComponent<Button>();
            but.onClick.RemoveAllListeners();
            but.onClick.AddListener(() => selectThisCard(thisCard));
        }
    }

    public void confirmDeleteCard()
    {
        if (selectedCard == null)
            return;
        playerList[characterIndex].GetComponent<cardHandler>().deleteCard(selectedCard.GetComponent<cardDisplay>().card);
        deleteCount++;
        backToTopic();
    }

    private void selectThisCard(GameObject thisCard)
    {
        selectedCard = thisCard;
    }

    public void backToTopic()
    {
        mainTab.SetActive(true);
        deleteCardTab.SetActive(false);
        buyCardTab.SetActive(false);
        forceCantClose = false;
        checkCondition();
    }

    private void clearDeckBox()
    {
        foreach (Transform child in deckBox.transform)
        {
            Destroy(child.gameObject);
        }
    }

    //Buy card
    private void clearDialogInContainer()
    {
        foreach (Transform child in chooseCharacter.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void openBuyCard()
    {
        mainTab.SetActive(false);
        chooseCardToBuy.SetActive(false);
        buyCardTab.SetActive(true);
        chooseCharacter.SetActive(true);
        descriptionGo.SetActive(true);
        moneyTextGo.SetActive(true);
        costTobuy = Mathf.FloorToInt(baseCost + (baseCost * (0.5f * buyCardCount)));
        if (inventoryManager.Instance.money >= costTobuy)
            buyCardDescription.text = "Who do you want to train?(Cost: " + costTobuy.ToString() + ")";
        else
            buyCardDescription.text = "You don't have enough money!!(Need " + costTobuy.ToString() +" )";
        moneyTextGo.GetComponent<TextMeshProUGUI>().text = "Money : " + inventoryManager.Instance.money.ToString();
        //print Text
        clearDialogInContainer();
        int i = 0;
        if (inventoryManager.Instance.money >= costTobuy)
        {
            foreach (GameObject thisCharacter in playerList)
            {
                GameObject buttonGO = Instantiate(buyCardButtonPrefab, chooseCharacter.transform);
                buttonGO.transform.position = buttonGO.transform.position + new Vector3(0, 100, 0) + new Vector3 (0,-100*i,0);
                TextMeshProUGUI tmp = buttonGO.GetComponentInChildren<TextMeshProUGUI>();
                tmp.text = thisCharacter.GetComponent<Character>().characterName;
                buttonGO.GetComponent<Button>().onClick.AddListener(() => openChooseCardToBuy(thisCharacter));
                i++;
            }
        }
        //Print return
        GameObject backBut = Instantiate(buyCardButtonPrefab, chooseCharacter.transform);
        backBut.transform.position = backBut.transform.position + new Vector3(0, 100, 0) + new Vector3(0, -100 * i, 0);
        TextMeshProUGUI tmpA = backBut.GetComponentInChildren<TextMeshProUGUI>();
        tmpA.text = "Return";
        backBut.GetComponent<Button>().onClick.AddListener(() => backToTopic());
    }


    private void openChooseCardToBuy(GameObject character)
    {
        //init
        choosedCharacter = character;
        choosedCard = null;
        forceCantClose = true;
        descriptionGo.SetActive(false);
        moneyTextGo.SetActive(false);
        chooseCharacter.SetActive(false);
        chooseCardToBuy.SetActive(true);
        //Create card
        List<Card> playerPool = cardPool.Instance.getCharactCardList(character.GetComponent<Character>().characterName);
        List<Card> chooseCardList = createChooseCardList(playerPool);
        for (int i =0; i < cardGOList.Count; i++)
        {
            int dummy = i;
            //cardGOList[i].GetComponentInChildren<TextMeshProUGUI>().text = chooseCardList[i].cardName;
            cardGOList[i].GetComponent<pritnCardDetail>().assignDetail(chooseCardList[dummy]);
            Button button = cardGOList[i].GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => chooseThisCard(chooseCardList[dummy]));
        }

    }

    private void chooseThisCard(Card card)
    {
        choosedCard = card;
    }

    public void confirmToBuyCard()
    {
        if (choosedCard == null || choosedCharacter == null)
            return;
        choosedCharacter.GetComponent<cardHandler>().playerDeck.Add(choosedCard);
        inventoryManager.Instance.addMoney(-costTobuy);
        buyCardCount++;
        forceCantClose = false;
        backToTopic();
    }

    private List<Card> createChooseCardList(List<Card> cards)
    {
        List<Card> outputList = new List<Card>();
        List<int> indexList = new List<int>();
        while (indexList.Count < 3)
        {
            int index = Random.Range(0, cards.Count);

            if (indexList.Contains(index))
                continue;
            else
                indexList.Add(index);
        }
        foreach (int index in indexList)
        {
            outputList.Add(cards[index]);
        }
        return outputList;
    }

}
