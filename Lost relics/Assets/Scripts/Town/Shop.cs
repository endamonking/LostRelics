using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shop : MonoBehaviour, IsInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public DialogControl _dialogControl;
    public bool Interact(Interactor interactor)
    {
        string[] text = new string[2]; 
        text[0] = "test";
        text[1] = "next";

       
            _dialogControl.GetDialog(text);
            _dialogControl.StartDialog();
         
        Debug.Log("use Shop");
        return true;
    }

    
}
