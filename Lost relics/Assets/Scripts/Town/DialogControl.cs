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
    public int check;
    public string[] dialogLines;
    private int currentIndex;
    public bool inDialog; 

    private void Start()
    {
        check = 1;
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
       
    }

    public void GetDialog(string[] strings)
    {
        dialogLines = strings;
    }

    public void StartDialog() 
    {
        Debug.Log(check);
        if (!_dialogBox.activeSelf && check == 1)
        {
            Debug.Log("open dialog");

            OpenDialog();
        }

        check--;

    }
    private void Update()
    {  if (inDialog)
        {
            DisplayCurrentDialogLine();
            if (Keyboard.current.zKey.wasPressedThisFrame)
            {

                currentIndex++;

                if (currentIndex < dialogLines.Length)
                {
                    DisplayCurrentDialogLine();
                }
                else if(currentIndex >= dialogLines.Length )
                {
                    check = 2;
                    CloseDialog();
                    
                }
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
