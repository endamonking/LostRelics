using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochet : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 80, addSkillMultiplier = 50;
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
        float skillMulti = baseSkillMultiplier / 100.0f;
        float addskillMulti = addSkillMultiplier / 100.0f;

        //Check if crit or not if cri then force critical by give critrate 200%
        float randomNumber = Random.value;

        if (randomNumber < userCritRate / 100.0f) //Critical hit
        {
            target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, 200, userCritDMG);
            //Other target 
            GameObject other = combatManager.Instance.getRandomEnemy();
            Character otherTarget = other.GetComponent<Character>();
            otherTarget.takeDamage(userDamage, userAP, userDMGBonus, addskillMulti, userCritRate, userCritDMG);
        }
        else
            target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, 0, userCritDMG);

        return true;
    }
}
