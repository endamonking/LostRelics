using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ChangeInventoryToCard : MonoBehaviour
{
    public GameObject inventory;
    public GameObject card;
    public Button myButton;
 
    // Start is called before the first frame update
    void Start()
    {
        myButton.onClick.AddListener(ChangeInventoryScreen);
    }

    // Update is called once per frame
    private void ChangeInventoryScreen()
    {
        if(inventory.activeSelf)
        {
            card.SetActive(true);
            inventory.SetActive(false);
            
        }
        else if(card.activeSelf)
        {
            card.SetActive(false);
            inventory.SetActive(true);

          
        }

    }
}
