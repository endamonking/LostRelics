using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPassive : uniquePassSkill, IOnTakeHitWithDMG
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int onTakeHit(Character user, int DMG)
    {
        int returnDMG = DMG;
        if (DMG >= user.inComMaxHP * 0.5f)
        {
            returnDMG = Mathf.FloorToInt(user.inComMaxHP * 0.5f);
            returnDMG += 1;
        }
        return returnDMG;
    }
}
