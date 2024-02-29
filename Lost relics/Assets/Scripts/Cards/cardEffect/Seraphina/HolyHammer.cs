using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyHammer : cardEffect
{
    [SerializeField]
    private int skillMultiplier = 200; //Percent unit
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

        int healAmount = target.takeDamageWithDMGReturn(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);
        //Heal part
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        foreach (GameObject player in players)
        {
            Character ally = player.GetComponent<Character>();
            ally.getHeal(healAmount / 2, 1.0f);
        }

        return true;
    }
}
