using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class randomSellItem : nodeEfffect
{
    [SerializeField]
    private Button buttonPrefab;
    [SerializeField]
    private string nodeName, description;
    [SerializeField]
    private int amount = 1;

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
        //if (Not met requirment item)
        inventoryManager playerInventory = GameObject.FindObjectOfType<inventoryManager>();
        if (playerInventory.equipmentList.Count < amount)
        {
            exploration_sceneManager.Instance.clearEventButton();
            Button ansBut = Instantiate(buttonPrefab, exploration_sceneManager.Instance.answerContainer);
            Vector3 position = new Vector3(0, 0, 0);
            ansBut.GetComponentInChildren<TextMeshProUGUI>().text = "Walk away";
            ansBut.GetComponent<RectTransform>().anchoredPosition = position;
            ansBut.onClick.AddListener(skipBut);
            exploration_sceneManager.Instance.answerButtonList.Add(ansBut);
            exploration_sceneManager.Instance.updateEventCanvas(nodeName, description);
        }
        else
        {
            removeItemAndGetMoney(playerInventory.equipmentList);
        }


    }

    private void skipBut()
    {
        base.closeEvenCanvas();
    }

    private void removeItemAndGetMoney(List<GameObject> playerInventory)
    {
        for (int i = 0; i < amount; i++)
        {
            int ranIndex = Random.Range(0, playerInventory.Count);
            //Debug.Log(playerInventory[ranIndex].itemName);
            playerInventory.RemoveAt(ranIndex);
        }
        base.closeEvenCanvas();
    }

}
