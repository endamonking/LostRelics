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
    private TextMeshProUGUI _cardName, _sta, _stance, _des;
    [SerializeField]
    private Image artImage;
    private RectTransform rectTransform;
    private Canvas canvas;
    public Vector2 originalPosition;

    public bool showOnly = false;
    // Start is called before the first frame update
    void Start()
    {
       // Button myButton = GetComponent<Button>();
        _cardName.text = card.cardName;
        _sta.text = card.cardCost.ToString();
        _stance.text = card.effect.intoStance.ToString();
        _des.text = card.effectString;
        if (card.artwork != null)
            artImage.sprite = card.artwork;
        rectTransform = GetComponent<RectTransform>();
        canvas = transform.parent.GetComponent<Canvas>();
        originalPosition = rectTransform.localPosition;
    }

    public void usingCard()
    {
        combatManager comIns = combatManager.Instance;
        if (combatManager.Instance.currentObjTurn.GetComponent<cardHandler>().currentMana >= card.cardCost)
        {
            comIns.currentObjTurn.GetComponent<cardHandler>().currentMana = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>().currentMana - card.cardCost;
            comIns.updateManaText();
            usingCardQ usedCard = new usingCardQ { card = this.gameObject, cardTarget = comIns.target };
            comIns.inUseCard.Enqueue(usedCard);
            comIns.currentObjTurn.GetComponent<cardHandler>().cardInHand.Remove(this.card);
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
        if (showOnly == true || combatManager.Instance.isShowDiscard == true)
            return;

        //originalPosition = rectTransform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (showOnly == true || combatManager.Instance.isShowDiscard == true)
            return;
        // Update the position of the UI Image based on the pointer's movement
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 localPoint))
        {
            rectTransform.localPosition = localPoint;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (showOnly == true || combatManager.Instance.isShowDiscard == true)
            return;
        // Finalize dragging behavior, e.g., releasing the UI Image, resetting cursor, etc.
        if (rectTransform.localPosition.y - originalPosition.y >= 200 && combatManager.Instance.tag != null && combatManager.Instance.target != null)
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
        /*
        GetComponent<Image>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
        */
        gameObject.SetActive(false);
    }

    private void activatedComponent()
    {
        /*
        GetComponent<Image>().enabled = true;
        GetComponent<Collider2D>().enabled = true;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
        */
        gameObject.SetActive(true);
    }

    public void undoCard()
    {
        combatManager.Instance.currentObjTurn.GetComponent<cardHandler>().currentMana = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>().currentMana + card.cardCost;
        combatManager.Instance.updateManaText();
        combatManager.Instance.currentObjTurn.GetComponent<cardHandler>().cardInHand.Add(this.card);
        activatedComponent();
        returnOriginPosition();
    }

    private void returnOriginPosition()
    {
        rectTransform.localPosition = originalPosition;
    }


}
