using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInItemSlot : MonoBehaviour
{
    public Item item;
    private void OnEnable()
    {
        TextMeshProUGUI[] textMeshes = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textMesh in textMeshes)
        {
        
            textMesh.text = item.itemName;
        }

    }
}
