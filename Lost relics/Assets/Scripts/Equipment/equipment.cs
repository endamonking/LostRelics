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
    public equipmentType equipmentType;
    public Sprite pic;
    public bool isEquiped = false;
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
    public abstract void uniqueEffect();
}
