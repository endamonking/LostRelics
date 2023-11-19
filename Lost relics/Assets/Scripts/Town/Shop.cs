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
    [SerializeField] private GameObject player;
    private void Start()
    {
        _shopUI.SetActive(false);
    }
    public bool Interact(Interactor interactor)

    {
       
         
        if (_shopUI.activeSelf)
        {
         
            _shopUI.SetActive(false);
            player.GetComponent<PlayerControl>().enabled = true;
        }
        else
        {
            _shopUI.SetActive(true);
            player.GetComponent<PlayerControl>().enabled = false;
        }
        Debug.Log("use Shop");
        return true;
    }

    
}
