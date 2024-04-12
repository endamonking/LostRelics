using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerProgression : MonoBehaviour
{
    [Header("UI")]
    public GameObject canvas;
    [Header("Stat")]
    public TextMeshProUGUI maxHP;
    public TextMeshProUGUI ATK, HEAL, DEF, SPD, CRATE, CDMG, EVADE, RES;
    [Header("Price")]
    public TextMeshProUGUI pHP;
    public TextMeshProUGUI pATK, pHEAL, pDEF, pSPD, pCRATE, pCDMG, pEVADE, pRES;// p -> orice
    [Header("Lv")]
    public TextMeshProUGUI lvHP;
    public TextMeshProUGUI lvATK, lvHEAL, lvDEF, lvSPD, lvCRATE, lvCDMG, lvEVADE, lvRES;

    [Header("Property")]
    public int maximumStatusLV = 10;
    // Start is called before the first frame update
    void Start()
    {
        printStatDetail();
        if (canvas.activeSelf)
            canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void printStatDetail()
    {
        maxHP.text = PlayerPrefs.GetInt("PPMAXHP", 0).ToString();
        ATK.text = PlayerPrefs.GetInt("PPATK", 0).ToString();
        HEAL.text = PlayerPrefs.GetInt("PPHEAL", 0).ToString();
        DEF.text = PlayerPrefs.GetInt("PPDEF", 0).ToString();
        SPD.text = PlayerPrefs.GetInt("PPSPD", 0).ToString();
        CRATE.text = PlayerPrefs.GetInt("PPCRATE", 0).ToString();
        CDMG.text = PlayerPrefs.GetInt("PPCDMG", 0).ToString();
        EVADE.text = PlayerPrefs.GetInt("PPEVADE", 0).ToString();
        RES.text = PlayerPrefs.GetInt("PPRES", 0).ToString();
        //LV
        lvHP.text = (PlayerPrefs.GetInt("PPMAXHP", 0) / 10).ToString();
        lvATK.text = (PlayerPrefs.GetInt("PPATK", 0) / 5).ToString();
        lvHEAL.text = (PlayerPrefs.GetInt("PPHEAL", 0) / 5).ToString();
        lvDEF.text = (PlayerPrefs.GetInt("PPDEF", 0) / 2).ToString();
        lvSPD.text = (PlayerPrefs.GetInt("PPSPD", 0) / 1).ToString();
        lvCRATE.text = (PlayerPrefs.GetInt("PPCRATE", 0) / 2).ToString();
        lvCDMG.text = (PlayerPrefs.GetInt("PPCDMG", 0) / 3).ToString();
        lvEVADE.text = (PlayerPrefs.GetInt("PPEVADE", 0)/ 1).ToString();
        lvRES.text = (PlayerPrefs.GetInt("PPRES", 0) / 1).ToString();
    }

    // count come from the amount of stat / by the amount of stat.
    //Example HP = 10 so it stat / 10 = count
    public void increaseLV(string statName)
    {
        int stat;
        int count;

        switch (statName)
        {
            case "HP":
                stat = PlayerPrefs.GetInt("PPMAXHP", 0);
                count = stat / 10;

                if (count >= maximumStatusLV)
                    return;

                stat += 10;
                PlayerPrefs.SetInt("PPMAXHP", stat);
                maxHP.text = stat.ToString();
                lvHP.text = (stat / 10).ToString();
                break;
            case "ATK":
                stat = PlayerPrefs.GetInt("PPATK", 0);
                count = stat / 5;

                if (count >= maximumStatusLV)
                    return;

                stat += 5;
                PlayerPrefs.SetInt("PPATK", stat);
                ATK.text = stat.ToString();
                lvATK.text = (stat / 5).ToString();
                break;
            case "HEAL":
                stat = PlayerPrefs.GetInt("PPHEAL", 0);
                count = stat / 5;

                if (count >= maximumStatusLV)
                    return;

                stat += 5;
                PlayerPrefs.SetInt("PPHEAL", stat);
                HEAL.text = stat.ToString();
                lvHEAL.text = (stat / 5).ToString();
                break;
            case "DEF":
                stat = PlayerPrefs.GetInt("PPDEF", 0);
                count = stat / 2;

                if (count >= maximumStatusLV)
                    return;

                stat += 2;
                PlayerPrefs.SetInt("PPDEF", stat);
                DEF.text = stat.ToString();
                lvDEF.text = (stat / 2).ToString();
                break;
            case "SPD":
                stat = PlayerPrefs.GetInt("PPSPD", 0);
                count = stat / 1;

                if (count >= maximumStatusLV)
                    return;

                stat += 1;
                PlayerPrefs.SetInt("PPSPD", stat);
                SPD.text = stat.ToString();
                lvSPD.text = (stat / 1).ToString();
                break;
            case "CRATE":
                stat = PlayerPrefs.GetInt("PPCRATE", 0);
                count = stat / 2;

                if (count >= maximumStatusLV)
                    return;

                stat += 2;
                PlayerPrefs.SetInt("PPCRATE", stat);
                CRATE.text = stat.ToString();
                lvCRATE.text = (stat / 2).ToString();
                break;
            case "CDMG":
                stat = PlayerPrefs.GetInt("PPCDMG", 0);
                count = stat / 3;

                if (count >= maximumStatusLV)
                    return;

                stat += 3;
                PlayerPrefs.SetInt("PPCDMG", stat);
                CDMG.text = stat.ToString();
                lvCDMG.text = (stat / 3).ToString();
                break;
            case "EVADE":
                stat = PlayerPrefs.GetInt("PPEVADE", 0);
                count = stat / 1;

                if (count >= maximumStatusLV)
                    return;

                stat += 1;
                PlayerPrefs.SetInt("PPEVADE", stat);
                EVADE.text = stat.ToString();
                lvEVADE.text = (stat / 1).ToString();
                break;
            case "RES":
                stat = PlayerPrefs.GetInt("PPRES", 0);
                count = stat / 1;

                if (count >= maximumStatusLV)
                    return;

                stat += 1;
                PlayerPrefs.SetInt("PPRES", stat);
                RES.text = stat.ToString();
                lvRES.text = (stat / 1).ToString();
                break;
        }
    }


    public void back()
    {
        canvas.SetActive(false);
    }
    public void openLvUp()
    {
        canvas.SetActive(true);
    }

}
