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
        string des2;
        buff SylviaBuff;
        Character Sylvia = characterGO.GetComponent<Character>();
        int SylviaSPD = Sylvia.inComSPD;
        if (SylviaSPD >= 40 && SylviaSPD < 50)
        {
            des2 = "Increase ATK by 10%, SPD by 10%, Critical damage by 20%";
            SylviaBuff = new buff("Sylvia's Buff", 1, "ATK_Up", des2);
            SylviaBuff.AddBuff("ATK", 10);
            SylviaBuff.AddBuff("SPD", 10);
            SylviaBuff.AddBuff("CRITDMG", 20);
            Sylvia.applyActiveBuff(SylviaBuff, true);
        }
        else if (SylviaSPD >= 50 && SylviaSPD < 60)
        {
            des2 = "Increase ATK by 20%, SPD by 20%, Critical damage by 40%";
            SylviaBuff = new buff("Sylvia's Buff", 1, "ATK_Up", des2);
            SylviaBuff.AddBuff("ATK", 20);
            SylviaBuff.AddBuff("SPD", 20);
            SylviaBuff.AddBuff("CRITDMG", 40);
            Sylvia.applyActiveBuff(SylviaBuff, true);
        }
        else if (SylviaSPD >= 60)
        {
            des2 = "Increase ATK by 30%, SPD by 30%, Critical damage by 60%";
            SylviaBuff = new buff("Sylvia's Buff", 1, "ATK_Up", des2);
            SylviaBuff.AddBuff("ATK", 30);
            SylviaBuff.AddBuff("SPD", 30);
            SylviaBuff.AddBuff("CRITDMG", 60);
            Sylvia.applyActiveBuff(SylviaBuff, true);
        }

    }
}
