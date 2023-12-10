using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemStatsPopup : MonoBehaviour
{
    public TextMeshProUGUI statsText;

    

    public void DisplayStats(Item item)
    {
        
        string stats = $"Name: {item.itemName}\n";  
        stats += $"Type: {item.itemType}\n";
         

         
        statsText.text = stats;
    }
}
