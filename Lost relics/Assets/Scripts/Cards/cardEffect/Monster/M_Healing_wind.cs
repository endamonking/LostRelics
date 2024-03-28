using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Healing_wind : cardEffect
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
        List<GameObject> players = new List<GameObject>();
        players.AddRange(combatManager.Instance.getAllEnemies());
        int healPower = user.inComHeal;
        float skillMuti = skillMultiplier / 100.0f;
        foreach (GameObject go in players)
        {
            go.GetComponent<Character>().getHeal(healPower, skillMuti);
        }

        return true;
    }
}
