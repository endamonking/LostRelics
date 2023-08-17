using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState 
{ 
    NORMAL, PLAYER, ENEMY, WON, LOST
}
public enum stance
{
    Guarding, Agg
}
public class combatManager : MonoBehaviour
{
    public BattleState state;
    public static combatManager Instance;
    public List<Card> inUseCard; // using card or trying to use 
    public GameObject currentObjTurn;

    private void Awake()
    {
        Instance = this;
        state = BattleState.NORMAL;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void myTurn()
    {

    }

    public void endTurn()
    {
        if (currentObjTurn == null)
            return;
        cardHandler user = currentObjTurn.GetComponent<cardHandler>();
        //Do card action
        foreach (Card card in combatManager.Instance.inUseCard)
        {
            card.changeStanceInto(user);
        }
        user.turnGauge = 100f;
        currentObjTurn = null;
        state = BattleState.NORMAL;
    }

}

