using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class eventNode : node
{
    [SerializeField]
    private string nodeName, description;
    [SerializeField]
    private List<string> answerList = new List<string>();
    [SerializeField]
    private List<nodeEfffect> asnwerEffectList = new List<nodeEfffect>();
    [SerializeField]
    private Button buttonPrefab;
    private List<Button> buttonList = new List<Button>();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnMouseDown()
    {
        if (exploration_sceneManager.Instance.isLerping == true || exploration_sceneManager.Instance.isEvent == true)
            return;

        if (exploration_sceneManager.Instance.playerLocation.nextNode.Contains(this))
        {
            base.OnMouseDown();
            StartCoroutine(lerpingNode(1));

            doEventNode();
        }
    }

    private void doEventNode()
    {
        exploration_sceneManager.Instance.isEvent = true;
        int i = 0;
        int effectIndex = 0;
        exploration_sceneManager.Instance.answerButtonList.Clear();
        foreach (string answer in answerList)
        {
            Button ansBut = Instantiate(buttonPrefab, exploration_sceneManager.Instance.answerContainer);
            Vector3 position = new Vector3(0, i, 0);
            ansBut.GetComponentInChildren<TextMeshProUGUI>().text = answer;
            ansBut.GetComponent<RectTransform>().anchoredPosition = position;
            ansBut.onClick.AddListener(asnwerEffectList[effectIndex].doEffect);
            i = i - 100;
            exploration_sceneManager.Instance.answerButtonList.Add(ansBut);
            effectIndex++;
        }
        exploration_sceneManager.Instance.updateEventCanvas(nodeName, description);
    }


}
