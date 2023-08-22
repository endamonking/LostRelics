using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int stamina;
    public Sprite artwork;
    public stance cardStance;
    [SerializeField]
    private stance intoStance;
    private bool isUsing;
    public GameObject thisObg;
    //cardFunction

    public void changeStanceInto(cardHandler handler)
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

