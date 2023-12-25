using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int UnitID;
    public string UnitName;
    public int UnitLevel;
    public int ATK;
    public int MaxHP;
    public int CurrentHP;

    public bool TakeDamage(int damage)
    {
        CurrentHP -= damage;

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
}
