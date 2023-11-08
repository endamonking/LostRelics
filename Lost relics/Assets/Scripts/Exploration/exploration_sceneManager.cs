using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class exploration_sceneManager : MonoBehaviour
{
    public static exploration_sceneManager Instance;

    public List<GameObject> playerPool = new List<GameObject>();
    private GameObject[] playerPoolDummy;
    public List<GameObject> enemyPool = new List<GameObject>();

    [Header("Node")]
    public node playerLocation;
    [SerializeField]
    private GameObject currentNodeEffectPrefab;
    public GameObject currentNodeEffect;
    
    [Header("Event")] 
    public GameObject EventCanvas;
    public TextMeshProUGUI eventNameText;
    public TextMeshProUGUI eventDescText;
    public Transform answerContainer;

    public bool isLerping = false;
    public bool isEvent = false;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentNodeEffect = Instantiate(currentNodeEffectPrefab, playerLocation.position, Quaternion.identity);
        playerPoolDummy = GameObject.FindGameObjectsWithTag("Player");
        playerPool.Clear();
        foreach (GameObject obj in playerPoolDummy)
        {
            obj.GetComponent<Character>().characterSetup();
            playerPool.Add(obj);
            obj.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnableMainSceneObjects()
    {
        Scene mainScene = SceneManager.GetSceneByName("Exploration");

        if (mainScene.IsValid())
        {
            GameObject[] mainSceneObjects = mainScene.GetRootGameObjects();

            foreach (GameObject obj in mainSceneObjects)
            {
                if (obj.tag == "Player" || obj.tag == "EventCanvas")
                    continue;
                obj.SetActive(true);
            }
        }
    }

    private void DisableMainSceneObjects()
    {
        Scene mainScene = SceneManager.GetSceneByName("Exploration");
        if (mainScene.IsValid())
        {
            GameObject[] mainSceneObjects = mainScene.GetRootGameObjects();

            foreach (GameObject obj in mainSceneObjects)
            {
                obj.SetActive(false);
            }
        }
    }

    public void updateEventCanvas(string name, string description)
    {
        if (EventCanvas.activeSelf != true)
            EventCanvas.SetActive(true);

        eventNameText.text = name;
        eventDescText.text = description;


    }

    public void loadCombatScene()
    {
        // Load the additional scene additively
        SceneManager.LoadScene("Combat", LoadSceneMode.Additive);
        // Disable all GameObjects in the main scene
        DisableMainSceneObjects();
    }

    [System.Obsolete]
    public void ReturnToExplorationScene()
    {
        // Unload the additional scene
        SceneManager.UnloadScene("Combat");
        enemyPool.Clear();
        // Enable all GameObjects in the main scene
        EnableMainSceneObjects();
    }
}
