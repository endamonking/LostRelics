using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeraphicJudgment : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 50, addedBaseSkillMultiplier = 50;
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
        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(combatManager.Instance.getAllEnemies());
        int userDamage = user.inComHeal;
        int userAP = user.inComArmorPen;
        int userDMGBonus = user.inComDMGBonus;
        int userCritRate = user.inComCritRate;
        int userCritDMG = user.inComCritDMG;
        float skillMulti = baseSkillMultiplier / 100.0f;
        float addSkillMulti = addedBaseSkillMultiplier / 100.0f;
        if (user.myStance == stance.Purification)
        {
            foreach (GameObject enemy in enemies)
            {
                Character targetCharac = enemy.GetComponent<Character>();
                targetCharac.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
                targetCharac.takeDamage(userDamage, userAP, userDMGBonus, addSkillMulti, userCritRate, userCritDMG);
            }
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                Character targetCharac = enemy.GetComponent<Character>();
                targetCharac.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);

            }
        }

        return true;
    }
}
