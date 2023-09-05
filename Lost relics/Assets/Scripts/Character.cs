using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField]
    private int basedefPoint;
    [SerializeField]
    public int maxHP, baseSPD;

    public int maxPlayerHand = 7;
    public int maxMana = 10;
    public stance myStatnce;

    public int currentDefpoint;
    public int currentHP, currentSPD;
    private cardHandler cardHandler;

    private CharacterBar hpBar;

    void Start()
    {
        currentSPD = baseSPD;
        currentHP = maxHP;
        currentDefpoint = basedefPoint;
        cardHandler = GetComponent<cardHandler>();
        hpBar = GetComponentInChildren<CharacterBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        currentHP = currentHP - damage;
        hpBar.updateHPBar(maxHP, currentHP);
        Debug.Log(this.gameObject.name + "take " +damage+" "+ currentHP);
        if (currentHP <= 0)
            died();
    }

    private void died()
    {
        combatManager.Instance.target = null;
        combatManager.Instance.returnEffectPosition();
        combatManager.Instance.checkWinLose();
        Destroy(cardHandler.turnGuageUI.gameObject);
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        if (combatManager.Instance.state != BattleState.PLAYER)
            return;

        Debug.Log(this.gameObject.name + "Clicked");
        combatManager.Instance.selectedTarget(this.gameObject);
    }

}
