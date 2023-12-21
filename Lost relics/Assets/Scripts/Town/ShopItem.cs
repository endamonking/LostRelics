using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // This should be here

public class ShopItem : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Image image;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponentInChildren<Image>();
        button = GetComponentInChildren<Button>();
    }
}
