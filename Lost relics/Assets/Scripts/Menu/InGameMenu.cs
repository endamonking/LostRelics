using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject player;
    private void Start(){
        canvas.SetActive(false);   
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
             
            MenuControl();
        }
    }

    private void MenuControl(){
        Debug.Log(menu.activeSelf);
        if (canvas.activeSelf){
            canvas.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled=true;
        }
        else{
            canvas.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
        }     
    }
  
}
