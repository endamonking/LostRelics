using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagkyPassive : uniquePassSkill, IStartturnEffect, IEndturnEffect
{
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
        Debug.Log("EDN");
        Character chara = characterGO.GetComponent<Character>();
        string des2 = "Increase ATK by 20%";
        buff buff = new buff("Bagky's ATK", 1, "ATK_Up", des2);
        buff.AddBuff("ATK", 20);
        chara.applyActiveBuff(buff, true);
    }

    public void onEndTurn()
    {
        Character chara = characterGO.GetComponent<Character>();
        string des2 = "Increase DEF by 20%";
        buff buff = new buff("Bagky's DEF", 2, "DEF_Up", des2);
        buff.AddBuff("DEF", 20);
        chara.applyActiveBuff(buff, true);
    }
}
