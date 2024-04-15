using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

public class enemyPositionSlot
{
    public GameObject enemy { get; set; }
    public Vector3 position { get; set; }
    public enemyPositionSlot(GameObject obj, Vector3 pos)
    {
        enemy = obj;
        position = pos;
    }
}

public enum stance
{
    None, Defence, Disarm, Exhausted, Sprinting, Take_aim, Panic, Preparation, Exposed, Flow, Temporal, Ethereal, Rage,
    Blade_Dance, Phantom_Assault, Counter, Frenzy, Zan, Purification, Reloading, Showdown
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
    [SerializeField]
    private enemyPositionSlot[] enemiesSlots = new enemyPositionSlot[3];

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
        for (int i = 0; i < enemiesSlots.Length; i++)
        {
            enemiesSlots[i] = new enemyPositionSlot(null, new Vector3(3, 0, -2 + (i * 2)));
        }
        initPlayers();
        initEnemies();
        StartCoroutine(startGame());
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
            playerObj.GetComponent<Character>().originalPosition = playerObj.transform.position;
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
            pCharacter.applyActiveBuff(buff,true);
        }
        foreach (buff buff in exdeBuff)
        {
            pCharacter.applyActiveDeBuff(buff,true);
        }

    }

    private void initEnemies()
    {
        int i = 0;
        foreach (GameObject enemy in enemiesPool)
        {
            GameObject enemyObj = Instantiate(enemy, transform.position, Quaternion.identity);
            enemyObj.transform.position = new Vector3(3, 0, -2 + (i * 2));
            enemyObj.GetComponent<Character>().originalPosition = enemyObj.transform.position;
            enemyObj.SetActive(true);
            StageCounter.instance.increaseMonsterStat(enemyObj.GetComponent<Character>());
            remainingEnemies.Add(enemyObj);
            //add to slot
            enemiesSlots[i].enemy = enemyObj;
            i++;
        }
        
    }
    public void initMoreEnemy(GameObject prefab, Transform spawnerTranform)
    {
        Vector3 spawnPosition = new Vector3(0,0,0);
        for (int i =0; i < enemiesSlots.Length; i++)
        {
            if (enemiesSlots[i].enemy == null)
            {
                spawnPosition = enemiesSlots[i].position;
                GameObject enemyObj = Instantiate(prefab, spawnPosition, Quaternion.identity);
                enemyObj.GetComponent<Character>().originalPosition = enemyObj.transform.position;
                StageCounter.instance.increaseMonsterStat(enemyObj.GetComponent<Character>());
                enemiesSlots[i].enemy = enemyObj;
                remainingEnemies.Add(enemyObj);
                break;
            }
        }
    }

    public void changeTurn(BattleState newState)
    {
        if (state == BattleState.WON || state == BattleState.LOST)
            return;
        state = newState;
        _stateText.text = state.ToString();
    }
    //Start character turn
    public void changeTurn(BattleState newState, GameObject newGO)
    {
        state = newState;
        _stateText.text = state.ToString();
        currentObjTurn = newGO;
        Character thisChara = newGO.GetComponent<Character>();
        //Reset character 
        newGO.GetComponent<cardHandler>().resedDrawCounter(); //Reset card counter
        //Character passive
        if (thisChara.characterPassiveSkill != null)
        {
            if (thisChara.characterPassiveSkill is IStartturnEffect)
            {
                IStartturnEffect passiveSkill = newGO.GetComponent<Character>().characterPassiveSkill.GetComponent<IStartturnEffect>();
                passiveSkill.onStartTurn();
            }
        }
        //Equipment
        characterEquipment characterEQ = newGO.GetComponent<characterEquipment>();
        List<equipment> eqList = new List<equipment>();
        eqList.Add(characterEQ.head);
        eqList.Add(characterEQ.armor);
        eqList.Add(characterEQ.accessory);
        foreach(equipment eq in eqList)
        {
            if (eq is IStartturnEffect)
            {
                IStartturnEffect skill = eq as IStartturnEffect;
                skill.onStartTurn();       
            }
        }
        //ApplyBuff and Debuff Effect
        doOnStartTurnEffect(newGO);
        thisChara.applyDebuffEffect();
        //Skipp Debuff
        float stunValue = thisChara.GetDeBuffValue("Stun");
        if (stunValue > 0)
        {
            endTurn();
            Debug.Log("d");
        }
    }

    public void doOnStartTurnEffect(GameObject newGo)
    {
        Character character = currentObjTurn.GetComponent<Character>();
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(character.activeBuffs);
        allBuff.AddRange(character.activeDeBuffs);
        allBuff.AddRange(character.activeUnClearBuffs);
        allBuff.AddRange(character.activeUnClearDeBuffs);
        foreach (buff a in allBuff)
        {
            if (a.doOnStartTurnFuntion != null)
            {
                a.doOnStartTurnFuntion();
            }
        }
    }
    public void doEndTurnEffect()
    {
        Character character = currentObjTurn.GetComponent<Character>();
        List<buff> allBuff = character.getAllBuffs();
        foreach (buff a in allBuff)
        {
            if (a.doEndTurnFunction != null)
            {
                a.doEndTurnFunction();
            }
            if (a.buffs.ContainsKey("Bomb")) //do bomb effect
            {
                if (a.duration == 1)
                {
                    int damage = a.buffs["Bomb"];
                    a.buffs.Remove("Bomb");
                    List<GameObject> enemies = new List<GameObject>();
                    //Find is player turn or enemy
                    if (currentObjTurn.tag == "Player")
                    {
                        enemies.AddRange(getAllPlayer());
                    }
                    else
                        enemies.AddRange(getAllEnemies());

                    foreach (GameObject enemy in enemies)
                    {
                        Character target = enemy.GetComponent<Character>();
                        target.takeTrueDamage(damage);
                    }
                }
            }
        }
        //Effect
        uniquePassSkill passive = character.characterPassiveSkill;
        if (passive != null)
        {
            if (passive is IEndturnEffect)
            {
                IEndturnEffect passiveSkill = passive as IEndturnEffect;
                passiveSkill.onEndTurn();
            }
        }
        


        character.characterUpDateHpBar();
    }
    public void endTurn()
    {
        if (currentObjTurn == null || isAction == true)
            return;
        //Reset character
        cardHandler user = currentObjTurn.GetComponent<cardHandler>();
        inUseCard.Clear();
        user.destroyInHandCard();
        user.turnGauge = 100f;
        user.currentMana = currentObjTurn.GetComponent<Character>().maxMana;
        doEndTurnEffect();
        if (currentObjTurn != null)
            currentObjTurn.GetComponent<Character>().updateBuffAndDebuff();
        //clear var
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
            if (dequeueCard == null) //it cant be possible 
                continue;
            dequeueCard.card.GetComponent<cardDisplay>().undoCard();
            if (currentObjTurn.tag == "Player")
                currentObjTurn.GetComponent<cardHandler>().updateCardInhand();
        }
        //Reset character
        cardHandler user = currentObjTurn.GetComponent<cardHandler>();
        inUseCard.Clear();
        user.destroyInHandCard();
        user.turnGauge = 100f;
        user.currentMana = currentObjTurn.GetComponent<Character>().maxMana;
        doEndTurnEffect();
        currentObjTurn.GetComponent<Character>().updateBuffAndDebuff();
        //Clear var
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

    public void forceEndTurnWitOutTriggerEndTurnEffect()
    {
        if (currentObjTurn == null)
            return;
        while (inUseCard.Count > 0)
        {
            usingCardQ dequeueCard = inUseCard.Dequeue();
            if (dequeueCard == null) //it cant be possible 
                continue;
            dequeueCard.card.GetComponent<cardDisplay>().undoCard();
            if (currentObjTurn.tag == "Player")
                currentObjTurn.GetComponent<cardHandler>().updateCardInhand();
        }
        //Reset character
        cardHandler user = currentObjTurn.GetComponent<cardHandler>();
        inUseCard.Clear();
        user.destroyInHandCard();
        user.turnGauge = 100f;
        user.currentMana = currentObjTurn.GetComponent<Character>().maxMana;
        currentObjTurn.GetComponent<Character>().updateBuffAndDebuff();
        //Clear var
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

    IEnumerator startGame()
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
            doBeforeusingCardEffect(cardData);
            if (cardData.doCardEffect(currentObjTurn.GetComponent<Character>(), dequeueCard.cardTarget)) //Start card effect
            {
                //Check Token
                if (cardData.isToken == false)
                {
                    if (currentObjTurn != null)
                        currentObjTurn.GetComponent<cardHandler>().discardedDeck.Add(cardData);
                }
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
            if (currentObjTurn != null)
            {
                if (currentObjTurn.tag == "Player")
                    currentObjTurn.GetComponent<cardHandler>().updateCardInhand();

            }
            yield return new WaitForSeconds(cardData.delayAction); 
        }

        isAction = false;
    }
    public void doBeforeusingCardEffect(Card cardData)
    {
        Character character = currentObjTurn.GetComponent<Character>();
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(character.activeBuffs);
        allBuff.AddRange(character.activeDeBuffs);
        allBuff.AddRange(character.activeUnClearBuffs);
        allBuff.AddRange(character.activeUnClearDeBuffs);
        foreach (buff a in allBuff)
        {
            if (a.doBeforeUseCard != null)
            {
                a.doBeforeUseCard(cardData);
            }
        }
    }

    /*public void doCharacterAnimationAndSound(GameObject other)
    {
        Character character = other.GetComponent<Character>();
        if (character == null)
            return;

        if (character.animController != null)
            character.animController.playAttackAnim();

        if (character.characterAudio != null)
            character.characterAudio.playAttackSound();

    }*/

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
            for (int i =0; i < 3; i++)
            {
                if (enemiesSlots[i].enemy == character)
                {
                    enemiesSlots[i].enemy = null;
                }
                else if (enemiesSlots[i].enemy != null)
                {
                    enemiesSlots[i].enemy.GetComponentInChildren<characterOnclick>().reActivateCollider();
                }
           
            }
    
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
            if (StageCounter.instance.isBossNode)
                StageCounter.instance.passBossNode();
            else
                StageCounter.instance.passMonsterNode();

            StartCoroutine(delay());
            return;
        }

        if (remainingPlayers.Count == 0) //Player lost
        {
            changeTurn(BattleState.LOST);
            StartCoroutine(delayLosing());
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
                case "MAXHP":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Max HP " + player.inComMaxHP.ToString();
                    break;
                case "HP":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Current HP " +player.currentHP.ToString();
                    break;
                case "ATK":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Atk "+player.inComATK.ToString();
                    break;
                case "HEAL":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Healing " + player.inComHeal.ToString();
                    break;
                case "DEF":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Def " +player.inComDef.ToString();
                    break;
                case "RESISTANCE":
                    childObject.GetComponent<TextMeshProUGUI>().text = "RESISTANCE " + player.inComResistance.ToString();
                    break;
                case "SPD":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Speed " +player.inComSPD.ToString();
                    break;
                case "EVADE":
                    childObject.GetComponent<TextMeshProUGUI>().text = "EVADE " + player.inComEvade.ToString();
                    break;
                case "CRTRate":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Crit rate " +player.inComCritRate.ToString();
                    break;
                case "CRTDMG":
                    childObject.GetComponent<TextMeshProUGUI>().text = "Crit damage "+ player.inComCritDMG.ToString();
                    break;
            }
        }
        List<buff> allBuff = new List<buff>();
        allBuff.AddRange(player.activeBuffs);
        allBuff.AddRange(player.activeUnClearBuffs);
        List<buff> allDebuff = new List<buff>();
        allDebuff.AddRange(player.activeDeBuffs);
        allDebuff.AddRange(player.activeUnClearDeBuffs);
        displayBuffInStatusScreen(allBuff);
        displaydeBuffInStatusScreen(allDebuff);

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
            if (activeBuff.duration < 90)
                textObject1.GetComponent<TextMeshProUGUI>().text = activeBuff.buffName + "  " + activeBuff.duration.ToString();
            else
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
            //Print descript
            BuffDescription bd = textObject1.GetComponent<BuffDescription>();
            bd.printBuffDescripttion(activeBuff.buffDescription);


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
            if (activeBuff.duration < 90)
                textObject1.GetComponent<TextMeshProUGUI>().text = activeBuff.buffName + "  " + activeBuff.duration.ToString();
            else
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

            //Print descript
            BuffDescription bd = textObject1.GetComponent<BuffDescription>();
            bd.printBuffDescripttion(activeBuff.buffDescription);
        }

    }

    public void closeCharacterWindow()
    {
        isShowDiscard = false;
        showCharacterScreen.SetActive(false);
    }

    //Wind
    [System.Obsolete]
    IEnumerator delay()
    {

        foreach (GameObject player in remainingPlayers)
        {
            int index = playersInitPool.IndexOf(player);
            playersPool[index].GetComponent<Character>().currentHP = player.GetComponent<Character>().currentHP;
            Destroy(player);
        }
        yield return new WaitForSeconds(2.0f);
        if (StageCounter.instance.isBossNode)
            StageCounter.instance.resetIsBossNode();
        exploration_sceneManager.Instance.getRewardAfterCombat();
        exploration_sceneManager.Instance.ReturnToExplorationScene();
    }
    IEnumerator delayLosing()
    {
        foreach (GameObject player in exploration_sceneManager.Instance.playerPool)
        {
            Destroy(player);
        }
        if (StageCounter.instance.isBossNode)
            StageCounter.instance.resetIsBossNode();
        GameManager.Instance.destroyGM();
        yield return new WaitForSeconds(2.0f);
        exploration_sceneManager.Instance.showRunResult();
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

    private void bactToMainScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public GameObject getRandomEnemy()
    {
        if (remainingEnemies.Count > 0)
        {
            GameObject randTarget = remainingEnemies[Random.Range(0, remainingEnemies.Count)];
            return randTarget;
        }
        else
            return null;

    }
    public GameObject getRandomPlayer()
    {
        if (remainingPlayers.Count > 0)
        {
            GameObject randTarget = remainingPlayers[Random.Range(0, remainingPlayers.Count)];
            return randTarget;
        }
        else
            return null;

    }
    //Get all funtion should create new list first then call the funtion to get list
    //It prevent bug when gameobject get destroy while using the list
    //Example        
    //List<GameObject> enemies = new List<GameObject>();
    //enemies.AddRange(combatManager.Instance.getAllEnemies())
    public List<GameObject> getAllEnemies()
    {

        return remainingEnemies;
    }
    public List<GameObject> getAllPlayer()
    {

        return remainingPlayers;
    }


}

