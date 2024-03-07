using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainHeal : cardEffect
{
    [SerializeField]
    private int skillMultiplier = 50, addSkillMultiplier = 30;
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
        //Target
        int healPower = user.inComHeal;
        float skillMuti = skillMultiplier / 100.0f;
        target.getHeal(healPower, skillMuti);
        //Self
        float selfMulti = addSkillMultiplier / 100.0f;
        user.getHeal(healPower, selfMulti);
        user.doCharacterSound();
        return true;
    }
}
