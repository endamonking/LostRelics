using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDraw : cardEffect
{
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
        if (user.currentHP <= user.inComMaxHP * 0.1f)
            return false;

        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(combatManager.Instance.getAllEnemies());
        int lostHP = user.inComMaxHP - user.currentHP;
        int dmg = 0;
        //Take self dmg
        int selfDMG = Mathf.FloorToInt(user.inComMaxHP * 0.1f);
        user.takeTrueDamageIgnoreOnHit(selfDMG);
        //DMG
        if (user.myStance == stance.Zan)
            dmg = Mathf.FloorToInt(lostHP * 0.4f);
        else
            dmg = Mathf.FloorToInt(lostHP * 0.2f);
 
        foreach (GameObject enemy in enemies)
        {
            Character enemyTarget = enemy.GetComponent<Character>();
            enemyTarget.takeTrueDamage(dmg);
            //play animation and sound
            user.doCharacterAnimationAndSound(enemy);
        }


        return true;
    }
}
