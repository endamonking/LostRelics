using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class explorationBuffAndDebuff
{
    public buff buff;
    public int battleDuration;
}

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
    public bool isReachBoss = false; //Is player reach the last node(Boss)
    private bool isBackToTown = false;
    [Header("Event")] 
    public GameObject EventCanvas;
    public TextMeshProUGUI eventNameText;
    public TextMeshProUGUI eventDescText;
    public Transform answerContainer;
    public List<Button> answerButtonList = new List<Button>();
    public List<explorationBuffAndDebuff> buffInExploration = new List<explorationBuffAndDebuff>();
    public List<explorationBuffAndDebuff> debuffInExploration = new List<explorationBuffAndDebuff>();

    [Header("Get item")]
    public GameObject getItemTab;
    public GameObject getItemContainer;
    public List<GameObject> itemSpawnList = new List<GameObject>();

    [Header("Result")]
    public GameObject resultTab;
    public TextMeshProUGUI eventText;
    public TextMeshProUGUI battleText;
    public TextMeshProUGUI bossText;
    public TextMeshProUGUI totalText;
    public TextMeshProUGUI eRFText;
    public TextMeshProUGUI batRFText;
    public TextMeshProUGUI bosRFText;
    public TextMeshProUGUI totalRFText;

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
        getItemTab.SetActive(false);
        EventCanvas.SetActive(false);
        resultTab.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isBackToTown && isEvent != true)
        {
            SceneManager.LoadScene("TestRoom");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (GameObject player in playerPool)
        {
            player.SetActive(true);
        }
        if (StageCounter.instance != null)
            StageCounter.instance.increaseStage();
        SceneManager.sceneLoaded -= OnSceneLoaded;
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

    public void turnOffEvenCanvas()
    {
        foreach (Button thisButton in answerButtonList)
            Destroy(thisButton.gameObject);
        EventCanvas.SetActive(false);
        isEvent = false;
        answerButtonList.Clear();
    }

    public void clearEventButton()
    {
        foreach (Button thisButton in answerButtonList)
            Destroy(thisButton.gameObject);
        answerButtonList.Clear();
    }

    public void applyExploBuff(buff activeBuff, int duration)
    {
        explorationBuffAndDebuff newBuff = new explorationBuffAndDebuff { buff = activeBuff, battleDuration = duration };
        buffInExploration.Add(newBuff);
    }

    public void applyExploDeBuff(buff activeDeBuff, int duration)
    {
        explorationBuffAndDebuff newBuff = new explorationBuffAndDebuff { buff = activeDeBuff, battleDuration = duration };
        debuffInExploration.Add(newBuff);
    }

    public void updateExploBuffAndDebuff()
    {
        for (int i = buffInExploration.Count - 1; i >= 0; i--)
        {
            explorationBuffAndDebuff buff = buffInExploration[i];
            buff.battleDuration--;
            if (buff.battleDuration <= 0)
            {
                buffInExploration.RemoveAt(i);
                // Handle any post-buff effects here
            }
        }

        for (int i = debuffInExploration.Count - 1; i >= 0; i--)
        {
            explorationBuffAndDebuff debuff = debuffInExploration[i];
            debuff.battleDuration--;
            if (debuff.battleDuration <= 0)
            {
                debuffInExploration.RemoveAt(i);
                // Handle any post-buff effects here
            }
        }
    }

    public List<buff> getExploBuff()
    {
        List<buff> exploBuff = new List<buff>();
        foreach (explorationBuffAndDebuff activeBuff in buffInExploration)
        {
            exploBuff.Add(activeBuff.buff);
        }

        return exploBuff;
    }
    public List<buff> getExploDeBuff()
    {
        List<buff> exploBuff = new List<buff>();
        foreach (explorationBuffAndDebuff activeBuff in debuffInExploration)
        {
            exploBuff.Add(activeBuff.buff);
        }

        return exploBuff;
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
        if (isReachBoss)
            isBackToTown = true;

        // Unload the additional scene
        SceneManager.UnloadScene("Combat");
        enemyPool.Clear();
        // Enable all GameObjects in the main scene
        EnableMainSceneObjects();
    }

    //Get item
    private void clearGetItemContainer()
    {
        foreach (Transform child in getItemContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void showingGetItem(List<GameObject> itemList)
    {
        clearGetItemContainer();
        isEvent = true;
        getItemTab.SetActive(true);
        foreach (GameObject equipmentGO in itemList)
        {
            GameObject eq = Instantiate(equipmentGO, getItemContainer.transform);
            eq.GetComponent<equipment>().setEquipmentPic();
        }
    }
    public void closeGetItemScreen()
    {
        getItemTab.SetActive(false);
        if (getCardManager.Instance.canvas.activeSelf != true)
            isEvent = false;
    }

    public void getRewardAfterCombat()
    {
        //Card
        float randomNumber = Random.value;
        if (randomNumber < 30.0f / 100.0f) //Critical hit
        {
            GameObject choosedCharacter = playerPool[Random.Range(0, playerPool.Count)];
            List<Card> cards = cardPool.Instance.getCharactCardList(choosedCharacter.GetComponent<Character>().characterName);
            List<Card> natural = cardPool.Instance.getCharactCardList("Natural");
            cards.AddRange(natural);
            getCardManager.Instance.startChooseCardEvent(cards, choosedCharacter.GetComponent<cardHandler>());
        }
        //Get Item
        List<GameObject> items = new List<GameObject>();
        items.Add(itemSpawnList[Random.Range(0, itemSpawnList.Count)]);
        showingGetItem(items);
        foreach (GameObject item in items)
        {
            inventoryManager.Instance.addItemWithOutReParent(item);
        }
        //Add money
        int moneyAmount = 250;
        inventoryManager.Instance.addMoney(moneyAmount);
    }
    //Need to make button to back to main screen
    public void showRunResult()
    {
        isEvent = true;
        resultTab.SetActive(true);
        int eventCount = StageCounter.instance.eventNodePassed;
        int monsterCount = StageCounter.instance.monsterNodePassed;
        int bossCount = StageCounter.instance.bossNodePassed;
        int eRF = eventCount * 5;
        int mRF = monsterCount * 10;
        int bRF = bossCount * 20;
        eventText.text = eventCount.ToString();
        battleText.text = monsterCount.ToString();
        bossText.text = bossCount.ToString();
        totalText.text = (eventCount + monsterCount + bossCount).ToString();
        eRFText.text = eRF.ToString();
        batRFText.text = mRF.ToString();
        bosRFText.text = bRF.ToString();
        totalRFText.text = (eRF + mRF + bRF).ToString();
        int RF = PlayerPrefs.GetInt("relicFragment", 0);
        PlayerPrefs.SetInt("relicFragment", (eRF + mRF + bRF + RF));
        //put file
        if (playerPool.Count == 1)
            Backend.instance.createJson(playerPool[0]);
        else
            Backend.instance.createJson(playerPool[0], playerPool[1]);

    }

    public void bactToMainScreen()
    {
        //destroy all dontonload
        StageCounter.instance.destroyME();
        InGameMenu.Instance.destroyME();
        inventoryManager.Instance.destroyME();
        inventoryCanvas.Instance.destroyME();
        //Destroy player
        foreach (GameObject player in playerPool)
        {
            Destroy(player);
        }
        SceneManager.LoadScene("MainMenu");
    }
}
