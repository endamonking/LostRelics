using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BuffDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject descripBox;
    [SerializeField]
    private TextMeshProUGUI descriptionTMP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        descripBox.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descripBox.SetActive(false);
    }

    public void printBuffDescripttion(string text)
    {
        descriptionTMP.text = text;
    }
}
