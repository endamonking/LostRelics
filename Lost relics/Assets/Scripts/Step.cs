using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Step", menuName = "ScriptableObjects/Step")]
public class Step : ScriptableObject
{
    public int order;
    public int category;
    public int complete;
    public int active;

    public string description;
    public Item questItem;




}
