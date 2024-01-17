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
    [Header("Delete card")]
    public Button openDeleteTabButton;
    public GameObject deckBox;
    public Image characterDeckPortrait;
    public int maxDeleteCount = 1;
    private int deleteCount = 0;
    private GameObject selectedCard;

    private int characterIndex = 0;
    private bool isPlayerNear = false;
    private bool isOpen = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        tgCanvas.SetActive(false);
        mainTab.SetActive(false);
        deleteCardTab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerNear == true)
        {
            doTraining();
        }
    }

    private void doTraining()
    {
        if (isOpen)
            closeTraining();
        else
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
        player.GetComponent<PlayerControl>().resumePlaterMovement();
        isOpen = false;
    }

    public void nextDeck(int number)
    {
        characterIndex += number;
        if (characterIndex >= playerList.Length)
            characterIndex = 0;
        else if (characterIndex < 0)
            characterIndex = playerList.Length - 1;
        opendeleteCard();
    }

    public void opendeleteCard()
    {
        mainTab.SetActive(false);
        deleteCardTab.SetActive(true);
        //Reset value
        selectedCard = null;
        //UI
        characterDeckPortrait.sprite = playerList[characterIndex].GetComponentInChildren<SpriteRenderer>().sprite;
        generateCard();
    }

    private void generateCard()
    {
        characterIndex = 0;
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
        checkCondition();
    }

    private void clearDeckBox()
    {
        foreach (Transform child in deckBox.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
