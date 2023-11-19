using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest")]
public class Quest : ScriptableObject
{
    public int id;
    public int complete;
    public int active;
    public int category;
    public string description;
    public string name;
    public Item questItem;



}
