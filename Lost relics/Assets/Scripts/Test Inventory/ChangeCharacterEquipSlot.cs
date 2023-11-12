using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChangeCharacterEquipSlot : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject character_slot_1;
    [SerializeField] private GameObject character_slot_2;
    [SerializeField] private GameObject character_slot_3;
    [SerializeField] private GameObject character_slot_4;
    [SerializeField] private Button button_1;
    [SerializeField] private Button button_2;
    [SerializeField] private Button button_3;
    [SerializeField] private Button button_4;
    [SerializeField] private Image uiImage;
    // Start is called before the first frame update
    void Start()
    {
      
        
        button_1.onClick.AddListener(ChangeTo1);
        button_2.onClick.AddListener(ChangeTo2);
        button_3.onClick.AddListener(ChangeTo3);
        button_4.onClick.AddListener(ChangeTo4);
        ChangeTo1();
    }
     
    // Update is called once per frame
    private void ChangeTo1()
    {
        Transform spriteTransform = player.transform.Find("Sprite");
        Transform char1 = spriteTransform.Find("Char_1");
        if(char1 != null)
        {
            SpriteRenderer spriteRenderer = char1.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
           
                Sprite sprite = spriteRenderer.sprite;

                 
                uiImage.sprite = sprite;
            }

        }
        character_slot_1.SetActive(true);
        character_slot_2.SetActive(false);
        character_slot_3.SetActive(false);
        character_slot_4.SetActive(false);
     

    }
    private void ChangeTo2()
    {
        Transform spriteTransform = player.transform.Find("Sprite");
        Transform char2 = spriteTransform.Find("Char_2");
        if (char2 != null)
        {
            SpriteRenderer spriteRenderer = char2.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {

                Sprite sprite = spriteRenderer.sprite;


                uiImage.sprite = sprite;
            }

        }
    
        character_slot_1.SetActive(false);
        character_slot_2.SetActive(true);
        character_slot_3.SetActive(false);
        character_slot_4.SetActive(false);
      

    }
    private void ChangeTo3()
    {
        Transform spriteTransform = player.transform.Find("Sprite");
        Transform char3 = spriteTransform.Find("Char_3");
        if (char3 != null)
        {
            SpriteRenderer spriteRenderer = char3.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {

                Sprite sprite = spriteRenderer.sprite;


                uiImage.sprite = sprite;
            }

        }
      
        character_slot_1.SetActive(false);
        character_slot_2.SetActive(false);
        character_slot_3.SetActive(true);
        character_slot_4.SetActive(false);
        

    }
    private void ChangeTo4()
    {
        Transform spriteTransform = player.transform.Find("Sprite");
        Transform char4 = spriteTransform.Find("Char_4");
        if (char4 != null)
        {
            SpriteRenderer spriteRenderer = char4.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {

                Sprite sprite = spriteRenderer.sprite;


                uiImage.sprite = sprite;
            }

        }
       
        character_slot_1.SetActive(false);
        character_slot_2.SetActive(false);
        character_slot_3.SetActive(false);
        character_slot_4.SetActive(true);
     

    }
}
