using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class shopManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject shopCanvas;
    public GameObject shopItemContainer;
    public GameObject itemDescriptionTab;
    public TextMeshProUGUI playerMoney;
    public Image itemPic;
    public TextMeshProUGUI itemDesText;
    public TextMeshProUGUI itemStatText;
    public TextMeshProUGUI itemPrice;

    [Header("Item")]
    public int totalItemsInshop = 9; //Note that this can be randomize but rn make it static
    public List<GameObject> bronzeItem;
    public List<GameObject> silverItem;
    public List<GameObject> goldItem;
    public List<GameObject> itemsInShop;
    public GameObject selectedItem;
    public int itemIndexInList = -1;

    private bool isPlayerNear = false;
    private bool isOpen = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        shopCanvas.SetActive(false);
        itemDescriptionTab.SetActive(false);
        addItemToShop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerNear == true)
        {
            inventoryManager.Instance.closePlayerCanvas();
            doShop();
        }

    }
    // bronze = 5
    // Silver = 3
    // gold = 1;
    private void addItemToShop()
    {
        //For nice looking if not 3 loop it will not nice looking
        int i = 0;
        while (i < 5) // Bronze
        {
            int randomIndex1 = Random.Range(0, bronzeItem.Count);
            itemsInShop.Add(bronzeItem[randomIndex1]);
            i++;
        }
        i = 0;
        while (i < 3) // Bronze
        {
            int randomIndex2 = Random.Range(0, silverItem.Count);
            itemsInShop.Add(silverItem[randomIndex2]);
            i++;
        }
        //Gold
        int randomIndex = Random.Range(0, goldItem.Count);
        itemsInShop.Add(goldItem[randomIndex]);
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

    private void doShop()
    {
        if (isOpen)
            closeShop();
        else
            openShop();
    }

    private void openShop()
    {
        selectedItem = null;
        itemIndexInList = -1;
        isOpen = true;
        player.GetComponent<PlayerControl>().stopPlaterMovement();
        shopCanvas.SetActive(true);
        playerMoney.text = "Money : " + inventoryManager.Instance.money.ToString(); 
        generateItem();
    }

    private void closeShop()
    {
        selectedItem = null;
        itemIndexInList = -1;
        shopCanvas.SetActive(false);
        itemDescriptionTab.SetActive(false);
        itemPic.enabled = false;
        itemDesText.enabled = false;
        itemStatText.enabled = false;
        player.GetComponent<PlayerControl>().resumePlaterMovement();
        isOpen = false;
    }

    private void generateItem()
    {
        clearItemInContainer();
        int i = 0;
        foreach (GameObject equipmentGO in itemsInShop)
        {
            GameObject eq = Instantiate(equipmentGO, shopItemContainer.transform);
            eq.GetComponent<equipment>().setEquipmentPic();
            //Add index
            eq.AddComponent<sellItemIndex>().itemInListIndex = i;
            Button but = eq.GetComponent<Button>();
            if (but == null)
                eq.AddComponent<Button>();
            eq.GetComponent<Button>().onClick.RemoveAllListeners();
            eq.GetComponent<Button>().onClick.AddListener(() => chooseThisItem(eq.GetComponent<equipment>()));
            eq.GetComponent<Button>().onClick.AddListener(() => selectThisItem(eq));
            i++;
        }
    }


    private void chooseThisItem(equipment item)
    {
        itemDescriptionTab.SetActive(true);
        itemPic.enabled = true;
        itemDesText.enabled = true;
        itemStatText.enabled = true;

        itemPic.sprite = item.pic;
        itemDesText.text = item.equipmentDes;
        itemPrice.text = item.value.ToString();
        string itemStat = item.equipmentName + "\n";
        itemStat = itemStat + ((item.ATK != 0) ? "ATK " + ((item.ATK > 0) ? "+ " : "- ") + Mathf.Abs(item.ATK).ToString() + "\n" : "");
        itemStat = itemStat + ((item.HP != 0) ? "HP " + ((item.HP > 0) ? "+ " : "- ") + Mathf.Abs(item.HP).ToString() + "\n" : "");
        itemStat = itemStat + ((item.DEF != 0) ? "DEF " + ((item.DEF > 0) ? "+ " : "- ") + Mathf.Abs(item.DEF).ToString() + "\n" : "");
        itemStat = itemStat + ((item.SPD != 0) ? "SPD " + ((item.SPD > 0) ? "+ " : "- ") + Mathf.Abs(item.SPD).ToString() + "\n" : "");
        itemStat = itemStat + ((item.CRITChance != 0) ? "Crit rate " + ((item.CRITChance > 0) ? "+ " : "- ") + Mathf.Abs(item.CRITChance).ToString() + "\n" : "");
        itemStat = itemStat + ((item.HEAL != 0) ? "HEAL " + ((item.HEAL > 0) ? "+ " : "- ") + Mathf.Abs(item.HEAL).ToString() + "\n" : "");
        itemStat = itemStat + ((item.RESISTANCE != 0) ? "RES " + ((item.HEAL > 0) ? "+ " : "- ") + Mathf.Abs(item.RESISTANCE).ToString() + "\n" : "");

        itemStatText.text = itemStat;

    }

    private void selectThisItem(GameObject thisEq)
    {
        selectedItem = thisEq;

    }

    private void clearItemInContainer()
    {
        foreach (Transform child in shopItemContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void buyItem()
    {
        if (selectedItem == null)
            return;

        if (inventoryManager.Instance.money >= selectedItem.GetComponent<equipment>().value)
        {
            //- because it buy
            inventoryManager.Instance.addMoney(-selectedItem.GetComponent<equipment>().value);
            inventoryManager.Instance.addItem(selectedItem);
            itemsInShop.RemoveAt(selectedItem.GetComponent<sellItemIndex>().itemInListIndex);
            Destroy(selectedItem.GetComponent<sellItemIndex>());
            openShop();
        }
    }

}
