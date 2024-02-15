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
        List<GameObject> allEnemies = combatManager.Instance.getAllEnemies();
        buff newdeBuff = new buff("Adaptive setting", 1, "On_Take_Hit", this.gameObject.GetComponent<IOnTakeHit>());
        foreach (GameObject GO in allEnemies)
        {
            Character enemy = GO.GetComponent<Character>();
            if (!enemy.findBuffContainByName(newdeBuff.buffName))
            {
                enemy.applyActiveDeBuff(newdeBuff, false);
            }
        }

        return true;
    }

}
