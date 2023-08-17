using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardHandler : MonoBehaviour
{
    public float turnGauge = 100f;

    public stance myStatnce;

    public List<Card> playerDeck;
    private List<Card> _currentDeck;
    private List<Card> _discardedDeck;
    private combatManager comIns;
    // Start is called before the first frame update
    void Start()
    {
        comIns = combatManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(turnGauge);
        if (comIns.state == BattleState.NORMAL)
        {
            turnGauge = turnGauge - Time.deltaTime * 10;
        }
        if (turnGauge <= 0)
        {
            comIns.state = BattleState.PLAYER;
            comIns.currentObjTurn = this.gameObject;
            
        }
    }


}
