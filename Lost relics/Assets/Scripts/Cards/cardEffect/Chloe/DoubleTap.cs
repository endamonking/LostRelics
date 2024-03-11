using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTap : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 60, addSkillMultiplier = 50;
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
        float addskillMulti = addSkillMultiplier / 100.0f;

        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        target.takeDamage(userDamage, userAP, userDMGBonus, addskillMulti, userCritRate, userCritDMG);
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        user.doCharacterAnimationAndSound(target.gameObject);
        //add stack
        buff lockNLoad = user.GetBuffByName(buffName);
        if (lockNLoad != null)
        {
            lockNLoad.buffs["STACK"] += 2;
            string des = "Lock’n loaded : " + lockNLoad.buffs["STACK"].ToString() + " Stacks";
            lockNLoad.updateDescription(des);
        }

        return true;
    }
}
