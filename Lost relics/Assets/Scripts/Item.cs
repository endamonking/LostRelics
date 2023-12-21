
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStateData
{
    public string key;
    public int value;
}
public enum ItemType
{
    Armor,
    Helmet,
    Boot,
    KeyItem
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{   public int currentSlot;
    public int sell;
    public int buy;
    public string itemName;
    public ItemType itemType;
    public Sprite icon;
    [Header("Only UI")]
    public bool stable = true;

    [TextArea]
    public string description;
    public List<ItemStateData> ItemStateDataList;
    private Dictionary<string, int> itemStateDictionary;

    private void OnEnable()
    {

        ItemStateDataList = new List<ItemStateData>
        {
            new ItemStateData { key = "HP", value = 1 },
            new ItemStateData { key = "ATK", value = 1 },
            new ItemStateData { key = "Healing", value = 1 },
            new ItemStateData { key = "DEF", value = 1 },
            new ItemStateData { key = "SPD", value = 1 },
            new ItemStateData { key = "Resistance", value = 1 },
            new ItemStateData { key = "Evade", value = 0 },
            new ItemStateData { key = "Crit", value = 0 },
            new ItemStateData { key = "Crit DMG", value = 0 }
        };

        itemStateDictionary = new Dictionary<string, int>();
        foreach (ItemStateData data in ItemStateDataList)
        {
            itemStateDictionary.Add(data.key, data.value);
        }
    }

    public float GetItemStateValue(string key)
    {
        if (itemStateDictionary.ContainsKey(key))
        {
            return itemStateDictionary[key];
        }
        else
        {
            return 0;
        }
    }
}
