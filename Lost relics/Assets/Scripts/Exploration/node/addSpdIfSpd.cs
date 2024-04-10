using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class addSpdIfSpd : nodeEfffect
{
    [SerializeField]
    private Button buttonPrefab;
    [SerializeField]
    private string nodeName, description;
    [SerializeField]
    private int speedAmount = 5, speedCondition = 30;
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
        exploration_sceneManager.Instance.clearEventButton();
        List<GameObject> characterMetCon = new List<GameObject>();
        List<GameObject> playersCha = exploration_sceneManager.Instance.playerPool;
        foreach (GameObject character in playersCha)
        {
            if (character.GetComponent<Character>().inComSPD >= speedCondition)
                characterMetCon.Add(character);
        }
        int i = 0;
        foreach (GameObject player in characterMetCon)
        {
            Button ansBut = Instantiate(buttonPrefab, exploration_sceneManager.Instance.answerContainer);
            Vector3 position = new Vector3(0, i, 0);
            ansBut.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Character>().characterName;
            ansBut.GetComponent<RectTransform>().anchoredPosition = position;
            ansBut.onClick.AddListener(() => addSpeedToCharacter(player.GetComponent<Character>()));
            i = i - 100;
            exploration_sceneManager.Instance.answerButtonList.Add(ansBut);
        }
        //Skipp but
        Button skippBut = Instantiate(buttonPrefab, exploration_sceneManager.Instance.answerContainer);
        Vector3 skippPosition = new Vector3(0, i, 0);
        skippBut.GetComponentInChildren<TextMeshProUGUI>().text = "No one can do it";
        skippBut.GetComponent<RectTransform>().anchoredPosition = skippPosition;
        skippBut.onClick.AddListener(skipBut);
        i = i - 100;
        exploration_sceneManager.Instance.answerButtonList.Add(skippBut);
    }

    private void addSpeedToCharacter(Character pCha)
    {
        pCha.baseSPD += speedAmount;
        base.closeEvenCanvas();
    }

    private void skipBut()
    {
        base.closeEvenCanvas();
    }

}
