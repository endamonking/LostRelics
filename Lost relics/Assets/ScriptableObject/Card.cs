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
    public stance changIntoStance;

    public void changeStanceInto(cardHandler handler)
    {
        handler.myStatnce = changIntoStance;
    }

    public void usingCard()
    {
        combatManager.Instance.inUseCard.Add(this);
    }

}
