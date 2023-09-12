using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChangeCharacterEquipSlot : MonoBehaviour
{
    public GameObject FirstCharacter;
    public GameObject SeccondCharacter;
    public Button myButton;
    public TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {
        myButton.onClick.AddListener(ChangeCharacterSlot);
    }

    // Update is called once per frame
    private void ChangeCharacterSlot()
    { if (FirstCharacter.activeSelf)
        {
            FirstCharacter.SetActive(false);
            SeccondCharacter.SetActive(true);
            buttonText.text = "SeccondCharacter";
        }
        else if(SeccondCharacter.activeSelf)
        {
            FirstCharacter.SetActive(true);
            SeccondCharacter.SetActive(false);
            buttonText.text = "FirstCharacter";
        }
        
    }
}
