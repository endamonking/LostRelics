using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    public static inventoryManager Instance;
    public int money = 0;

    public List<GameObject> eqListPRefab;
    public List<GameObject> equipmentList = new List<GameObject>();
    [Header("Equipment")]
    public GameObject headGO;
    public GameObject armorGO;
    public GameObject accGO;
    public Transform equipmentContainer;

    [Header("UI")]
    public GameObject playerCanvas;
    [Header("Quest")]
    public List<quest> questList = new List<quest>();
    public GameObject questContainer;


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
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject GO in eqListPRefab)
        {
            GameObject eq = Instantiate(GO, this.gameObject.transform);
            equipmentList.Add(eq);

        }
        updatelistIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatelistIndex()
    {
        int i = 0;
        foreach (GameObject GO in equipmentList)
        {
            GO.GetComponent<equipment>().equipmentIndexInList = i;
            i++;
        }
    }

    public void updateEquiped(int index, bool isThisEquiped)
    {
        equipmentList[index].GetComponent<equipment>().isEquiped = isThisEquiped;
    }

    public void removeItem(int Index)
    {
        GameObject go = equipmentList[Index];
        equipmentList.RemoveAt(Index);
        Destroy(go);
        updatelistIndex();
    }

    public void removeMultipleItems(List<int> IndexList)
    {
        IndexList.Sort((a, b) => b.CompareTo(a));
        foreach (int index in IndexList)
        {
            if (index >= 0 && index < equipmentList.Count)
            {
                Destroy(equipmentList[index]);
                equipmentList.RemoveAt(index);
            }
            else
            {
                Debug.LogWarning("Index out of range: " + index);
            }
        }
        updatelistIndex();
    }

    //use to add item to Iventory by set parent of gameobject
    //So the new item must be new Gameobject Example (GameObject eq = Instantiate(equipmentGO, otherGO.transform))
    
    public void addItem (GameObject newItem)
    {
        equipmentList.Add(newItem);
        newItem.transform.SetParent(this.gameObject.transform);
        updatelistIndex();
    }

    public void addItemWithOutReParent(GameObject newItem)
    {
        equipmentList.Add(newItem);
        updatelistIndex();
    }
    public void addMoney(int amount)
    {
        money = money + amount;
        if (money <= 0)
            money = 0;
    }

    //Quest
    public void doKillQuest(string targetName)
    {
        foreach (quest q in questList)
        {
            if (q is killEnemyQuest)
            {
                killEnemyQuest thisQuest = (killEnemyQuest)q;
                thisQuest.fullfillCondition(targetName);
            }
        }
    }

    public void addQuest(quest newQuest)
    {
        quest copiedQuest = Instantiate(newQuest, questContainer.transform);
        questList.Add(copiedQuest);
    }

    public void removeQuest(quest newQuest)
    {
        questList.Remove(newQuest);
    }

    //UI
    public void closePlayerCanvas()
    {
        playerCanvas.GetComponent<inventoryCanvas>().forceClose();
    }
    public void destroyME()
    {
        Destroy(gameObject);
    }
    
    public List<GameObject> getNonEquipedLsit()
    {
        List<GameObject> eqList = new List<GameObject>();
        eqList.AddRange(equipmentList);
        for (int i = 0; i < eqList.Count; i++)
        {
            equipment item = eqList[i].GetComponent<equipment>();
            if (item.isEquiped == true)
            {
                eqList.RemoveAt(i);
            }
        }


        return eqList;
    }

}
