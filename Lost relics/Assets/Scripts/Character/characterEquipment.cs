using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterEquipment : MonoBehaviour
{
    public equipment head = null;
    public equipment armor = null;
    public equipment accessory = null;
    public GameObject headGO;
    public GameObject armorGO;
    public GameObject accGO;


    [SerializeField]
    private int _bonusMAXHP = 0, _bonusSpeed = 0, _bonusDEF = 0;
    public int bonusMAXHP
    {
        get
        {
            int finalValue = 0, headValue = 0, armorValue = 0, accValue = 0;

            if (head != null)
                headValue = head.HP;
            if (armor != null)
                armorValue = armor.HP;
            if (accessory != null)
                accValue = accessory.HP;

            finalValue = headValue + armorValue + accValue;
            

            return finalValue;
        }
    }
    public int bonusSpeed
    {
        get
        {
            int finalValue = 0, headValue = 0, armorValue = 0, accValue = 0;

            if (head != null)
                headValue = head.SPD;
            if (armor != null)
                armorValue = armor.SPD;
            if (accessory != null)
                accValue = accessory.SPD;

            finalValue = headValue + armorValue + accValue;


            return finalValue;
        }
    }
    public int bonusDEF
    {
        get
        {
            int finalValue = 0, headValue = 0, armorValue = 0, accValue = 0;

            if (head != null)
                headValue = head.DEF;
            if (armor != null)
                armorValue = armor.DEF;
            if (accessory != null)
                accValue = accessory.DEF;

            finalValue = headValue + armorValue + accValue;


            return finalValue;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void equipEquipment(GameObject newEquipmentGO, equipmentType type)
    {
        equipment newEquipment = newEquipmentGO.GetComponent<equipment>();

        switch (type)
        {
            case equipmentType.HEAD when head == null:
                head = newEquipment;
                headGO = newEquipmentGO;
                newEquipment.equiped();
                break;
            case equipmentType.ARMORE when armor == null:
                armor = newEquipment;
                armorGO = newEquipmentGO;
                newEquipment.equiped();
                break;
            case equipmentType.ACCESSORY when accessory == null:
                accessory = newEquipment;
                accGO = newEquipmentGO;
                newEquipment.equiped();
                break;
            case equipmentType.HEAD when head != null:
                head.removeEquiped();
                Destroy(headGO);
                head = newEquipment;
                headGO = newEquipmentGO;
                newEquipment.equiped();
                break;
            case equipmentType.ARMORE when armor != null:
                armor.removeEquiped();
                Destroy(armorGO);
                armor = newEquipment;
                armorGO = newEquipmentGO;
                newEquipment.equiped();
                break;
            case equipmentType.ACCESSORY when accessory != null:
                accessory.removeEquiped();
                Destroy(accGO);
                accessory = newEquipment;
                accGO = newEquipmentGO;
                newEquipment.equiped();
                break;
        }
    }

}
