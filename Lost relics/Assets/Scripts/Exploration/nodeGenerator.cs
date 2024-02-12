using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeGenerator : MonoBehaviour
{
    public int maxNodeLayer = 10;

    [SerializeField]
    private List<GameObject> eventNodePrefab = new List<GameObject>();
    [SerializeField]
    private List<GameObject> monsterNodePrefab = new List<GameObject>();
    [SerializeField]
    private List<GameObject> startNodePrefab;
    [SerializeField]
    private List<GameObject> bossNodePrefab;

    private Dictionary<int, List<node>> nodeList = new Dictionary<int, List<node>>();
    [SerializeField]
    private explorationCam explorCam;

    // Start is called before the first frame update
    void Start()
    {
        createMap();
        connectNode();
        explorCam.initMinCam(nodeList[0][0].position);
        explorCam.initMaxCam(nodeList[maxNodeLayer][0].position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generateNode(int numNodeInLayer, int layer, List<GameObject> nodePrefab)
    {
        int verticalLayer = 0;

        for (int i = 0; i < numNodeInLayer; i++)
        {
            Vector3 newPosition = new Vector3(layer * 3, verticalLayer * 1.5f * Mathf.Pow(-1,i) , 0);
            GameObject node = Instantiate(nodePrefab[Random.Range(0,nodePrefab.Count)], newPosition, Quaternion.identity);
            node.name = "Node " + i.ToString() + " Layer " + layer.ToString();
            node.GetComponent<node>().position = newPosition;
            addList(layer, node.GetComponent<node>());
            if (i % 2 == 0)
                verticalLayer++;

        }
    }
    private void generateNode(int numNodeInLayer, int layer, List<GameObject> eventNodePrefab, List<GameObject> monsterNodePrefab)
    {
        int verticalLayer = 0;

        for (int i = 0; i < numNodeInLayer; i++)
        {
            GameObject nodePrefab = new GameObject();
            int randType = Random.Range(0, 2);
            if (randType == 0) //Mosnter
                nodePrefab = monsterNodePrefab[Random.Range(0, monsterNodePrefab.Count)];
            else
                nodePrefab = eventNodePrefab[Random.Range(0, eventNodePrefab.Count)];

            Vector3 newPosition = new Vector3(layer * 3, verticalLayer * 1.5f * Mathf.Pow(-1, i), 0);
            GameObject node = Instantiate(nodePrefab, newPosition, Quaternion.identity);
            node.name = "Node " + i.ToString() + " Layer " + layer.ToString();
            node.GetComponent<node>().position = newPosition;
            addList(layer, node.GetComponent<node>());
            if (i % 2 == 0)
                verticalLayer++;

        }
    }

    private void createMap()
    {
        //generater town node
        generateNode(1, 0, startNodePrefab);
        int totalLayer = maxNodeLayer + 1;
        for (int i = 1; i < totalLayer; i++)
        {
            if (i == totalLayer - 1) // last node
            {
                generateNode(1, i ,bossNodePrefab);
                break;
            }
            generateNode(Random.Range(1,4), i, eventNodePrefab,monsterNodePrefab);
        }
    }


    private void addList(int layer, node newNode)
    {
        if (nodeList.ContainsKey(layer)) // has layer
        {
            nodeList[layer].Add(newNode);
          
        }
        else // nolayer
        {
            nodeList[layer] = new List<node>();
            nodeList[layer].Add(newNode);
        }
    }

    private void connectNode()
    {
        exploration_sceneManager.Instance.playerLocation = nodeList[0][0]; //frist node

        for (int i = 0; i < nodeList.Count; i++) 
        {
            if (i - nodeList.Count == -1) //last node
                break;
            randomConnectNodeToNode(nodeList[i], nodeList[i + 1]);
        }

    }

    private void randomConnectNodeToNode(List<node> thisList, List<node> nextList)
    {
        int countDummy = 0;
        int randDonNum = Random.Range(0, 5); //Random Connected nummber
        int totalRannum = 0;
        List<node> remaningList = new List<node>();
        remaningList.AddRange(nextList);

        if (thisList.Count < nextList.Count)
        {
            totalRannum = nextList.Count + randDonNum;
        }
        else
        {
            totalRannum = thisList.Count + randDonNum;
        }
        for (int i = 0; i < totalRannum; i++)
        {
            if (countDummy >= thisList.Count)
                countDummy = 0;
            if (remaningList.Count == 0)
                remaningList.AddRange(nextList);

            int index = Random.Range(0, remaningList.Count);
            thisList[countDummy].connect(remaningList[index]);
            remaningList.RemoveAt(index);
            countDummy++;
        }

    }

    public Vector3 getNodePosition(int layer, int index)
    {
        return nodeList[layer][index].position;
    }

}
