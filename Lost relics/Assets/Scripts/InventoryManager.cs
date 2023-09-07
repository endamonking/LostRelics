using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public Inventory inventory;  
    public InventorySlot[] EquipmentSlots =new InventorySlot[3];
    public void AddItem(Item Item)
    {
        for(int i=0; i<inventorySlots.Length;i++)
        {
            InventorySlot slot = inventorySlots[i];
        }
    }

}
