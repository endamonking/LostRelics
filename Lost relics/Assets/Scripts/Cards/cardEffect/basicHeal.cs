using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicHeal : cardEffect
{
    [SerializeField]
    private int skillMultiplier = 100;
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
        int healPower = user.inComHeal;
        float skillMuti = skillMultiplier / 100.0f;
        target.getHeal(healPower, skillMuti);
        user.doCharacterAnimationAndSound();
        return true;
    }
}
