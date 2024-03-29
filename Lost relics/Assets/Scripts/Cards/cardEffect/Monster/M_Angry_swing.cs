using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Angry_swing : cardEffect
{
    [SerializeField]
    int oneTargetskillMultiplier = 150, allTargetskillMultiplier = 125; //Percent unit
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

        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(combatManager.Instance.getAllPlayer());
        if (enemies.Count > 1)
        {
            float targetskill = allTargetskillMultiplier / 100.0f;
            foreach (GameObject enemy in enemies)
            {
                Character targetEmy = enemy.GetComponent<Character>();
                targetEmy.takeDamage(userDamage, userAP, userDMGBonus, targetskill, userCritRate, userCritDMG);
            }
        }
        else
        {
            float targetskill = oneTargetskillMultiplier / 100.0f;
            target.takeDamage(userDamage, userAP, userDMGBonus, targetskill, userCritRate, userCritDMG);
        }
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        return true;
    }
}
