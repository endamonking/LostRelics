using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCounter : MonoBehaviour
{
    public static StageCounter instance;
    public int stageCounter = 1;
    [HideInInspector]
    public bool isGotCompanion = false;

    public bool isBossNode = false;
    public int eventNodePassed = 0;
    public int monsterNodePassed = 0;
    public int bossNodePassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {

            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        stageCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseStage()
    {
        stageCounter++;
    }

    public void increaseMonsterStat(Character monster)
    {
        switch (stageCounter)
        {
            case 2:
                monster.maxHP = Mathf.FloorToInt(monster.maxHP * 1.25f);
                monster.currentHP = monster.maxHP;
                monster.basedefPoint = Mathf.FloorToInt(monster.basedefPoint * 1.25f);
                monster.baseATK = Mathf.FloorToInt(monster.baseATK * 1.2f);
                break;
            case 3:
                monster.maxHP = Mathf.FloorToInt(monster.maxHP * 1.5f);
                monster.currentHP = monster.maxHP;
                monster.basedefPoint = Mathf.FloorToInt(monster.basedefPoint * 1.5f);
                monster.baseATK = Mathf.FloorToInt(monster.baseATK * 1.2f);
                monster.baseSPD = monster.baseSPD + 5;
                monster.maxMana = monster.maxMana + 1;
                break;
        }
        increaseBossStat(monster);

    }

    private void increaseBossStat(Character monster)
    {
        if (isBossNode)
        {
            monster.maxHP = Mathf.FloorToInt(monster.maxHP * 3);
            monster.currentHP = monster.maxHP;
            monster.maxMana = Mathf.FloorToInt(monster.maxMana * 1.5f);
            monster.baseEvade += 5;
            //add card
            cardHandler CH = monster.gameObject.GetComponent<cardHandler>();
            List<Card> addedDeck = new List<Card>();
            addedDeck.AddRange(CH.playerDeck);
            CH.playerDeck.AddRange(addedDeck);
        }
    }

    public void thisIsBossNode()
    {
        isBossNode = true;
    }

    public void resetIsBossNode()
    {
        if (isBossNode)
            isBossNode = false;
    }
    public void passEventNode()
    {
        eventNodePassed++;
    }
    public void passMonsterNode()
    {
        monsterNodePassed++;
    }
    public void passBossNode()
    {
        bossNodePassed++;
    }

}
