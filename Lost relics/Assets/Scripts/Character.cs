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

    }

    private void died()
    {
        Destroy(this.gameObject);
    }

}
