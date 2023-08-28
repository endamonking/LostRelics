using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DisplayItemsUI : MonoBehaviour
{
    public Inventory inventory;
    public TMP_Dropdown itemDropdown;

    void Start()
    {
        DisplayItems();
    }

    public void DisplayItems()
    {
        // Clear any existing options
        itemDropdown.ClearOptions();

        // Create a list of options
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (Item item in inventory.itemList)
        {
            options.Add(new TMP_Dropdown.OptionData(item.itemName));
        }

        // Add the options to the dropdown
        itemDropdown.AddOptions(options);

        // Add a listener to handle selection changes
        itemDropdown.onValueChanged.AddListener(OnItemSelected);
    }

    public void OnItemSelected(int index)
    {
        // Get the selected item
        Item selectedItem = inventory.itemList[index];

        // Handle item selection
        Debug.Log("Selected item: " + selectedItem.itemName);
    }
}
