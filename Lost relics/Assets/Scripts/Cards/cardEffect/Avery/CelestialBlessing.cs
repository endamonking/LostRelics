using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBlessing : cardEffect
{
    [SerializeField]
    private int skillMultiplier = 50;
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
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllPlayer());
        int healPower = user.inComHeal;
        float skillMuti = skillMultiplier / 100.0f;
        foreach (GameObject go in players)
        {
            Character player = go.GetComponent<Character>();
            player.getHeal(healPower, skillMuti);
            if (user.myStance == stance.Ethereal)
                player.removeActiveDeBuff(player.activeDeBuffs.Count);
        }
        user.doCharacterSound();
        return true;
    }
}
