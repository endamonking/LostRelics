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
    public string buffDescription;
    public Dictionary<string, int> buffs;
    public buffFuntion doEndTurnFunction;
    public buffFuntionWithCard doBeforeUseCard;
    public buffFuntionWithTarget doOnHitFuntion;
    public buffFuntion doOnStartTurnFuntion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public buff(string name, int duration, string pic, string desription)
    {
        this.buffName = name;
        this.duration = duration;
        this.buffPicName = pic;
        this.buffs = new Dictionary<string, int>();
        this.buffDescription = desription;
    }
    public buff(string name, int duration, string pic, IEndturnEffect newFunction, string desription)
    {
        this.buffName = name;
        this.duration = duration;
        this.buffPicName = pic;
        this.buffs = new Dictionary<string, int>();
        this.doEndTurnFunction = newFunction.onEndTurn;
        this.buffDescription = desription;
    }
    public buff(string name, int duration, string pic, IBeforeUseCard newFunction, string desription)
    {
        this.buffName = name;
        this.duration = duration;
        this.buffPicName = pic;
        this.buffs = new Dictionary<string, int>();
        this.doBeforeUseCard = newFunction.onBeforeUseCard;
        this.buffDescription = desription;
    }
    public buff(string name, int duration, string pic, IOnTakeHit newFunction, string description)
    {
        this.buffName = name;
        this.duration = duration;
        this.buffPicName = pic;
        this.buffs = new Dictionary<string, int>();
        this.doOnHitFuntion = newFunction.onTakeHit;
        this.buffDescription = description;
    }
    public buff(string name, int duration, string pic, IStartturnEffect newFunction, string desription)
    {
        this.buffName = name;
        this.duration = duration;
        this.buffPicName = pic;
        this.buffs = new Dictionary<string, int>();
        this.doOnStartTurnFuntion = newFunction.onStartTurn;
        this.buffDescription = desription;
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

    public void updateDescription(string text)
    {
        this.buffDescription = text;
    }

}
