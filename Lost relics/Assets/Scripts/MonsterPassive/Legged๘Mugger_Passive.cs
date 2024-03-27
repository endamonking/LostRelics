using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legged๘Mugger_Passive : uniquePassSkill, IStartturnEffect
{
    [SerializeField]
    private int manaAmount = 2;
    private int _num = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onStartTurn()
    {
        Debug.Log("Passive" +_num);
        if (_num >= 1)
        {
            cardHandler ch = characterGO.GetComponent<cardHandler>();
            ch.currentMana += manaAmount;
            Debug.Log(ch.currentMana);
            _num = 0;
        }
        else
            _num++;

    }
}
