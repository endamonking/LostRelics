using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temporalShift : cardEffect
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool applyEffect(Character target, Character user)
    {
        //First debuff
        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(combatManager.Instance.getAllEnemies());
        buff deBuff = new buff("Temporal Shift", 2, "SPD_Down");
        deBuff.AddBuff("SPD", -20);
        foreach (GameObject enemy in enemies)
        {
            Character charac = enemy.GetComponent<Character>();
            charac.applyActiveDeBuff(deBuff, false);
        }
        //Second Buff
        if (user.myStance == stance.Temporal)
        {
            GameObject enemy = combatManager.Instance.getRandomEnemy();
            Character chara = enemy.GetComponent<Character>();
            buff secondDeBuff = new buff("Time Warp", 2, "SPD_Down");
            secondDeBuff.AddBuff("SPD", -20);
            chara.applyActiveDeBuff(secondDeBuff, true);
        }

        return true;
    }
}
