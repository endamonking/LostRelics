using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveItemQuest : quest
{
    [Header("Give equipment")]
    public equipmentType targetEquipmentType;
    public int numberOfItem = 2;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool fullfillCondition(List<equipment> eqList)
    {
        if (isComplete)
            return isComplete;

        counter = 0;
        foreach (equipment eq in eqList)
        {
            if (eq.equipmentType == targetEquipmentType)
            {
                counter++;
            }
        }

        if (counter >= numberOfItem)
            isComplete = true;

        return isComplete;
    }

}
