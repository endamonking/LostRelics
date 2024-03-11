using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class node5Opt2 : nodeEfffect
{
    [SerializeField]
    private Button buttonPrefab;
    [SerializeField]
    private string nodeName, description;
    [SerializeField]
    private int healAmount = 30, poisonPercenATK = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void doEffect()
    {
        List<GameObject> playersCha = exploration_sceneManager.Instance.playerPool;

        foreach (GameObject character in playersCha)
        {
            Character pCha = character.GetComponent<Character>();
            pCha.currentHP = pCha.currentHP + healAmount;
            if (pCha.currentHP >= pCha.inComMaxHP)
                pCha.currentHP = pCha.inComMaxHP;
        }
        //Add debuff
        string des = "Receive true damage at the start of the turn";
        buff deBuff = new buff("Poison", 99, "Poison", des);
        int damageAmount = poisonPercenATK;

        deBuff.AddBuff("PoisonMaxHP", damageAmount);
        exploration_sceneManager.Instance.applyExploDeBuff(deBuff, 1);
        //Add card
        exploration_sceneManager.Instance.clearEventButton();
        int i = 0;
        foreach (GameObject player in playersCha)
        {
            Button ansBut = Instantiate(buttonPrefab, exploration_sceneManager.Instance.answerContainer);
            Vector3 position = new Vector3(0, i, 0);
            ansBut.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Character>().characterName;
            ansBut.GetComponent<RectTransform>().anchoredPosition = position;
            List<Card> cards = cardPool.Instance.getCharactCardList(player.GetComponent<Character>().characterName);
            ansBut.onClick.AddListener(() => addCard(cards, player.GetComponent<cardHandler>()));
            i = i - 100;
            exploration_sceneManager.Instance.answerButtonList.Add(ansBut);
        }
        exploration_sceneManager.Instance.updateEventCanvas(nodeName, description);


    }

    private void addCard(List<Card> cards, cardHandler pCH)
    {
        base.closeEvenCanvas();
        getCardManager.Instance.startChooseCardEvent(cards, pCH);
    }
}
