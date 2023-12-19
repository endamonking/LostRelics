using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healOneCha : nodeEfffect
{
    [SerializeField]
    private Button buttonPrefab;
    [SerializeField]
    private string nodeName, description;
    [SerializeField]
    private int amount = 30;
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
            ansBut.onClick.AddListener(() => healOneCharacter(player.GetComponent<Character>()));
            i = i - 100;
            exploration_sceneManager.Instance.answerButtonList.Add(ansBut);
        }
        exploration_sceneManager.Instance.updateEventCanvas(nodeName, description);

    }

    private void healOneCharacter(Character pCha)
    {
        pCha.currentHP = pCha.currentHP + amount;
        if (pCha.currentHP >= pCha.inComMaxHP)
            pCha.currentHP = pCha.inComMaxHP;
        base.closeEvenCanvas();
    }

}
