using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class addSpeed : nodeEfffect
{
    [SerializeField]
    private Button buttonPrefab;
    [SerializeField]
    private string nodeName, description;
    [SerializeField]
    private int speedAmount = 2;
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
        List<GameObject> playersCha = exploration_sceneManager.Instance.playerPool;
        int i = 0;
        foreach (GameObject player in playersCha)
        {
            Button ansBut = Instantiate(buttonPrefab, exploration_sceneManager.Instance.answerContainer);
            Vector3 position = new Vector3(0, i, 0);
            ansBut.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Character>().characterName;
            ansBut.GetComponent<RectTransform>().anchoredPosition = position;
            ansBut.onClick.AddListener(() => addSpeedToCharacter(player.GetComponent<Character>()));
            i = i - 100;
            exploration_sceneManager.Instance.answerButtonList.Add(ansBut);
        }
    }

    private void addSpeedToCharacter(Character pCha)
    {
        pCha.baseSPD += speedAmount;
        base.closeEvenCanvas();
    }

}
