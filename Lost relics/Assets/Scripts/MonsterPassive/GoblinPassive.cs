using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPassive : uniquePassSkill, IStartturnEffect
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onStartTurn()
    {
        Character user = characterGO.GetComponent<Character>();
        if (user.myStance == stance.None)
            user.changingStance(stance.Rage, false);
    }
}
