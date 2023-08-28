using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField]
    private int basedefPoint;
    [SerializeField]
    private int maxHP, baseSPD;

    public int maxPlayerHand = 7;
    public int maxMana = 10;
    public stance myStatnce;


    public int currentDefpoint;
    public int currentHP, currentSPD;

    void Start()
    {
        currentSPD = baseSPD;
        currentHP = maxHP;
        currentDefpoint = basedefPoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        currentHP = currentHP - damage;
        Debug.Log(this.gameObject.name + "take " +damage+" "+ currentHP);
        if (currentHP <= 0)
            died();
    }

    private void died()
    {
        combatManager.Instance.target = null;
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        if (combatManager.Instance.state != BattleState.PLAYER)
            return;

        Debug.Log(this.gameObject.name + "Clicked");
        combatManager.Instance.target = this;
    }

}
