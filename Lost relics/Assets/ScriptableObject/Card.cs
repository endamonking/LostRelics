using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int cardCost;
    public Sprite artwork;
    public stance cardStance;
    public float delayAction;
    public cardEffect effect;
    [SerializeField]
    private stance intoStance;
    private bool isUsing;
    //cardFunction script


    //This will do card effect from CardEffect script then will change into stance 
    public void doCardEffect(Character handler, Character target)
    {
        Debug.Log(cardName); // Simmulate use function
        effect.applyEffect(target);
        handler.myStatnce = intoStance;
    }

  /*  public void usingCard()
    {
        if (isUsing == false)
        {
            combatManager.Instance.inUseCard.Add(this.);
            isUsing = true;
        }
        else
        {
            combatManager.Instance.inUseCard.Remove(this);
            isUsing = false;
        }
        
    }*/
}

