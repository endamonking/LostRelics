using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{

    [SerializeField] private GameObject rowPrefab;
    public ScrollRect scrollRect;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private ContentSizeFitter contentSizeFitter;
    [SerializeField] private GameObject ShopUI;
    public int numberOfRows = 5;
    public int numberOfItemsPerRow = 5;
    private int slotNumber;
    void Start()
    {
        slotNumber = 1;
        Transform parentTransform = ShopUI.transform;
        ContentSizeFitter contentSizeFitter = parentTransform.GetComponent<ContentSizeFitter>();
        for (int i = 1; i <= numberOfRows; i++)
        {
           
           GameObject newRow = Instantiate(rowPrefab, parentTransform);
            newRow.name = "Row_" + i;
            newRow.transform.SetParent(parentTransform);
            
           for (int j = 1; j <= numberOfItemsPerRow; j++)
           {

                
               GameObject newItem = Instantiate(itemPrefab, newRow.transform);
               newItem.name = "ShopSlot_" + slotNumber;
                slotNumber = slotNumber + 1;
            }
        }

        contentSizeFitter.SetLayoutVertical();
        RectTransform rectTransform = parentTransform.GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, rectTransform.offsetMin.y -15  );
        scrollRect.verticalNormalizedPosition = 1f;
    }
}
