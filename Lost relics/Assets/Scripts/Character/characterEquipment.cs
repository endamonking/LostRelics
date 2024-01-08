using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterEquipment : MonoBehaviour
{
    public equipment head = null;
    public equipment armor = null;
    public equipment accessory = null;


    [SerializeField]
    private int _bonusMAXHP = 0, _bonusSpeed = 0, _bonusDEF = 0;
    public int bonusMAXHP
    {
        get
        {
            int finalValue = 0, headValue = 0, armorValue = 0, accValue = 0;

            if (head != null)
                headValue = head.HP;
            if (armor != null)
                armorValue = armor.HP;
            if (accessory != null)
                accValue = accessory.HP;

            finalValue = headValue + armorValue + accValue;
            

            return finalValue;
        }
    }
    public int bonusSpeed
    {
        get
        {
            int finalValue = 0, headValue = 0, armorValue = 0, accValue = 0;

            if (head != null)
                headValue = head.SPD;
            if (armor != null)
                armorValue = armor.SPD;
            if (accessory != null)
                accValue = accessory.SPD;

            finalValue = headValue + armorValue + accValue;


            return finalValue;
        }
    }
    public int bonusDEF
    {
        get
        {
            int finalValue = 0, headValue = 0, armorValue = 0, accValue = 0;

            if (head != null)
                headValue = head.DEF;
            if (armor != null)
                armorValue = armor.DEF;
            if (accessory != null)
                accValue = accessory.DEF;

            finalValue = headValue + armorValue + accValue;


            return finalValue;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
