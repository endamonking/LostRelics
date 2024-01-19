using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum equipmentType
{
    HEAD,ARMORE,ACCESSORY
}
public abstract class equipment : MonoBehaviour
{
    [Header("Status")]
    public int HP = 0;
    public int DEF = 0;
    public int SPD = 0;
    public int CRITChance = 0;
    public int value = 0; // Price
    public string equipmentDes;
    public string equipmentName;
    public equipmentType equipmentType;
    public bool isEquiped = false;
    [Header("UI")]
    public Sprite pic;
    public int equipmentIndexInList = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setEquipmentPic()
    {
        GetComponent<Image>().sprite = pic;
    }
    public void equiped()
    {
        inventoryManager.Instance.updateEquiped(equipmentIndexInList, true);
    }
    public void removeEquiped()
    {
        inventoryManager.Instance.updateEquiped(equipmentIndexInList, false);
    }
    public abstract void uniqueEffect();
}