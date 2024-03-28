using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindyPassive : uniquePassSkill
{
    // Start is called before the first frame update
    void Start()
    {
        Character character = characterGO.GetComponent<Character>();
        //Apply debuf
        string des1 = "Deal 10 damage to all allies upon death";
        buff deBuff = new buff("Bomb", 99, "SPECIAL", des1);
        deBuff.AddBuff("Bomb", 10);
        character.applyActiveDeBuff(deBuff, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
