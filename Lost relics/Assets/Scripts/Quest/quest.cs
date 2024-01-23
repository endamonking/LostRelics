using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class quest : MonoBehaviour
{
    [Header("Base")]
    public string questName;
    public string questDescription;
    public bool isComplete = false;
    public int moneyReward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
