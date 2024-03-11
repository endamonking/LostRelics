using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengtheningBullet : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 20;
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
        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        //Add buff
        string des2 = "Increase ATK by 30%";
        buff newBuff = new buff("Strengthening bullet", 2, "ATK_Up", des2);
        newBuff.AddBuff("ATK", 30);
        target.applyActiveBuff(newBuff, false);

        return true;
    }
}
