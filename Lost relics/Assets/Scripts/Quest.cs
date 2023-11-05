using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest")]
public class Quest : ScriptableObject
{
    public int order;
    public int complete;
    public int active;

    public string description;
   




}