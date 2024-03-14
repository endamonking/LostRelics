using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class getCardManager : MonoBehaviour
{
    public static getCardManager Instance;

    private List<Card> choosedCardList = new List<Card>();
    private cardHandler pCardHander;
    [Header("UI")]
    public List<Button> buttonList = new List<Button>();
    public GameObject canvas;
    public TextMeshProUGUI titleText;

    private int selectCardIndex = 99;

    private void Awake()
    {
        // Ensure there is only one instance of this class
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // If an instance already exists, destroy this new instance
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectCard(int index)
    {
        selectCardIndex = index;
    }

    public void confirm()
    {
        if (selectCardIndex != 0 && selectCardIndex != 1 && selectCardIndex != 2)
            return;
        pCardHander.playerDeck.Add(choosedCardList[selectCardIndex]);
        reset();
    }

    public void startChooseCardEvent(List<Card> cards, cardHandler pCha)
    {
        exploration_sceneManager.Instance.isEvent = true;
        pCardHander = pCha;
        createChooseCardList(cards);
        int i = 0;
        foreach (Button button in buttonList)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = choosedCardList[i].cardName;
            i++;
        }
        string characterName = pCha.gameObject.GetComponent<Character>().characterName;
        titleText.text = characterName + " got";
        canvas.SetActive(true);
    }

    private void createChooseCardList(List<Card> cards)
    {
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
            choosedCardList.Add(cards[index]);
        }
    }

    private void reset()
    {
        choosedCardList.Clear();
        selectCardIndex = 99;
        canvas.SetActive(false);
        exploration_sceneManager.Instance.isEvent = false;
    }

}
