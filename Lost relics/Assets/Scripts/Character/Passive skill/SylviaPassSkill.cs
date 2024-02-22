using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SylviaPassSkill : uniquePassSkill, IStartturnEffect
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
        buff SylviaBuff = new buff("Sylvia's Buff", 1, "ATK_Up");
        Character Sylvia = characterGO.GetComponent<Character>();
        int SylviaSPD = Sylvia.inComSPD;
        if (SylviaSPD >= 40 && SylviaSPD < 50)
        {
            SylviaBuff.AddBuff("ATK", 10);
            SylviaBuff.AddBuff("SPD", 10);
            SylviaBuff.AddBuff("CRITDMG", 20);
            Sylvia.applyActiveBuff(SylviaBuff, true);
        }
        else if (SylviaSPD >= 50 && SylviaSPD < 60)
        {
            SylviaBuff.AddBuff("ATK", 20);
            SylviaBuff.AddBuff("SPD", 20);
            SylviaBuff.AddBuff("CRITDMG", 40);
            Sylvia.applyActiveBuff(SylviaBuff, true);
        }
        else if (SylviaSPD >= 60)
        {
            SylviaBuff.AddBuff("ATK", 30);
            SylviaBuff.AddBuff("SPD", 30);
            SylviaBuff.AddBuff("CRITDMG", 60);
            Sylvia.applyActiveBuff(SylviaBuff, true);
        }

    }
}
