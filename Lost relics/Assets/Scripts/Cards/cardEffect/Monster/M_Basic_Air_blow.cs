using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Basic_Air_blow : cardEffect
{
    [SerializeField]
    int skillMultiplier = 100; //Percent unit
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
        enemies.AddRange(combatManager.Instance.getAllPlayer());
        //Apply debuf
        string des = "Decrease ATK by 10%";
        buff deBuff = new buff("Air blow", 2, "ATK_Down", des);
        deBuff.AddBuff("ATK", -10);
        foreach (GameObject enemy in enemies)
        {
            Character targetPlayer = enemy.GetComponent<Character>();
            targetPlayer.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
            buff currentBuff = targetPlayer.findBuffContainByName(deBuff.buffName);
            if (currentBuff != null)
            {
                targetPlayer.removeBuff(currentBuff);
                targetPlayer.applyActiveDeBuff(deBuff, false);
            }
            else
                targetPlayer.applyActiveDeBuff(deBuff, false);
        }
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        //Draw card
        GameObject player = combatManager.Instance.currentObjTurn;
        cardHandler playerCardHanlder = player.GetComponent<cardHandler>();
        playerCardHanlder.drawCard();

        return true;
    }
}
