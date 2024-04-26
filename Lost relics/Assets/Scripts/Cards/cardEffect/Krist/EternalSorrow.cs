using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EternalSorrow : cardEffect
{
    [SerializeField]
    private int hitCount = 11;
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
        int dmg = Mathf.FloorToInt(user.inComMaxHP * 0.4f);
        for (int i = 0; i < hitCount; i++)
        {
            GameObject go = combatManager.Instance.getRandomEnemy();
            if (go == null)
                continue;
            Character enemyTarget = go.GetComponent<Character>();
            enemyTarget.takeTrueDamage(dmg);
            //play animation and sound
            user.doCharacterAnimationAndSound(go);
        }


        return true;
    }
}
