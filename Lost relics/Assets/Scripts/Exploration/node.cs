using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    public Vector3 position;
    public List<node> nextNode = new List<node>();

    [SerializeField]
    private LineRenderer linePrefab;
    private LineRenderer lineRend;
    // Start is called before the first frame update
    void Start()
    {
        //position = transform.position;
        createConnectionLine();

    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void connect(node otherNode)
    {
        if (nextNode.Contains(otherNode))
            return;

        nextNode.Add(otherNode);
    }

    public void createConnectionLine()
    {

        for (int i = 0; i < nextNode.Count;i++)
        {
            LineRenderer line = Instantiate(linePrefab, transform);
            line.positionCount = 2;
            line.SetPosition(0, position);
            line.SetPosition(1, nextNode[i].position);
        }
    }

    private void OnMouseDown()
    {
        exploration_sceneManager.Instance.loadCombatScene();
    }


}
