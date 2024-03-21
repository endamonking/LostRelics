using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class pritnCardDetail : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _cardName, _sta, _stance, _des;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void assignDetail(Card card)
    {
        _cardName.text = card.cardName;
        _sta.text = card.cardCost.ToString();
        _stance.text = card.effect.intoStance.ToString();
        _des.text = card.effectString;
    }
}
