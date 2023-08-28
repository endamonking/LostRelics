using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cardDisplay : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Card card;

    [SerializeField]
    private TextMeshProUGUI _cardName, _sta;

    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
       // Button myButton = GetComponent<Button>();
        _cardName.text = card.cardName;
        _sta.text = card.cardCost.ToString();
        rectTransform = GetComponent<RectTransform>();
        canvas = transform.parent.GetComponent<Canvas>();
        originalPosition = rectTransform.localPosition;
    }

    public void usingCard()
    {
        combatManager comIns = combatManager.Instance;
        if (combatManager.Instance.currentObjTurn.GetComponent<cardHandler>().currentMana >= card.cardCost)
        {
            combatManager.Instance.currentObjTurn.GetComponent<cardHandler>().currentMana = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>().currentMana - card.cardCost;
            comIns.inUseCard.Enqueue(this.gameObject);
            if (comIns.isAction == false) // Not actioning
            {
                comIns.isAction = true;
                comIns.StartCoroutine(comIns.startAction());
            }

        }
        else
        {
            Debug.Log("No mana");
            returnOriginPosition();
            activatedComponent();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //originalPosition = rectTransform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update the position of the UI Image based on the pointer's movement
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 localPoint))
        {
            rectTransform.localPosition = localPoint;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Finalize dragging behavior, e.g., releasing the UI Image, resetting cursor, etc.
        if (rectTransform.localPosition.y - originalPosition.y >= 200 && combatManager.Instance.tag != null)
        {
            deactivatedComponent();
            usingCard();
        }
        else //cancel
        {
            returnOriginPosition();
        }
    }
    
    //To make card look invisible by setActive false image and collider
    private void deactivatedComponent()
    {
        GetComponent<Image>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

    }

    private void activatedComponent()
    {
        GetComponent<Image>().enabled = true;
        GetComponent<Collider2D>().enabled = true;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            child.gameObject.SetActive(true);
        }

    }

    public void undoCard()
    {
        combatManager.Instance.currentObjTurn.GetComponent<cardHandler>().currentMana = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>().currentMana + card.cardCost;
        activatedComponent();
        returnOriginPosition();
    }

    private void returnOriginPosition()
    {
        rectTransform.localPosition = originalPosition;
    }


}
