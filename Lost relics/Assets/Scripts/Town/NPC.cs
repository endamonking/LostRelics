using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IsInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public DialogControl _dialogControl;
    public bool Interact(Interactor interactor)
    {
        string[] text = new string[2];
        text[0] = "Npc";
        text[1] = "First";


        _dialogControl.GetDialog(text);
        _dialogControl.StartDialog();

        Debug.Log("NPC");
        return true;
    }
}
