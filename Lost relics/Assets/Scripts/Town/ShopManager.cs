using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
 
using System.Linq;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private InventoryManager inventoryManager;
    public Inventory shopinven;
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject shoppingItemPrefab;
    [SerializeField] private List<Item> ShopItemList = new List<Item>();
    public ScrollRect scrollRect;

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private ContentSizeFitter contentSizeFitter;
    [SerializeField] private GameObject shopUIpanel;
 
    public int numberOfItemsPerRow = 4;
    int numberOfRows;   
    private int slotNumber;
    void Start()
    {
         

        inventoryManager = FindObjectOfType<InventoryManager>();

        if (inventoryManager == null)
            {
                Debug.LogError("No InventoryManager found in the scene.");
            }
         
        Transform buttonTransform = shopPanel.transform.parent.parent.parent.Find("Purchase");
        if (buttonTransform != null)
        {
            Button button = buttonTransform.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(Purchase);
            }
        }
        slotNumber = 1;
        numberOfRows = (int)Math.Ceiling((decimal)shopinven.itemList.Count / numberOfItemsPerRow);
        numberOfRows ++;
        Debug.Log( " shopinven.itemList.Count" +shopinven.itemList.Count);
        Transform parentTransform = shopUIpanel.transform;
        ContentSizeFitter contentSizeFitter = parentTransform.GetComponent<ContentSizeFitter>();
        for (int i = 1; i <= numberOfRows; i++)
        { 
           GameObject newRow = Instantiate(rowPrefab, parentTransform);
            newRow.name = "Row_" + i;
            newRow.transform.SetParent(parentTransform);
            
           for (int j = 1; j <= numberOfItemsPerRow && slotNumber  <= shopinven.itemList.Count ; j++)
           {
               GameObject newItem = Instantiate(itemPrefab, newRow.transform);
                
               newItem.name = "ShopSlot_" + slotNumber;
                
                ShopItem shopItem = newItem.GetComponent<ShopItem>();
                if (shopItem != null)
                {
                    Item item = shopinven.itemList[slotNumber - 1];
                    shopItem.textMeshPro.text = item.itemName;
                    shopItem.image.sprite = item.icon;
                     
                    shopItem.button.onClick.AddListener(() => OnAddToCartButtonClick(item)); 
                }
                slotNumber = slotNumber + 1;
            }
        }

        contentSizeFitter.SetLayoutVertical();
        
        scrollRect.verticalNormalizedPosition = 1f;
    }

    void OnAddToCartButtonClick(Item item)
    {
        Transform parentTransform = shopUIpanel.transform;  // Grab from shopPanel
        ContentSizeFitter contentSizeFitter = parentTransform.GetComponent<ContentSizeFitter>();

        ShopItemList.Add(item);

        
        GameObject newShoppingListItem = Instantiate(shoppingItemPrefab, shopPanel.transform);
        TextMeshProUGUI textMeshPro = newShoppingListItem.GetComponentInChildren<TextMeshProUGUI>();
        Button button = newShoppingListItem.GetComponentInChildren<Button>();
        if (textMeshPro != null && button != null)
        {
            textMeshPro.text = item.itemName;
            
            button.onClick.AddListener(() => OnRemoveFromCartButtonClick(item, newShoppingListItem));
        }
        contentSizeFitter.SetLayoutVertical();
    }
    public void OnRemoveFromCartButtonClick(Item item, GameObject shoppingListItem)
    {
        
        ShopItemList.Remove(item);

        
        Destroy(shoppingListItem);
    }
    void Purchase()
    {
        Debug.Log("Purchase");
        // Count only non-null items in the inventory
        int nonNullInventoryCount = inventoryManager.inventory.itemList.Count(item => item != null);

        
        int remainingInventorySpace = inventoryManager.inventory.itemList.Count - nonNullInventoryCount;   
        int totalCost = ShopItemList.Sum(item => item.buy);
        if (inventoryManager.inventory.money >= totalCost)
        {
            if (remainingInventorySpace >= ShopItemList.Count)
            {
                Debug.Log("There's enough space in the inventory for the items in ShopItemList.");


                foreach (Item shopItem in ShopItemList)
                {
                    if (shopItem != null)
                    {



                        int index = inventoryManager.inventory.itemList.FindIndex(item => item == null);

                        if (index != -1)
                        {
                            Debug.Log("Index" + index);
                            inventoryManager.inventory.itemList[index] = shopItem;
                        }

                        inventoryManager.LoadItemInventory();

                    }
                }

                ShopItemList.Clear();
                foreach (Transform child in shopPanel.transform)
                {
                    Destroy(child.gameObject);
                }   
            }
            else
            {
                Debug.Log("There's not enough space in the inventory for the items in ShopItemList.");
            }
        }
        else
        {
            Debug.Log("Not enough money to buy all items in ShopItemList.");
        }

    }
}
