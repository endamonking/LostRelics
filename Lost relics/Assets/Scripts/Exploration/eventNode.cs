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
        foreach (string answer in answerList)
        {
            Button ansBut = Instantiate(buttonPrefab, exploration_sceneManager.Instance.answerContainer);
            Vector3 position = new Vector3(0, i, 0);
            ansBut.GetComponentInChildren<TextMeshProUGUI>().text = answer;
            ansBut.GetComponent<RectTransform>().anchoredPosition = position;
            ansBut.onClick.AddListener(nodeEffect);
            i = i - 100;
            buttonList.Add(ansBut);
        }
        exploration_sceneManager.Instance.updateEventCanvas(nodeName, description);
    }

    private void nodeEffect()
    {
        foreach (Button thisButton in buttonList)
            Destroy(thisButton.gameObject);
        exploration_sceneManager.Instance.EventCanvas.SetActive(false);
        exploration_sceneManager.Instance.isEvent = false;
    }

}
