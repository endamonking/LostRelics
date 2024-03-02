using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunpowderVeil : cardEffect
{
    [SerializeField]
    int skillMultiplier = 30, addskillMultiplier = 50;
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
        int addSkillMulti = Mathf.FloorToInt(userDamage * (addskillMultiplier / 100.0f));

        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        //Apply debuf
        buff deBuff = new buff("Bomb", 2, "SPECIAL");
        deBuff.AddBuff("Bomb", addSkillMulti);

        target.applyActiveDeBuff(deBuff, false);
        return true;
    }

}
