using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTheStorage : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 30;
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
        int hitCounts = 0; ;
        //Dind hit counts
        buff lockNLoad = user.GetBuffByName(buffName);
        if (lockNLoad != null)
        {
            hitCounts = lockNLoad.buffs["STACK"];
            lockNLoad.buffs["STACK"] = 0;
        }

        for (int i = 0; i < hitCounts; i++)
        {
            target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
            //play animation and sound
            user.doCharacterAnimationAndSound(target.gameObject);
        }
        Debug.Log(hitCounts);
        return true;
    }
}
