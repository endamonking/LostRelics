using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerStateData
{
    public string key;
    public float value;
}
[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/Stats")]
public class Stats : ScriptableObject
{

    public List<PlayerStateData> playerStateDataList;
    private Dictionary<string, float> playerStateDictionary;

    private void OnEnable()
    {
        playerStateDataList = new List<PlayerStateData>
        {
            new PlayerStateData { key = "HP", value = 1 },
            new PlayerStateData { key = "ATK", value = 1 },
            new PlayerStateData { key = "Healing", value = 1 },
            new PlayerStateData { key = "DEF", value = 1 },
            new PlayerStateData { key = "SPD", value = 1 },
            new PlayerStateData { key = "Resistance", value = 1 },
            new PlayerStateData { key = "Evade", value = 0f },
            new PlayerStateData { key = "Crit", value = 0f },
            new PlayerStateData { key = "Crit DMG", value = 1.5f }
        };

        playerStateDictionary = new Dictionary<string, float>();
        foreach (PlayerStateData data in playerStateDataList)
        {
            playerStateDictionary.Add(data.key, data.value);
        }
    }

    public float GetStateValue(string key)
    {
        if (playerStateDictionary.ContainsKey(key))
        {
            return playerStateDictionary[key];
        }
        else
        {
            return 0;
        }
    }
}
