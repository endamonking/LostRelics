using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanmenAte : cardEffect
{
    [SerializeField]
    int skillMultiplier = 20; //Percent unit
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
        enemies.AddRange(combatManager.Instance.getAllEnemies());
        //create debuff
        buff deBuff = new buff("Ganmen ate", 2, "SPD_Down");
        deBuff.AddBuff("SPD", -10);

        foreach (GameObject enemy in enemies)
        {
            Character targetChara = enemy.GetComponent<Character>();
            targetChara.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
            targetChara.applyActiveDeBuff(deBuff, false);

        }

        
        return true;
    }
}
