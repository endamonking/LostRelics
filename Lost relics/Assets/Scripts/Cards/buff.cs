using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff 
{
    public delegate void buffFuntion();
    public delegate void buffFuntionWithCard(Card usingCard);
    public delegate void buffFuntionWithTarget(Character target);

    public string buffName;
    public string buffPicName;
    public int duration = 0; // Turn unit
    public Dictionary<string, int> buffs;
    public buffFuntion doEndTurnFunction;
    public buffFuntionWithCard doBeforeUseCard;
    public buffFuntionWithTarget doOnHitFuntion;


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
    public buff(string name, int duration, string pic, IBeforeUseCard newFunction)
    {
        this.buffName = name;
        this.duration = duration;
        this.buffPicName = pic;
        this.buffs = new Dictionary<string, int>();
        this.doBeforeUseCard = newFunction.onBeforeUseCard;
    }
    public buff(string name, int duration, string pic, IOnTakeHit newFunction)
    {
        this.buffName = name;
        this.duration = duration;
        this.buffPicName = pic;
        this.buffs = new Dictionary<string, int>();
        this.doOnHitFuntion = newFunction.onTakeHit;
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
