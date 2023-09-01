using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInInventory : MonoBehaviour
{   
    [SerializeField] private Inventory inventory;
   
    
    private void OnEnable()
    {
        Debug.Log(inventory.itemList.Count);
        for (int i = 0; i < inventory.itemList.Count; i++)
        { 
           
            Transform child = transform.GetChild(i);

            Item item = inventory.itemList[i];


            child.GetComponent<ItemInItemSlot>().item = item;
        }

    }
    

}
