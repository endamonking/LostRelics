using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    [Header("UI")]
    public Image image;
    public GameObject sellSlot;
    private InventoryManager inventoryManager;
    public GameObject itemStatsPopupPrefab;
    private GameObject itemStatsPopup;
    private bool isDragging = false;  
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform parentBeforeDrag;
    private void Start() 
    {
        sellSlot = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(go => go.name == "Sell");
        if (sellSlot == null)
        {
            Debug.LogError("No GameObject named 'Sell' found in the scene.");
        }
    }
    private void Awake()
    {
       

        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(transform))
        {
            if (!isDragging) // Show the popup only if not dragging
            {
                ShowPopup();
            }

            return;
        }
       


    }
    public void ShowPopup()
    {
         
        itemStatsPopup = Instantiate(itemStatsPopupPrefab, transform.position + new Vector3(100, -75, 0), Quaternion.identity);
        Canvas activeCanvas = FindObjectOfType<Canvas>();
        itemStatsPopup.transform.SetParent(activeCanvas.transform); // Set the popup's parent to the inventory item
        itemStatsPopup.transform.SetAsLastSibling();
        // Customize the popup to display item stats based on the item data
        ItemStatsPopup popupScript = itemStatsPopup.GetComponent<ItemStatsPopup>();
        if (popupScript != null)
        {
           
            popupScript.DisplayStats(item); // Pass the item's information to display in the popup
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(itemStatsPopup);
        Debug.Log("Exit");

    }

    public void InitialiseItem(Item newItem) {

        item= newItem;
        image.sprite = newItem.icon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        sellSlot.SetActive(true);
        Debug.Log("BeginDrag");
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        parentBeforeDrag = transform.parent;
        transform.SetParent(transform.root);
        
       

       

    }
    public void OnDrag(PointerEventData eventData)
    {
        sellSlot.SetActive(true);
        isDragging = true;
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        Debug.Log("EndDrag");
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        inventoryManager.UpdateInventoryItems();
        
        sellSlot.SetActive(false);
    }
}
