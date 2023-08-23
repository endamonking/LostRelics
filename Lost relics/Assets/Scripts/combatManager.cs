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
    public Queue<GameObject> inUseCard = new Queue<GameObject>(); // using card or trying to use 
    public GameObject currentObjTurn;
    public bool isAction = false;
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

    void Update()
    {

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
        //Do card action
        /*foreach (GameObject card in inUseCard)
        {
            card.GetComponent<cardDisplay>().card.changeStanceInto(user);
        }*/
        /*foreach(GameObject card in inUseCard)
        {
            user.discardedDeck.Add(card.GetComponent<cardDisplay>().card);
            user.cardInHand.Remove(card.GetComponent<cardDisplay>().card);
        }*/
        inUseCard.Clear();
        user.destroyInHandCard();
        user.turnGauge = 100f;
        user.currentMana = currentObjTurn.GetComponent<Character>().maxMana;
        currentObjTurn = null;
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
            GameObject card = inUseCard.Dequeue();
            Card cardData = card.GetComponent<cardDisplay>().card;
            //Using card function
            cardData.changeStanceInto(currentObjTurn.GetComponent<Character>());
            currentObjTurn.GetComponent<cardHandler>().discardedDeck.Add(cardData);
            currentObjTurn.GetComponent<cardHandler>().cardInHand.Remove(cardData);
            yield return new WaitForSeconds(cardData.delayAction); 
        }

        isAction = false;
    }



}

