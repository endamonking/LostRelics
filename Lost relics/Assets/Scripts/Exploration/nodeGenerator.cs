using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeGenerator : MonoBehaviour
{
    public int maxNodeLayer = 10;

    [SerializeField]
    private GameObject nodePrefab;


    private Dictionary<int, List<node>> nodeList = new Dictionary<int, List<node>>();

    // Start is called before the first frame update
    void Start()
    {
        generateNode(1,0);
        generateNode(3, 1);
        generateNode(5, 2);
        generateNode(3, 3);
        generateNode(1, 4);
        connectNode();
        //VisualizeConnections();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generateNode(int numNodeInLayer, int layer)
    {
        for (int i = 0; i < numNodeInLayer; i++)
        {
            Vector3 newPosition = new Vector3(layer * 3, i * 1.5f, 0);
            GameObject node = Instantiate(nodePrefab, newPosition, Quaternion.identity);
            node.name = "Node " + i.ToString() + " Layer " + layer.ToString();
            node.GetComponent<node>().position = newPosition;
            addList(layer, node.GetComponent<node>());

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
        for (int i = 0; i < nodeList.Count; i++) 
        {
            /*if (i == 0) // Start node
            {
                foreach (node nextNode in nodeList[i + 1])
                {
                    nodeList[i][0].connect(nextNode);
                }
                continue;
            }*/
            if (i - nodeList.Count == -1) //last node
                break;
            /*else if (i - nodeList.Count == -2)
            {
                foreach (node node1 in nodeList[i])
                {
                    node1.connect(nodeList[i + 1][0]); // connect with first node
                }
                continue;
            }*/

            /* foreach (node node1 in nodeList[i])
             {

                 if (nodeList[i].IndexOf(node1) < nodeList[i + 1].Count)
                     node1.connect(nodeList[i + 1][nodeList[i].IndexOf(node1)]);
             }*/

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

    /*              use to connect same line
     *              if (nodeList[i + 1].IndexOf(node1) < nodeList[i].Count)
                    nodeList[i][nodeList[i + 1].IndexOf(node1)].connect(node1);*/

}
