using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class questManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject questCanvas;
    public GameObject buttonPrefab;

    [Header("Receive Quest tab")]
    public Button openReceiveTab;
    public GameObject receiveTab;
    public GameObject questDetail;
    public GameObject questContainer;
    public TextMeshProUGUI questName;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI moneyText;
    public List<quest> questsPrefab = new List<quest>();
    private List<quest> questsInshop = new List<quest>();
    public int maxQuest = 3;
    private quest selectedQuest = null;
    public int questFee = 100;

    [Header("Send")]
    public Button openSendTab;
    public GameObject completeTab;
    public GameObject questCompleteDetail;
    public GameObject completeQuestContainer;
    public TextMeshProUGUI completeQuestName;
    public TextMeshProUGUI completeQuestDescription;
    public TextMeshProUGUI completeMoneyText;
    public TextMeshProUGUI questStatus;
    private quest selectedCompleteQuest = null;

    private bool isPlayerNear = false;
    private bool isOpen = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        questDetail.SetActive(false);
        questCanvas.SetActive(false);
        completeTab.SetActive(false);
        questCompleteDetail.SetActive(false);
        int i = 0;
        while (i < maxQuest)
        {
            int randomIndex = Random.Range(0, questsPrefab.Count);
            questsInshop.Add(questsPrefab[randomIndex]);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerNear == true)
        {
            openQuestBoard();
        }
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

    private void openQuestBoard()
    {
        if (isOpen)
            closeShop();
        else
            openShop();
    }

    private void openShop()
    {
        selectedQuest = null;
        completeTab.SetActive(false);
        questCompleteDetail.SetActive(false);
        receiveTab.SetActive(true);
        isOpen = true;
        player.GetComponent<PlayerControl>().stopPlaterMovement();
        questCanvas.SetActive(true);
        generateQuest();
    }

    private void closeShop()
    {
        questCanvas.SetActive(false);
        questDetail.SetActive(false);
        completeTab.SetActive(false);
        questCompleteDetail.SetActive(false);
        player.GetComponent<PlayerControl>().resumePlaterMovement();
        isOpen = false;
    }

    private void generateQuest()
    {
        questDetail.SetActive(false);
        clearItemInContainer(questContainer);
        changeReceiveTabColor();
        moneyText.text = "Money : " +inventoryManager.Instance.money.ToString();

        foreach (quest q in questsInshop)
        {
            GameObject eq = Instantiate(buttonPrefab, questContainer.transform);
            Button but = eq.GetComponent<Button>();
            but.onClick.RemoveAllListeners();
            but.onClick.AddListener(() => chooseThisQuest(q));
            eq.GetComponentInChildren<TextMeshProUGUI>().text = q.questName;
        }


    }
    private void clearItemInContainer(GameObject boxContainer)
    {
        foreach (Transform child in boxContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void chooseThisQuest(quest thisQuest)
    {
        selectedQuest = thisQuest;
        printQuestDetail();
    }

    private void printQuestDetail()
    {
        questDetail.SetActive(true);
        questName.text = selectedQuest.questName;
        questDescription.text = selectedQuest.questDescription;
    }

    public void acceptQuest()
    {
        if (selectedQuest == null)
            return;

        if (inventoryManager.Instance.money >= questFee)
        {
            //- because it buy
            inventoryManager.Instance.addMoney(-questFee);
            inventoryManager.Instance.addQuest(selectedQuest);
            questsInshop.Remove(selectedQuest);
            openShop();
        }
    }
    public void opencompleteQuestTab()
    {

        receiveTab.SetActive(false);
        generateCompleteQuest();
    }

    public void openReceiveQuestTab()
    {
        completeTab.SetActive(false);
        openShop();
    }

    private void changeReceiveTabColor()
    {
        ColorBlock sendcolorBlock = openSendTab.colors;
        sendcolorBlock.normalColor = new Color(255f, 255f, 255f, 0.5f);
        openSendTab.colors = sendcolorBlock;

        ColorBlock colorBlock = openReceiveTab.colors;
        colorBlock.normalColor = new Color(255f, 255f, 255f, 1.0f);
        openReceiveTab.colors = colorBlock;
    }

    //Complete Quest

    private void generateCompleteQuest()
    {
        selectedCompleteQuest = null;
        questCompleteDetail.SetActive(false);
        completeTab.SetActive(true);
        clearItemInContainer(completeQuestContainer);
        changeSnedTabColor();
        completeMoneyText.text = "Money : " + inventoryManager.Instance.money.ToString();

        foreach (quest q in inventoryManager.Instance.questList)
        {
            GameObject eq = Instantiate(buttonPrefab, completeQuestContainer.transform);
            Button but = eq.GetComponent<Button>();
            but.onClick.RemoveAllListeners();
            but.onClick.AddListener(() => chooseThisCompleteQuest(q));
            eq.GetComponentInChildren<TextMeshProUGUI>().text = q.questName;
        }
    }
    private void chooseThisCompleteQuest(quest thisQuest)
    {
        selectedCompleteQuest = thisQuest;
        printCompleteQuestDetail();
    }

    private void printCompleteQuestDetail()
    {
        questCompleteDetail.SetActive(true);
        completeQuestName.text = selectedCompleteQuest.questName;
        completeQuestDescription.text = selectedCompleteQuest.questDescription;
        if (selectedCompleteQuest.isComplete)
            questStatus.text = "Status : Complete";
        else
            questStatus.text = "Status : Not complete";
    }
    public void sendQuest()
    {
        if (selectedCompleteQuest == null)
            return;

        if (selectedCompleteQuest.isComplete)
        {
            inventoryManager.Instance.addMoney(selectedCompleteQuest.moneyReward);
            inventoryManager.Instance.removeQuest(selectedCompleteQuest);
            generateCompleteQuest();
        }
    }
    private void changeSnedTabColor()
    {
        ColorBlock semdcolorBlock = openSendTab.colors;
        semdcolorBlock.normalColor = new Color(255f, 255f, 255f, 1f);
        openSendTab.colors = semdcolorBlock;

        ColorBlock colorBlock = openReceiveTab.colors;
        colorBlock.normalColor = new Color(255f, 255f, 255f, 0.5f);
        openReceiveTab.colors = colorBlock;
    }



}
