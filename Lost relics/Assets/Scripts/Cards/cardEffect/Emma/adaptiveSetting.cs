using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adaptiveSetting : cardEffect, IOnTakeHit
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onTakeHit(Character target)
    {
        int damage = 2;
        target.takeTrueDamageIgnoreOnHit(damage);
    }

    public override bool applyEffect(Character target, Character user)
    {
        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(combatManager.Instance.getAllEnemies());
        buff newdeBuff = new buff("Adaptive setting", 1, "On_Take_Hit", this.gameObject.GetComponent<IOnTakeHit>());
        foreach (GameObject GO in enemies)
        {
            Character enemy = GO.GetComponent<Character>();
            buff currentBuff = enemy.findBuffContainByName(newdeBuff.buffName);
            if (currentBuff != null)
            {
                enemy.removeBuff(currentBuff);
                enemy.applyActiveDeBuff(newdeBuff, false);
            }
            else
                enemy.applyActiveDeBuff(newdeBuff, false);
        }

        return true;
    }

}
