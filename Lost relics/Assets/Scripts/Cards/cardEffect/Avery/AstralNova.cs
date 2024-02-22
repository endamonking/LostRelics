using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstralNova : cardEffect, IStartturnEffect
{
    [SerializeField]
    private int skillMultiplier = 70;
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
        //Attack 
        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(combatManager.Instance.getAllEnemies()); 
        int userDamage = user.inComATK;
        int userAP = user.inComArmorPen;
        int userDMGBonus = user.inComDMGBonus;
        int userCritRate = user.inComCritRate;
        int userCritDMG = user.inComCritDMG;
        float skillMulti = skillMultiplier / 100.0f;

        foreach (GameObject enemy in enemies)
        {
            Character targetSkill = enemy.GetComponent<Character>();
            targetSkill.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        }

        //Add mana
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        buff manaBuff = new buff("Astral Nova : Mana", 2, "MANA_Up", this.gameObject.GetComponent<IStartturnEffect>());
        foreach (GameObject player in players)
        {
            Character targetBuff = player.GetComponent<Character>();
            if (player != combatManager.Instance.currentObjTurn) //Not current Character
                manaBuff.duration = 1;

            targetBuff.applyActiveBuff(manaBuff, true);
        }

        return true;
    }
    public void onStartTurn()
    {
        cardHandler user = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>();
        user.currentMana += 1;
    }
}
