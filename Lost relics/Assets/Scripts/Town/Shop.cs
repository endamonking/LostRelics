using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shop : MonoBehaviour, IsInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public DialogControl _dialogControl;
    [SerializeField] private GameObject _shopUI;
    private void Start()
    {
        _shopUI.SetActive(false);
    }
    public bool Interact(Interactor interactor)
    
    {
        string[] text = new string[2]; 
        text[0] = "test";
        text[1] = "next";

        if (_shopUI.activeSelf)
        {
            _shopUI.SetActive(false);
        }
        else
        {
            _shopUI.SetActive(true);
        
        }
        Debug.Log("use Shop");
        return true;
    }

    
}
