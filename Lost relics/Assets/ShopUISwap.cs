using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUISwap : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject shoppingListUI;
    [SerializeField] private GameObject purchaseButton;
    private TMP_Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        inventoryUI.SetActive(false);

        buttonText = GetComponentInChildren<TMP_Text>();

        buttonText.text = "Sell";
        GetComponent<Button>().onClick.AddListener(Swap);
    }

    // Update is called once per frame
    void Swap()
    {
        if (inventoryUI.activeSelf)
        {
            buttonText.text = "Sell";
            inventoryUI.SetActive(false);
            shoppingListUI.SetActive(true);
            purchaseButton.SetActive(true);

        }
        else {
            purchaseButton.SetActive(false);
            buttonText.text = "Purchase";
            inventoryUI.SetActive(true);
            shoppingListUI.SetActive(false);
        }
    }
}
