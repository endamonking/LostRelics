using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventoryCanvas : MonoBehaviour
{
    public static inventoryCanvas Instance;
    public GameObject[] playerList;

    [Header("Tab")]
    public GameObject inventoryTab;
    public GameObject characterTab;
    public GameObject deckTab;
    public GameObject questTab;
    public List<GameObject> buttonNavbar = new List<GameObject>();
    [Header("Inventory UI")]
    public GameObject inventoryScreen; 
    public Image itemPic;
    public TextMeshProUGUI itemDesText;
    public TextMeshProUGUI itemStatText;
    public TextMeshProUGUI moneyText;
    [Header("Character UI")]
    public Image portrait;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterStat;
    public GameObject equipmentBox;
    public GameObject equipmentBoxParent;
    public TextMeshProUGUI oldEquipDes;
    public TextMeshProUGUI oldEquipStat;
    public TextMeshProUGUI newEquipDes;
    public TextMeshProUGUI newEquipStat;
    public Image headPic;
    public Image armorPic;
    public Image accPic;
    private equipment selectedEquipment = null;
    private GameObject selectedEquipmentGO = null;
    [Header("Character deck")]
    public GameObject deckBox;
    public Image characterDeckPortrait;
    [Header("Quest UI")]
    public GameObject questContainer;
    public GameObject questDetail;
    public GameObject questButtonPrefab;
    public TextMeshProUGUI questName;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI questStatus;


    private int characterIndex = 0;

    private void Awake()
    {
        // If an instance already exists, destroy the new one
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Set the instance to this if it doesn't exist
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        //playerList = GameObject.FindGameObjectsWithTag("Player");
        itemPic.enabled = false;
        itemDesText.enabled = false;
        itemStatText.enabled = false;
        //Close all tab
        inventoryTab.SetActive(false);
        characterTab.SetActive(false);
        deckTab.SetActive(false);
        questTab.SetActive(false);
        equipmentBoxParent.SetActive(false);

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int openTab(int tabIndex)
    {
        int move = 0;
        clearInventory();
        clearEquipmentBox();
        clearDeckBox();
        //Find player
        playerList = new GameObject[0];
        playerList = GameObject.FindGameObjectsWithTag("Player");
        if (playerList.Length <= 0)
        {
            if (exploration_sceneManager.Instance != null)
            {
                playerList = exploration_sceneManager.Instance.playerPool.ToArray();
            }
                
        }
        switch (tabIndex)
        {
            case 0://Inventory
                changeReceiveTabColor(0);
                move = showInventoryTab();
                break;
            case 1:
                changeReceiveTabColor(1);
                move = showCharacterTab();
                break;
            case 2:
                changeReceiveTabColor(2);
                move = showCharacterDeck();
                break;
            case 3:
                changeReceiveTabColor(3);
                move = showQuestTab();
                break;
        }
        return move;
    }

    private int showInventoryTab()
    {
        int move = 0;
        if (inventoryTab.activeSelf)
        {
            closeAllTab();
            this.gameObject.SetActive(false); // CLose canas 
            move = 0;
        }
        else
        {
            this.gameObject.SetActive(true);
            closeAllTab();
            inventoryTab.SetActive(true);
            generateAllItem();
            move = 1;
        }
        return move;
    }
    private int showCharacterTab()
    {
        int move = 0;
        if (characterTab.activeSelf)
        {
            closeAllTab();
            this.gameObject.SetActive(false); // CLose canas 
            move = 0;
        }
        else
        {
            this.gameObject.SetActive(true);
            closeAllTab();
            characterTab.SetActive(true);
            characterIndex = 0;
            openCharacterTab();
            move = 1;
        }
        return move;
    }

    private int showCharacterDeck()
    {
        int move = 0;
        if (deckTab.activeSelf)
        {
            closeAllTab();
            this.gameObject.SetActive(false); // CLose canas 
            move = 0;
        }
        else
        {
            this.gameObject.SetActive(true);
            closeAllTab();
            deckTab.SetActive(true);
            characterIndex = 0;
            openCharacterDeck();
            move = 1;
        }
        return move;
    }

    private int showQuestTab()
    {
        int move = 0;
        if (questTab.activeSelf)
        {
            closeAllTab();
            this.gameObject.SetActive(false); // CLose canas 
            move = 0;
        }
        else
        {
            this.gameObject.SetActive(true);
            closeAllTab();
            questTab.SetActive(true);
            generateQuest();
            move = 1;
        }
        return move;
    }

    private void openCharacterTab()
    {
        equipmentBoxParent.SetActive(false);
        selectedEquipment = null;
        selectedEquipmentGO = null;
        Character player = playerList[characterIndex].GetComponent<Character>();
        portrait.sprite = playerList[characterIndex].GetComponentInChildren<Unit>().portrait;
        characterName.text = player.characterName;
        printCharacterStat(player, playerList[characterIndex].GetComponent<characterEquipment>());

    }

    private void printCharacterStat(Character player, characterEquipment playerEquipment)
    {
        string displayText = "MAX HP " + (player.maxHP + playerEquipment.bonusMAXHP).ToString()+"\n";
        displayText = displayText + "Current HP " + player.currentHP+"\n";
        displayText = displayText + "Attack power " + (player.baseATK + playerEquipment.bonusATK).ToString() + "\n";
        displayText = displayText + "Healing power " + (player.baseHeal + playerEquipment.bonusHEAL).ToString() + "\n";
        displayText = displayText + "Defend " + (player.basedefPoint + playerEquipment.bonusDEF).ToString()+"\n";
        displayText = displayText + "Resistance " + (player.baseResistance + playerEquipment.bonusResistance).ToString() + "\n";
        displayText = displayText + "Speed " + (player.baseSPD + playerEquipment.bonusSpeed + "\n");
        displayText = displayText + "Evade " + (player.baseEvade + playerEquipment.bonusEvade + "\n");
        displayText = displayText + "Crit rate " + (player.baseCritRate + playerEquipment.bonusCRITRATE + "\n");
        displayText = displayText + "Crit damage " + (player.baseCritDMG + /*playerEquipment.bonuscritd +*/ "\n");

        characterStat.text = displayText;
    }

    //Equipemntype - tell what is equipment type by 0 = Head, 1 = Armor, 2 = Acc
    public void openEquipmentBox(int eqIndex)
    {
        if (equipmentBoxParent.activeSelf != true)
            equipmentBoxParent.SetActive(true);

        equipmentType eqType = equipmentType.HEAD;
        switch (eqIndex)
        {
            case 0:
                eqType = equipmentType.HEAD;
                break;
            case 1:
                eqType = equipmentType.ARMORE;
                break;
            case 2:
                eqType = equipmentType.ACCESSORY;
                break;

        }
        clearEquipmentBox();
        List<GameObject> eqList = new List<GameObject>();
        eqList.AddRange(inventoryManager.Instance.equipmentList);
        Character player = playerList[characterIndex].GetComponent<Character>();
        characterEquipment playerEquiped = playerList[characterIndex].GetComponent<characterEquipment>();
        //Print old equip stat
        newEquipDes.text = "";
        newEquipStat.text = "";
        switch (eqType)
        {
            case equipmentType.HEAD when playerEquiped.head != null:
                oldEquipDes.text = playerEquiped.head.equipmentDes;
                oldEquipStat.text = printEquipStat(playerEquiped.head);
                break;
            case equipmentType.ARMORE when playerEquiped.armor != null:
                oldEquipDes.text = playerEquiped.armor.equipmentDes;
                oldEquipStat.text = printEquipStat(playerEquiped.armor);
                break;
            case equipmentType.ACCESSORY when playerEquiped.accessory != null:
                oldEquipDes.text = playerEquiped.accessory.equipmentDes;
                oldEquipStat.text = printEquipStat(playerEquiped.accessory);
                break;
            default:
                oldEquipDes.text = " ";
                oldEquipStat.text = " ";
                break;
        }
        printCharacterStat(player, playerList[characterIndex].GetComponent<characterEquipment>());
        //Create equipment
        foreach (GameObject equipmentGO in eqList)
        {
            if (equipmentGO.GetComponent<equipment>().equipmentType != eqType || equipmentGO.GetComponent<equipment>().isEquiped == true)
                continue;

            GameObject eq = Instantiate(equipmentGO, equipmentBox.transform);
            eq.GetComponent<equipment>().setEquipmentPic();
            eq.GetComponent<Image>().enabled = true;
            Button but = eq.GetComponent<Button>();
            if (but == null)
                eq.AddComponent<Button>();
            eq.GetComponent<Button>().onClick.RemoveAllListeners();
            eq.GetComponent<Button>().onClick.AddListener(() => printNewEquipmentStat(eq));
        }

    }
    private void printNewEquipmentStat(GameObject item)
    {
        equipment itemData = item.GetComponent<equipment>();
        newEquipDes.text = itemData.equipmentDes;
        newEquipStat.text = printEquipStat(itemData);
        selectedEquipment = itemData;
        selectedEquipmentGO = item;

    }

    private string printEquipStat(equipment item)
    {
        string outputString = "";
        string itemStat = item.equipmentName + "\n";
        itemStat = itemStat + ((item.ATK != 0) ? "ATK " + ((item.ATK > 0) ? "+ " : "- ") + Mathf.Abs(item.ATK).ToString() + "\n" : "");
        itemStat = itemStat + ((item.HP != 0) ? "HP " + ((item.HP > 0) ? "+ " : "- ") + Mathf.Abs(item.HP).ToString() + "\n" : "");
        itemStat = itemStat + ((item.DEF != 0) ? "DEF " + ((item.DEF > 0) ? "+ " : "- ") + Mathf.Abs(item.DEF).ToString() + "\n" : "");
        itemStat = itemStat + ((item.SPD != 0) ? "ATK " + ((item.SPD > 0) ? "+ " : "- ") + Mathf.Abs(item.SPD).ToString() + "\n" : "");
        itemStat = itemStat + ((item.CRITChance != 0) ? "Crit rate " + ((item.CRITChance > 0) ? "+ " : "- ") + Mathf.Abs(item.CRITChance).ToString() + "\n" : "");

        outputString = itemStat;
        return outputString;
    }

    public void equipThisItem()
    {
        if (selectedEquipment == null)
            return;

        characterEquipment playerEquiped = playerList[characterIndex].GetComponent<characterEquipment>();
        playerEquiped.equipEquipment(selectedEquipmentGO, selectedEquipment.equipmentType);
        selectedEquipmentGO.transform.SetParent(inventoryManager.Instance.equipmentContainer);
        //Reset UI
        switch (selectedEquipment.equipmentType)
        {
            case equipmentType.HEAD:
                headPic.sprite = selectedEquipment.pic;
                openEquipmentBox(0);
                break;
            case equipmentType.ARMORE:
                armorPic.sprite = selectedEquipment.pic;
                openEquipmentBox(1);
                break;
            case equipmentType.ACCESSORY:
                accPic.sprite = selectedEquipment.pic;
                openEquipmentBox(2);
                break;

        }
    }

    public void nextCharacter(int number)
    {
        characterIndex += number;
        if (characterIndex >= playerList.Length)
            characterIndex = 0;
        else if (characterIndex < 0)
            characterIndex = playerList.Length -1;
        openCharacterTab();
    }

    public void nextDeck(int number)
    {
        characterIndex += number;
        if (characterIndex >= playerList.Length)
            characterIndex = 0;
        else if (characterIndex < 0)
            characterIndex = playerList.Length - 1;
        openCharacterDeck();
    }

    private void openCharacterDeck()
    {
        clearDeckBox();
        Character player = playerList[characterIndex].GetComponent<Character>();
        characterDeckPortrait.sprite = playerList[characterIndex].GetComponentInChildren<Unit>().portrait;
        //Generate card
        playerList[characterIndex].GetComponent<cardHandler>().showDeckList(deckBox);

    }


    private void closeAllTab()
    {
        itemPic.enabled = false;
        itemDesText.enabled = false;
        itemStatText.enabled = false;
        equipmentBoxParent.SetActive(false);
        characterTab.SetActive(false);
        inventoryTab.SetActive(false);
        deckTab.SetActive(false);
        questTab.SetActive(false);
        questDetail.SetActive(false);

    }

    private void generateAllItem()
    {
        clearInventory();
        List<GameObject> eqList = new List<GameObject>();
        eqList.AddRange(inventoryManager.Instance.equipmentList);
        foreach (GameObject equipmentGO in eqList)
        {
            GameObject eq = Instantiate(equipmentGO, inventoryScreen.transform);
            eq.GetComponent<equipment>().setEquipmentPic();
            Button but = eq.GetComponent<Button>();
            if (but == null)
                eq.AddComponent<Button>();
            eq.GetComponent<Button>().onClick.RemoveAllListeners();
            eq.GetComponent<Button>().onClick.AddListener(() => showItemDescription(eq.GetComponent<equipment>()));
            
        }
        moneyText.text = "Money : " + inventoryManager.Instance.money.ToString();
    }

    private void clearInventory()
    {
        foreach (Transform child in inventoryScreen.transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void clearEquipmentBox()
    {
        foreach (Transform child in equipmentBox.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void clearDeckBox()
    {
        foreach (Transform child in deckBox.transform)
        {
            Destroy(child.gameObject);
        }
    }


    private void showItemDescription(equipment item)
    {
        itemPic.enabled = true;
        itemDesText.enabled = true;
        itemStatText.enabled = true;

        itemPic.sprite = item.pic;
        itemDesText.text = item.equipmentDes;
        string itemStat = item.equipmentName + "\n";
        itemStat = itemStat + ((item.ATK != 0) ? "ATK " + ((item.ATK > 0) ? "+ " : "- ") + Mathf.Abs(item.ATK).ToString() + "\n" : "");
        itemStat = itemStat + ((item.HP != 0) ? "HP " + ((item.HP > 0) ? "+ " : "- ") + Mathf.Abs(item.HP).ToString() + "\n" : "");
        itemStat = itemStat + ((item.DEF != 0) ? "DEF " + ((item.DEF > 0) ? "+ " : "- ") + Mathf.Abs(item.DEF).ToString() + "\n" : "");
        itemStat = itemStat + ((item.SPD != 0) ? "ATK " + ((item.SPD > 0) ? "+ " : "- ") + Mathf.Abs(item.SPD).ToString() + "\n" : "");
        itemStat = itemStat + ((item.CRITChance != 0) ? "Crit rate " + ((item.CRITChance > 0) ? "+ " : "- ") + Mathf.Abs(item.CRITChance).ToString() + "\n" : "");

        itemStatText.text = itemStat;

    }

    public void forceClose()
    {
        inventoryTab.SetActive(false);
        characterTab.SetActive(false);
        deckTab.SetActive(false);
        this.gameObject.SetActive(false);
    }

    // Quest
    private void generateQuest()
    {
        questDetail.SetActive(false);
        clearQuestContainer();

        foreach (quest q in inventoryManager.Instance.questList)
        {
            GameObject eq = Instantiate(questButtonPrefab, questContainer.transform);
            Button but = eq.GetComponent<Button>();
            but.onClick.RemoveAllListeners();
            but.onClick.AddListener(() => printCompleteQuestDetail(q));
            eq.GetComponentInChildren<TextMeshProUGUI>().text = q.questName;
        }
    }
    private void clearQuestContainer()
    {
        foreach (Transform child in questContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void printCompleteQuestDetail(quest thisQuest)
    {
        questDetail.SetActive(true);
        questName.text = thisQuest.questName;
        questDescription.text = thisQuest.questDescription;
        if (thisQuest.isComplete)
            questStatus.text = "Status : Complete";
        else
            questStatus.text = "Status : Not complete";
    }

    //Navbar

    public void changeTabButton(int tab)
    {
        openTab(tab);
    }

    private void changeReceiveTabColor(int tabIndex)
    {
        int i = 0;
        foreach (GameObject button in buttonNavbar)
        {
            ColorBlock sendcolorBlock = button.GetComponent<Button>().colors;
            sendcolorBlock.normalColor = new Color(255f, 255f, 255f, 0.5f);
            button.GetComponent<Button>().colors = sendcolorBlock;

            if (i == tabIndex)
            {
                ColorBlock colorBlock = button.GetComponent<Button>().colors;
                colorBlock.normalColor = new Color(255f, 255f, 255f, 1f);
                button.GetComponent<Button>().colors = colorBlock;
            }

            i++;
        }
    }

}
