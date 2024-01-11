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
    public int HP = 0, DEF = 0, SPD = 0, CRITChance = 0;
    public string equipmentDes;
    public string equipmentName;
    public equipmentType equipmentType;
    public Sprite pic;
    public bool isEquiped = false;
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
