using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventoryCanvas : MonoBehaviour
{
    public GameObject[] playerList;

    public GameObject inventoryScreen;
    [Header("Inventory UI")]
    public Image itemPic;
    public TextMeshProUGUI itemDesText;
    public TextMeshProUGUI itemStatText;

    // Start is called before the first frame update
    void Start()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        itemPic.enabled = false;
        itemDesText.enabled = false;
        itemStatText.enabled = false;

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showInventory()
    {
        if (this.gameObject.activeSelf)
        {
            itemPic.enabled = false;
            itemDesText.enabled = false;
            itemStatText.enabled = false;
            this.gameObject.SetActive(false);

        }
        else
        {
            this.gameObject.SetActive(true);
            generateAllItem();
        }
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
