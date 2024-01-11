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
        equipmentBoxParent.SetActive(false);
        selectedEquipment = null;
        selectedEquipmentGO = null;
        Character player = playerList[characterIndex].GetComponent<Character>();
        portrait.sprite = playerList[characterIndex].GetComponentInChildren<SpriteRenderer>().sprite;
        characterName.text = player.characterName;
        printCharacterStat(player, playerList[characterIndex].GetComponent<characterEquipment>());
        //


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
            eq.AddComponent<Button>();
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
        string itemStat = (item.HP > 0) ? ("HP + " + item.HP.ToString() + "\n") : "";

        itemStat = itemStat + ((item.DEF > 0) ? ("DEF + " + item.DEF.ToString() + "\n") : "");
        itemStat = itemStat + ((item.SPD > 0) ? ("SPD + " + item.SPD.ToString() + "\n") : "");
        itemStat = itemStat + ((item.CRITChance > 0) ? ("Crit chance + " + item.CRITChance.ToString() + "%\n") : "");

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

    private void closeAllTab()
    {
        itemPic.enabled = false;
        itemDesText.enabled = false;
        itemStatText.enabled = false;
        equipmentBoxParent.SetActive(false);
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
    private void clearEquipmentBox()
    {
        foreach (Transform child in equipmentBox.transform)
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
