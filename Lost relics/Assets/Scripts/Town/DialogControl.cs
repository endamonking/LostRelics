using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogControl : MonoBehaviour
{
   
    public TextMeshProUGUI _dialogText;
    public GameObject _dialogBox;
    private int check;
    private string[] dialogLines;
    private int currentIndex;
    public bool inDialog { get; set; }
    [SerializeField] private GameObject player;

    private void Start()
    {
      
        inDialog = false;
         CloseDialog();
    }
    private void OpenDialog()
    {
        _dialogBox.SetActive(true);
        inDialog = true;
        currentIndex = 0;
        
    }

    public bool IsInDialog()
    {
        return !inDialog;
    }

    public void CloseDialog()
    {
      
        _dialogBox.SetActive(false);
        inDialog = false;
        player.GetComponent<PlayerControl>().enabled = true;

    }

    public void GetDialog(string[] strings)
    {
        dialogLines = strings;
    }

    public void StartDialog()
    {
        player.GetComponent<PlayerControl>().enabled = false;
        DisplayCurrentDialogLine();
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            if (_dialogBox.activeSelf)
            {
                currentIndex++;
                if (currentIndex < dialogLines.Length)
                {
                    DisplayCurrentDialogLine();
                }
                else if (currentIndex >= dialogLines.Length)
                {
                    check = 2;
                    CloseDialog();

                }
            }
            else
            {   
                OpenDialog();
                DisplayCurrentDialogLine();
            }
        }


    }
 
    private void DisplayCurrentDialogLine()
    { 
        if (currentIndex >= 0 && currentIndex < dialogLines.Length)
        {
            _dialogText.text = dialogLines[currentIndex];
        }
    }
}
