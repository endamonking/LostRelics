using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff 
{
    public delegate void buffFuntion();

    public string buffName;
    public string buffPicName;
    public int duration = 0; // Turn unit
    public Dictionary<string, int> buffs;
    public buffFuntion doEndTurnFunction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public buff(string name, int duration, string pic)
    {
        this.buffName = name;
        this.duration = duration;
        this.buffPicName = pic;
        this.buffs = new Dictionary<string, int>();
    }
    public buff(string name, int duration, string pic, IEndturnEffect newFunction)
    {
        this.buffName = name;
        this.duration = duration;
        this.buffPicName = pic;
        this.buffs = new Dictionary<string, int>();
        this.doEndTurnFunction = newFunction.onEndTurn;
    }

    public void AddBuff(string propertyName, int value)
    {
        if (!buffs.ContainsKey(propertyName))
        {
            buffs.Add(propertyName, value);
        }
        else
        {
            buffs[propertyName] += value;
        }
    }

}
