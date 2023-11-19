using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestBoard : MonoBehaviour, IsInteractable
{

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public DialogControl _dialogControl;



    [SerializeField] private GameObject _QuestUI;
    [SerializeField] private GameObject player;
    public Quest[] questList;
    public GameObject buttonPrefab;

    private void Start()
    {
        _QuestUI.SetActive(false);
        Transform detail = _QuestUI.transform.Find("Detail");
        detail.gameObject.SetActive(false);
    }
    public bool Interact(Interactor interactor)
    {
 
 
        if (_QuestUI.activeSelf)
        {

            _QuestUI.SetActive(false);
            player.GetComponent<PlayerControl>().enabled = true;
        }
        else
        {
            _QuestUI.SetActive(true);
            StartQuestUI(questList);
            player.GetComponent<PlayerControl>().enabled = false;
        }

        return true;
    }

    private void StartQuestUI(Quest[] quest)
    {
        Transform content = _QuestUI.transform.Find("Choice/Content");

        if (content != null)
        {
            foreach (Transform child in content.transform)
            {
                Destroy(child.gameObject);
            }
             
            for (int i = 0; i < questList.Length; i++)
            {
                Quest currentQuest = questList[i];

                GameObject newButton = Instantiate(buttonPrefab, content);

                Button buttonComponent = newButton.GetComponent<Button>();
                if (buttonComponent != null)
                {
                    // Change the button text
                    buttonComponent.GetComponentInChildren<TMP_Text>().text = questList[i].name;

                    // Add an event listener to each button
                    buttonComponent.onClick.AddListener(() => SetQuestDetail(currentQuest   ));
                }
            }
        }

    }

    private void SetQuestDetail(Quest quest)
    {
       
        Transform detail = _QuestUI.transform.Find("Detail");
        detail.gameObject.SetActive(true);

        Transform description = detail.Find("Description");
        TMP_Text descriptionTextMeshPro = description.GetComponent<TMP_Text>();
        descriptionTextMeshPro.text = quest.description;
        Transform button = detail.transform.Find("Accept");
        Button buttonComponent = button.GetComponent<Button>();
        if (quest.active == 1)
        { 
            buttonComponent.gameObject.SetActive(false); 
             PlayerControl playerControl = player.GetComponent<PlayerControl>();
            playerControl.AddQuest(quest);
        }
        buttonComponent.onClick.AddListener(() => OnAcceptButtonClicked(quest, buttonComponent)); 
    }
    private void OnAcceptButtonClicked(Quest quest,Button buttonComponent)
    {

        PlayerControl playerControl = player.GetComponent<PlayerControl>();
        quest.active = 1;
        playerControl.AddQuest(quest);
        buttonComponent.gameObject.SetActive(false);
    }
}
