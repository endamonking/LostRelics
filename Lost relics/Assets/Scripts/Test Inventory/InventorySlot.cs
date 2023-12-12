using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{

    private InventoryManager inventoryManager;
    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            if (inventoryItem != null)
            {
                inventoryItem.parentAfterDrag = transform;

            }
        }
        else if (transform.childCount == 1)
        {

            InventoryItem droppedItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventoryItem currentItem = transform.GetChild(0).GetComponent<InventoryItem>();

            if (droppedItem != null && currentItem != null)
            {
                InventorySlotHelmet inventorySlotHelmet = droppedItem.parentBeforeDrag.GetComponentInParent<InventorySlotHelmet>();
                InventorySlotArmor inventorySlotArmor = droppedItem.parentBeforeDrag.GetComponentInParent<InventorySlotArmor>();
                InventorySlotBoot inventorySlotBoot = droppedItem.parentBeforeDrag.GetComponentInParent<InventorySlotBoot>();

                if ((inventorySlotHelmet == null) && (inventorySlotArmor == null) && (inventorySlotBoot == null))
                {
                    Debug.Log(droppedItem.parentBeforeDrag);

                    currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                    currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                    // int newSlotIndex = GetSlotIndex();
                    // Debug.Log("New slot index: " + newSlotIndex);
                    droppedItem.parentAfterDrag = transform;
                    //inventory.MoveItem(droppedItem.item, GetSlotIndex());
                }
                else
                {
                    switch (droppedItem.item.itemType)
                    {
                        case ItemType.Helmet:
                            // Debug.Log(droppedItem.parentBeforeDrag);
                            if (currentItem.item.itemType == ItemType.Helmet)
                            {
                                currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                                currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                                // int newSlotIndex = GetSlotIndex();
                                droppedItem.parentAfterDrag = transform;
                                Debug.Log("From Equip To Inventory");
                                //inventory.MoveItem(droppedItem.item, GetSlotIndex());
                            }
                            break;
                        case ItemType.Armor:
                            if (currentItem.item.itemType == ItemType.Armor)
                            {
                                currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                                currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                                //int newSlotIndex = GetSlotIndex();
                                droppedItem.parentAfterDrag = transform;
                                // inventory.MoveItem(droppedItem.item, GetSlotIndex());
                            }
                            break;
                        case ItemType.Boot:
                            if (currentItem.item.itemType == ItemType.Boot)
                            {
                                currentItem.parentAfterDrag = droppedItem.parentBeforeDrag;
                                currentItem.transform.SetParent(droppedItem.parentBeforeDrag);
                                // int newSlotIndex = GetSlotIndex();
                                droppedItem.parentAfterDrag = transform;
                                // inventory.MoveItem(droppedItem.item, GetSlotIndex());
                            }
                            break;
                        default:

                            break;
                    }


                }
            }
        }
    }


}
