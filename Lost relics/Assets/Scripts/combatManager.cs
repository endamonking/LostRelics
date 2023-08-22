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
public class combatManager : MonoBehaviour
{
    public BattleState state;
    public static combatManager Instance;
    public List<GameObject> inUseCard; // using card or trying to use 
    public GameObject currentObjTurn;
    [SerializeField]
    private TextMeshProUGUI _stateText;
    private void Awake()
    {
        Instance = this;
        state = BattleState.START;
    }

    // Start is called before the first frame update
    void Start()
    {
        _stateText.text = state.ToString();
        StartCoroutine(startTurn());
    }

    public void changeTurn(BattleState newState)
    {
        state = newState;
        _stateText.text = state.ToString();
    }

    public void endTurn()
    {
        if (currentObjTurn == null)
            return;
        cardHandler user = currentObjTurn.GetComponent<cardHandler>();
        //Do card action
        foreach (GameObject card in inUseCard)
        {
            card.GetComponent<cardDisplay>().card.changeStanceInto(user);
        }
        foreach(GameObject card in inUseCard)
        {
            user.discardedDeck.Add(card.GetComponent<cardDisplay>().card);
            user.cardInHand.Remove(card.GetComponent<cardDisplay>().card);
        }
        inUseCard.Clear();
        user.destroyInHandCard();
        user.turnGauge = 100f;
        currentObjTurn = null;
        state = BattleState.NORMAL;
    }


    IEnumerator startTurn()
    {
        yield return new WaitForSeconds(1.0f);
        changeTurn(BattleState.NORMAL);
    }



}

