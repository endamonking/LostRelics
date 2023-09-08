using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum BattleState 
{ 
    START, NORMAL, PLAYER, ENEMY, WON, LOST
}
public enum stance
{
    Guarding, Agg
}

public class usingCardQ
{
    public GameObject card { get; set; }
    public Character cardTarget { get; set; }
}

public class combatManager : MonoBehaviour
{
    public BattleState state;
    public static combatManager Instance;
    public Queue<usingCardQ> inUseCard = new Queue<usingCardQ>(); // using card or trying to use 
    public GameObject currentObjTurn;
    public bool isAction = false;
    public GameObject endTurnButton;
    public Character target;
    [SerializeField]
    private TextMeshProUGUI _stateText;
    public TextMeshProUGUI currentManaText;

    [Header("Effect")]
    [SerializeField]
    private GameObject selectedEffectPrefabe;
    private GameObject _selectedEffect;
    private Vector3 _selectedEffectPostion;

    private List<GameObject> remainingPlayers = new List<GameObject>();
    private List<GameObject> playersPool;
    private List<GameObject> remainingEnemies = new List<GameObject>();
    private List<GameObject> enemiesPool;
    private void Awake()
    {
        Instance = this;
        playersPool = exploration_sceneManager.Instance.playerPool;
        enemiesPool = exploration_sceneManager.Instance.enemyPool;

        state = BattleState.START;
    }

    // Start is called before the first frame update
    void Start()
    {
        _stateText.text = state.ToString();
        _selectedEffectPostion = new Vector3(0, -20f, 0);
        _selectedEffect = Instantiate(selectedEffectPrefabe, _selectedEffectPostion, Quaternion.identity);
        initPlayers();
        initEnemies();
        StartCoroutine(startTurn());
    }

    void Update()
    {

    }

    private void initPlayers()
    {
        int i = 0;
        foreach (GameObject player in playersPool)
        {
            GameObject playerObj = Instantiate(player, transform.position, Quaternion.identity);
            playerObj.transform.position = new Vector3(-3, 0, -2 + (i * 2));
            playerObj.SetActive(true);
            remainingPlayers.Add(playerObj);
            i++;
        }
    }

    private void initEnemies()
    {
        int i = 0;
        foreach (GameObject enemy in enemiesPool)
        {
            GameObject enemyObj = Instantiate(enemy, transform.position, Quaternion.identity);
            enemyObj.transform.position = new Vector3(3, 0, -2 + (i * 2));
            enemyObj.SetActive(true);
            remainingEnemies.Add(enemyObj);
            i++;
        }
    }

    public void changeTurn(BattleState newState)
    {
        state = newState;
        _stateText.text = state.ToString();
    }

    public void endTurn()
    {
        if (currentObjTurn == null || isAction == true)
            return;
        cardHandler user = currentObjTurn.GetComponent<cardHandler>();
        inUseCard.Clear();
        user.destroyInHandCard();
        user.turnGauge = 100f;
        user.currentMana = currentObjTurn.GetComponent<Character>().maxMana;
        currentObjTurn = null;
        target = null;
        if (endTurnButton.activeSelf)
            endTurnButton.SetActive(false);
        if (currentManaText.gameObject.activeSelf == true)
            currentManaText.gameObject.SetActive(false);
        returnEffectPosition();
        changeTurn(BattleState.NORMAL);
    }

    IEnumerator startTurn()
    {
        yield return new WaitForSeconds(1.0f);
        changeTurn(BattleState.NORMAL);
    }

    public IEnumerator startAction()
    {
        while (inUseCard.Count > 0)
        {
            usingCardQ dequeueCard = inUseCard.Dequeue();
            Card cardData = dequeueCard.card.GetComponent<cardDisplay>().card;
            //Check target
            if (dequeueCard.cardTarget == null)
            {
                dequeueCard.card.GetComponent<cardDisplay>().undoCard();
                continue;
            }
            //Using card function
            cardData.doCardEffect(currentObjTurn.GetComponent<Character>(), dequeueCard.cardTarget);
            currentObjTurn.GetComponent<cardHandler>().discardedDeck.Add(cardData);
            currentObjTurn.GetComponent<cardHandler>().cardInHand.Remove(cardData);
            yield return new WaitForSeconds(cardData.delayAction); 
        }

        isAction = false;
    }

    public void updateManaText()
    {
        if (currentManaText.gameObject.activeSelf == false)
            currentManaText.gameObject.SetActive(true);
        currentManaText.text = "Mana " + currentObjTurn.GetComponent<cardHandler>().currentMana.ToString();
    }

    public void selectedTarget(GameObject Objtarget)
    {
        target = Objtarget.GetComponent<Character>();
        _selectedEffect.transform.position = Objtarget.transform.position + new Vector3(0, -1, 0);
    }

    public void returnEffectPosition()
    {
        _selectedEffect.transform.position = _selectedEffectPostion;
    }

    [System.Obsolete]
    public void checkWinLose(GameObject character)
    {
        if (remainingEnemies.Contains(character))
            remainingEnemies.Remove(character);
        if (remainingPlayers.Contains(character))
            remainingPlayers.Remove(character);

        if (remainingEnemies.Count == 0) //Playerwin
        {
            changeTurn(BattleState.WON);
            Destroy(_selectedEffect);
            StartCoroutine(delay());
            return;
        }

        if (remainingPlayers.Count == 0) //Player lost
        {
            changeTurn(BattleState.LOST);
            return;
        }

    }

    [System.Obsolete]
    IEnumerator delay()
    {
        
        foreach (GameObject player in remainingPlayers)
            Destroy(player);
        yield return new WaitForSeconds(3.0f);
        exploration_sceneManager.Instance.ReturnToExplorationScene();
    }


}

