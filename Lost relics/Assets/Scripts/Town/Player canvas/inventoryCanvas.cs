using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventoryCanvas : MonoBehaviour
{
    public GameObject[] playerList;

    [Header("Tab")]
    public GameObject inventoryTab;
    public GameObject characterTab;
    [Header("Inventory UI")]
    public GameObject inventoryScreen; 
    public Image itemPic;
    public TextMeshProUGUI itemDesText;
    public TextMeshProUGUI itemStatText;
    [Header("Character UI")]
    public Image portrait;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterStat;

    private int characterIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        itemPic.enabled = false;
        itemDesText.enabled = false;
        itemStatText.enabled = false;
        //Close all tab
        inventoryTab.SetActive(false);
        characterTab.SetActive(false);

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int openTab(int tabIndex)
    {
        int move = 0;
        switch (tabIndex)
        {
            case 0://Inventory
                move = showInventoryTab();
                break;
            case 1:
                move = showCharacterTab();
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

    private void openCharacterTab()
    {
        Character player = playerList[characterIndex].GetComponent<Character>();
        portrait.sprite = playerList[characterIndex].GetComponentInChildren<SpriteRenderer>().sprite;
        characterName.text = player.characterName;
        printCharacterStat(player, playerList[characterIndex].GetComponent<characterEquipment>());

    }

    private void printCharacterStat(Character player, characterEquipment playerEquipment)
    {
        string displayText = "MAX HP " + (player.maxHP + playerEquipment.bonusMAXHP).ToString()+"\n";
        displayText = displayText + "Current HP " + player.currentHP+"\n";
        displayText = displayText + "Attack power " + player.baseATK + "\n";
        displayText = displayText + "Defend " + (player.basedefPoint + playerEquipment.bonusDEF).ToString()+"\n";
        displayText = displayText + "Speed " + (player.baseSPD + playerEquipment.bonusSpeed);

        characterStat.text = displayText;
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

    private void closeAllTab()
    {
        itemPic.enabled = false;
        itemDesText.enabled = false;
        itemStatText.enabled = false;
        characterTab.SetActive(false);
        inventoryTab.SetActive(false);
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
            eq.AddComponent<Button>();
            eq.GetComponent<Button>().onClick.AddListener(() => showItemDescription(eq.GetComponent<equipment>()));
            
        }
    }

    private void clearInventory()
    {
        foreach (Transform child in inventoryScreen.transform)
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
        string itemStat = (item.HP > 0) ? ("HP + " +item.HP.ToString() + "\n") : "";

        itemStat = itemStat + ((item.DEF > 0) ? ("DEF + " + item.DEF.ToString() + "\n") : "");
        itemStat = itemStat + ((item.SPD > 0) ? ("SPD + " + item.SPD.ToString() + "\n") : "");
        itemStat = itemStat + ((item.CRITChance > 0) ? ("Crit chance + " + item.CRITChance.ToString() + "%\n") : "");

        itemStatText.text = itemStat;



    }

}
