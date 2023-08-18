using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class cardDisplay : MonoBehaviour
{
    public Card card;

    [SerializeField]
    private TextMeshProUGUI _cardName, _sta;

    private bool isUsing;
    // Start is called before the first frame update
    void Start()
    {
        Button myButton = GetComponent<Button>();
        _cardName.text = card.cardName;
        _sta.text = card.stamina.ToString();
    }

    public void usingCard()
    {
        if (isUsing == false)
        {
            combatManager.Instance.inUseCard.Add(this.gameObject);
            isUsing = true;
        }
        else
        {
            combatManager.Instance.inUseCard.Remove(this.gameObject);
            isUsing = false;
        }

    }

}
