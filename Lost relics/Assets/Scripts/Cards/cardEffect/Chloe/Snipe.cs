using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snipe : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 100, addSkillMultiplier = 140;
    [SerializeField]
    private string buffName = "Lock’n loaded";
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
        float addSkillMulti = addSkillMultiplier / 100.0f;

        //Dind hit counts
        buff lockNLoad = user.GetBuffByName(buffName);
        if (lockNLoad != null)
        {
            if (lockNLoad.buffs["STACK"] == 2)
            {
                target.takeDamage(userDamage, userAP, userDMGBonus, addSkillMulti, userCritRate, userCritDMG);
            }
            else
                target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        }
        else
            return false;

        return true;
    }
}
