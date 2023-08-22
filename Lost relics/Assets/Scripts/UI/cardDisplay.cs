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

    private bool isUsing;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
       // Button myButton = GetComponent<Button>();
        _cardName.text = card.cardName;
        _sta.text = card.stamina.ToString();
        rectTransform = GetComponent<RectTransform>();
        canvas = transform.parent.GetComponent<Canvas>();
        originalPosition = rectTransform.localPosition;
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
        if (rectTransform.localPosition.y - originalPosition.y >= 200)
        {
            Debug.Log("Doaction");
            usingCard();
        }
        else //cancel
        {
            rectTransform.localPosition = originalPosition;
        }

    }


}
