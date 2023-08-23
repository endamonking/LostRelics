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
    public int delayAction;
    [SerializeField]
    private stance intoStance;
    private bool isUsing;
    //cardFunction script

    public void changeStanceInto(Character handler)
    {
        Debug.Log(cardName); // Simmulate use function
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

