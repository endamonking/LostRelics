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
        //exploration_sceneManager.Instance.playerLocation = this;

    }

    protected virtual IEnumerator lerpingNode(float duration)
    {
        exploration_sceneManager.Instance.isLerping = true;
        float startTime = Time.time;
        float elapsedTime = 0f;
        GameObject effect = exploration_sceneManager.Instance.currentNodeEffect;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, this.transform.position + new Vector3(0, 0, -10), t);
            effect.transform.position = Vector3.Lerp(effect.transform.position, this.transform.position, t);
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        exploration_sceneManager.Instance.isLerping = false;
        exploration_sceneManager.Instance.playerLocation = this;
    }

}
