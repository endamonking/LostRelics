using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class node : MonoBehaviour
{
    public Vector3 position;
    public List<node> nextNode = new List<node>();

    [SerializeField]
    private LineRenderer linePrefab;
    private LineRenderer lineRend;
    private Camera mainCamera;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        mainCamera = Camera.main;
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

    protected virtual void OnMouseDown()
    {
        exploration_sceneManager.Instance.playerLocation = this;
        mainCamera.transform.position = this.transform.position + new Vector3(0, 0, -10);
    }


}