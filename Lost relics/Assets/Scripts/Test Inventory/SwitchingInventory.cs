using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingInventory : MonoBehaviour
{
    [SerializeField] private Button button_1;
    [SerializeField] private Button button_2;
 
    [SerializeField] private GameObject equipment;
    [SerializeField] private GameObject deck;
    // Start is called before the first frame update
    void Start()
    {
        button_1.onClick.AddListener(OpenEquipment);
        button_2.onClick.AddListener(OpenDeck);
        equipment.SetActive(true);

    }

    // Update is called once per frame
    void OpenEquipment()
    {
        if (deck.activeSelf) {
            deck.SetActive(false);
            equipment.SetActive(true);
        }
        
         
    }

    void OpenDeck()
    {
        if (equipment.activeSelf)
        {
            equipment.SetActive(false);
            deck.SetActive(true);
        }
    }
}
