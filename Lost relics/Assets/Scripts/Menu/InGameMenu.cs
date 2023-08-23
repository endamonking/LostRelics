using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Canvas;
    public GameObject Player;
    private void Start(){
        Canvas.SetActive(false);   
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            //Debug.Log("Escape Button");
            MenuControl();
        }
    }

    private void MenuControl(){
        Debug.Log(Menu.activeSelf);
        if (Canvas.activeSelf){
            Canvas.SetActive(false);
            Player.GetComponent<PlayerMovement>().enabled=true;
        }
        else{
            Canvas.SetActive(true);
            Player.GetComponent<PlayerMovement>().enabled = false;
        }     
    }
  
}
