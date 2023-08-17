using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class cardDisplay : MonoBehaviour
{
    [SerializeField]
    private Card _card;

    [SerializeField]
    private TextMeshProUGUI _cardName, _sta;

    // Start is called before the first frame update
    void Start()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(_card.usingCard);
        _cardName.text = _card.cardName;
        _sta.text = _card.stamina.ToString();
    }

}
