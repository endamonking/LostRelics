using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Hot_Air : cardEffect
{
    [SerializeField]
    int skillMultiplier = 150; //Percent unit
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
        int userDamage = user.inComATK;
        int userAP = user.inComArmorPen;
        int userDMGBonus = user.inComDMGBonus;
        int userCritRate = user.inComCritRate;
        int userCritDMG = user.inComCritDMG;
        float skillMulti = skillMultiplier / 100.0f;

        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(combatManager.Instance.getAllPlayer());
        //deBuff
        string des = "Decrease DEF by 20%";
        buff deBuff = new buff("Hot air", 2, "DEF_Down", des);
        deBuff.AddBuff("DEF", -20);
        foreach (GameObject enemy in enemies)
        {
            Character targetPlayer = enemy.GetComponent<Character>();
            targetPlayer.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
            targetPlayer.applyActiveDeBuff(deBuff, false);
        }

        return true;
    }
}
