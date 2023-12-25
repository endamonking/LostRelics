using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameMenu : MonoBehaviour
{
    //[SerializeField] private GameObject menu;
    //[SerializeField] private GameObject menuCanvas;
    //[SerializeField] private GameObject PlayerCanvas;
    [SerializeField] private GameObject player;

    private void Start(){
        //menuCanvas.SetActive(false);
        //PlayerCanvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            //MenuControl();
        }
        
    }

    //private void MenuControl(){
         
        //if (menuCanvas.activeSelf){
            //menuCanvas.SetActive(false);
            //player.GetComponent<PlayerControl>().enabled=true;
        //}
        //else{
            //menuCanvas.SetActive(true);
            //player.GetComponent<PlayerControl>().enabled = false;
        //}     
    //}
    
}
