using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameMenuButton : MonoBehaviour{
    public Button OptionsButton;
    public Button BackButton;
    public Button ResumeButton;
    public Button ExitButton;
    public Button MainMenuButton;
    public GameObject Menu;
    public GameObject Option;
    public GameObject Canvas;
    public GameObject Player;

    // Start is called before the first frame update
    void Start(){
        Option.SetActive(false);
        ResumeButton.onClick.AddListener(Resume);
        OptionsButton.onClick.AddListener(ShowOptionMenu);
        BackButton.onClick.AddListener(BackToMenu);
        ExitButton.onClick.AddListener(Exit);
        MainMenuButton.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    void Update(){
        
    }
    private void ShowOptionMenu(){
        Menu.SetActive(false);
        Option.SetActive(true);
    }

    private void BackToMenu(){
        Menu.SetActive(true);
        Option.SetActive(false);
    }
    private void Resume(){
        Canvas.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = true;
    }
    private void MainMenu(){
        Debug.Log("MainMenu");
  
        SceneManager.LoadScene("MainMenu");
    }
    private void Exit(){
        Application.Quit();
    }
}
