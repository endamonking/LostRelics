using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVerse : cardEffect
{
    [SerializeField]
    private int baseSkillMultiplier = 100, flowSkillMultiplier = 150;

    private int cardDrawed;
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
        float skillMulti = user.myStance == stance.Flow ? flowSkillMultiplier : baseSkillMultiplier;

        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();
        cardDrawed = playerCardHanlder.cardDrawedThisTurn;

        for (int i = 0; i < cardDrawed; i++)
        {
            float additiveskillMulti = skillMulti / 100.0f;
            target.takeDamage(userDamage, userAP, userDMGBonus, additiveskillMulti, userCritRate, userCritDMG);
            //play animation and sound
            user.doCharacterAnimationAndSound(target.gameObject);
        }

        return true;
    }
}
