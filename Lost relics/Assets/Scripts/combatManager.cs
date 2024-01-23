using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum BattleState 
{ 
    START, NORMAL, PLAYER, ENEMY, WON, LOST
}

public class usingCardQ
{
    public GameObject card { get; set; }
    public Character cardTarget { get; set; }
}

public enum stance
{
    None, Defence, Disarm, Exhausted, Sprinting, Take_aim, Panic, Preparation
}

public class combatManager : MonoBehaviour
{
    public BattleState state;
    public static combatManager Instance;
    public Queue<usingCardQ> inUseCard = new Queue<usingCardQ>(); // using card or trying to use 
    public GameObject currentObjTurn;
    public bool isAction = false;
    public bool isForceEndturn = false;
    [Header("UI")]
    public GameObject endTurnButton;
    public GameObject showDiscardButton;
    public GameObject turnBar;
    public GameObject CurrentTurnPic;
    public GameObject showCharacterScreen;
    public GameObject debuffBox;
    public GameObject buffBox;
    [SerializeField]
    private GameObject buffText, buffIcon;
    [Header("Target")]
    public Character target;
    [SerializeField]
    private TextMeshProUGUI _stateText;
    public TextMeshProUGUI currentManaText;
    public TextMeshProUGUI cardLeftText;


    [SerializeField]
    private GameObject discardBox;
    [SerializeField]
    private GameObject discardScreen;

    [Header("Effect")]
    [SerializeField]
    private GameObject selectedEffectPrefabe;
    private GameObject _selectedEffect;
    private Vector3 _selectedEffectPostion;

    private List<GameObject> remainingPlayers = new List<GameObject>();
    private List<GameObject> playersPool;
    private List<GameObject> playersInitPool = new List<GameObject>();
    private List<GameObject> remainingEnemies = new List<GameObject>();
    private List<GameObject> enemiesPool;

    public bool isShowDiscard = false;

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
            //Add explo buff and debuff
            applyExploBuffAndDebuff(playerObj.GetComponent<Character>());
            i++;
        }
        playersInitPool.AddRange(remainingPlayers);
    }

    private void applyExploBuffAndDebuff(Character pCharacter)
    {
        List<buff> exBuff = exploration_sceneManager.Instance.getExploBuff();
        List<buff> exdeBuff = exploration_sceneManager.Instance.getExploDeBuff();

        foreach (buff buff in exBuff)
        {
            pCharacter.applyActiveBuff(buff);
        }
        foreach (buff buff in exdeBuff)
        {
            pCharacter.applyActiveDeBuff(buff);
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
        currentObjTurn.GetComponent<Character>().updateBuffAndDebuff();
        currentObjTurn = null;
        target = null;
        if (endTurnButton.activeSelf)
            endTurnButton.SetActive(false);
        if (showDiscardButton.activeSelf)
            showDiscardButton.SetActive(false);
        if (discardScreen.activeSelf)
            discardScreen.SetActive(false);
        if (CurrentTurnPic.activeSelf)
            CurrentTurnPic.SetActive(false);
        if (currentManaText.gameObject.activeSelf == true)
            currentManaText.gameObject.SetActive(false);
        if (cardLeftText.gameObject.activeSelf == true)
            cardLeftText.gameObject.SetActive(false);
        returnEffectPosition();
        isForceEndturn = false;
        changeTurn(BattleState.NORMAL);
    }

    public void forceEndTurn()
    {
        if (currentObjTurn == null)
            return;
        while (inUseCard.Count > 0)
        {
            usingCardQ dequeueCard = inUseCard.Dequeue();
            if (dequeueCard == null)
                continue;
            dequeueCard.card.GetComponent<cardDisplay>().undoCard();
            if (currentObjTurn.tag == "Player")
                currentObjTurn.GetComponent<cardHandler>().updateCardInhand();
        }
        cardHandler user = currentObjTurn.GetComponent<cardHandler>();
        inUseCard.Clear();
        user.destroyInHandCard();
        user.turnGauge = 100f;
        user.currentMana = currentObjTurn.GetComponent<Character>().maxMana;
        currentObjTurn.GetComponent<Character>().updateBuffAndDebuff();
        currentObjTurn = null;
        target = null;
        if (endTurnButton.activeSelf)
            endTurnButton.SetActive(false);
        if (showDiscardButton.activeSelf)
            showDiscardButton.SetActive(false);
        if (discardScreen.activeSelf)
            discardScreen.SetActive(false);
        if (CurrentTurnPic.activeSelf)
            CurrentTurnPic.SetActive(false);
        if (currentManaText.gameObject.activeSelf == true)
            currentManaText.gameObject.SetActive(false);
        if (cardLeftText.gameObject.activeSelf == true)
            cardLeftText.gameObject.SetActive(false);
        returnEffectPosition();
        isForceEndturn = false;
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
            if (dequeueCard == null)
                continue;
            Card cardData = dequeueCard.card.GetComponent<cardDisplay>().card;
            //Check target
            if (dequeueCard.cardTarget == null)
            {
                dequeueCard.card.GetComponent<cardDisplay>().undoCard();
                if (currentObjTurn.tag == "Player")
                    currentObjTurn.GetComponent<cardHandler>().updateCardInhand();
                continue;
            }
            //Using card function
            if (cardData.doCardEffect(currentObjTurn.GetComponent<Character>(), dequeueCard.cardTarget))
            {
                currentObjTurn.GetComponent<cardHandler>().discardedDeck.Add(cardData);
                if (isForceEndturn)
                {
                    forceEndTurn();
                    break;
                }
            }
            else
            {
                dequeueCard.card.GetComponent<cardDisplay>().undoCard();
                if (currentObjTurn.tag == "Player")
                    currentObjTurn.GetComponent<cardHandler>().updateCardInhand();
            }
            //currentObjTurn.GetComponent<cardHandler>().cardInHand.Remove(cardData);
            if (currentObjTurn.tag == "Player")
                currentObjTurn.GetComponent<cardHandler>().updateCardInhand();
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

    public void updateCardRemaining(int number)
    {
        if (cardLeftText.gameObject.activeSelf == false)
            cardLeftText.gameObject.SetActive(true);
        cardLeftText.text = number.ToString();
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

    public List<usingCardQ> getInUseCard()
    {
        List<usingCardQ> usingCard = new List<usingCardQ>(inUseCard);

        return usingCard;
    }

    [System.Obsolete]
    public void checkWinLose(GameObject character)
    {
        if (remainingEnemies.Contains(character))
        {
            remainingEnemies.Remove(character);
        }
        if (remainingPlayers.Contains(character))
        {
            int index = playersInitPool.IndexOf(character);
            playersPool[index].GetComponent<Character>().currentHP = 1;
            remainingPlayers.Remove(character);
        }

        if (remainingEnemies.Count == 0) //Playerwin
        {
            changeTurn(BattleState.WON);
            Destroy(_selectedEffect);
            exploration_sceneManager.Instance.updateExploBuffAndDebuff();
            foreach (GameObject enemy in enemiesPool)
            {
                inventoryManager.Instance.doKillQuest(enemy.GetComponent<Character>().characterName);
            }
            StartCoroutine(delay());
            return;
        }

        if (remainingPlayers.Count == 0) //Player lost
        {
            changeTurn(BattleState.LOST);
            return;
        }

    }

    public void displayDiscardCard()
    {
        if (discardScreen.activeSelf != true)
            discardScreen.SetActive(true);

        if (isShowDiscard == false)
        {
            currentObjTurn.GetComponent<cardHandler>().displayDiscardedCard(discardBox);
            isShowDiscard = true;
        }
        else
        {
            foreach (Transform child in discardBox.transform)
            {
                if (child.tag == "Card")
                    Destroy(child.gameObject);
            }
            discardScreen.SetActive(false);
            isShowDiscard = false;
        }

    }

    public void cancelDiscardScren() 
    {
        foreach (Transform child in discardBox.transform)
        {
            if (child.tag == "Card")
                Destroy(child.gameObject);
        }
        discardScreen.SetActive(false);
        isShowDiscard = false;
    }

    public void showCharacterWindow(Character player, Sprite portrait)
    {
        isShowDiscard = true;
        //Character player = currentObjTurn.GetComponent<Character>();
        GameObject pic = showCharacterScreen.transform.Find("Portrait").gameObject;
        pic.GetComponent<Image>().sprite = portrait;
        foreach (Transform childTransform in showCharacterScreen.transform)
        {
            // Access the child GameObject
            GameObject childObject = childTransform.gameObject;
            
            switch (childObject.name)
            {
                case "Name":
                    childObject.GetComponent<TextMeshProUGUI>().text = player.characterName;
                    break;
                case "HP":
                    childObject.GetComponent<TextMeshProUGUI>().text = "HP " +player.currentHP.ToString();
                    break;
                case "ATK":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Atk "+player.inComATK.ToString();
                    break;
                case "DEF":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Def " +player.inComDef.ToString();
                    break;
                case "SPD":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Speed " +player.inComSPD.ToString();
                    break;
                case "CRTRate":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Crit rate " +player.inComCritRate.ToString();
                    break;
                case "CRTDMG":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Crit damage "+ player.inComCritDMG.ToString();
                    break;
            }
        }
        displayBuffInStatusScreen(player.activeBuffs);
        displaydeBuffInStatusScreen(player.activeDeBuffs);

        showCharacterScreen.SetActive(true);
    }

    private void displayBuffInStatusScreen(List<buff> allBuff)
    {
        foreach (Transform child in buffBox.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (buff activeBuff in allBuff)
        {
            GameObject textObject1 = Instantiate(buffText, buffBox.transform);
            textObject1.GetComponent<TextMeshProUGUI>().text = activeBuff.buffName;
            //GameObject icon = Instantiate(buffIcon, debuffBox.transform);
            Sprite pic = Resources.Load<Sprite>("Buff_Icon/" + activeBuff.buffPicName);
            if (pic != null)
                textObject1.GetComponentInChildren<Image>().sprite = pic;
            else
            {
                pic = Resources.Load<Sprite>("Buff_Icon/none");
                textObject1.GetComponentInChildren<Image>().sprite = pic;
            }


        }
    }
    private void displaydeBuffInStatusScreen(List<buff> allBuff)
    {
        foreach (Transform child in debuffBox.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (buff activeBuff in allBuff)
        {
            GameObject textObject1 = Instantiate(buffText, debuffBox.transform);
            textObject1.GetComponent<TextMeshProUGUI>().text = activeBuff.buffName;
            //GameObject icon = Instantiate(buffIcon, debuffBox.transform);
            Sprite pic = Resources.Load<Sprite>("Buff_Icon/" + activeBuff.buffPicName);
            if (pic != null)
                textObject1.GetComponentInChildren<Image>().sprite = pic;
            else
            {
                pic = Resources.Load<Sprite>("Buff_Icon/none");
                textObject1.GetComponentInChildren<Image>().sprite = pic;
            }


        }

    }

    public void closeCharacterWindow()
    {
        isShowDiscard = false;
        showCharacterScreen.SetActive(false);
    }


    [System.Obsolete]
    IEnumerator delay()
    {

        foreach (GameObject player in remainingPlayers)
        {
            int index = playersInitPool.IndexOf(player);
            playersPool[index].GetComponent<Character>().currentHP = player.GetComponent<Character>().currentHP;
            Destroy(player);
        }
        yield return new WaitForSeconds(3.0f);
        exploration_sceneManager.Instance.ReturnToExplorationScene();
    }

    public void updatePlayerUI(int deckCount, Sprite pic)
    {
        endTurnButton.SetActive(true);
        showDiscardButton.SetActive(true);
        CurrentTurnPic.SetActive(true);
        CurrentTurnPic.GetComponent<Image>().sprite = pic;
        Button picBut = CurrentTurnPic.GetComponent<Button>();
        picBut.onClick.AddListener(() => showCharacterWindow(currentObjTurn.GetComponent<Character>(), pic));
        updateManaText();
        updateCardRemaining(deckCount);
    }


}

