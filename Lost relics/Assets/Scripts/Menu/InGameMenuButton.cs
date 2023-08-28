using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameMenuButton : MonoBehaviour{
    public Button optionsButton;
    public Button backButton;
    public Button resumeButton;
    public Button exitButton;
    public Button mainMenuButton;
    public GameObject menu;
    public GameObject option;
    public GameObject canvas;
    public GameObject player;

    // Start is called before the first frame update
    void Start(){
        option.SetActive(false);
        resumeButton.onClick.AddListener(Resume);
        optionsButton.onClick.AddListener(ShowOptionMenu);
        backButton.onClick.AddListener(BackToMenu);
        exitButton.onClick.AddListener(Exit);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    void Update(){
        
    }
    private void ShowOptionMenu(){
        menu.SetActive(false);
        option.SetActive(true);
    }

    private void BackToMenu(){
        menu.SetActive(true);
        option.SetActive(false);
    }
    private void Resume(){
        canvas.SetActive(false);
        player.GetComponent<PlayerControl>().enabled = true;
    }
    private void MainMenu(){
        Debug.Log("MainMenu");
  
        SceneManager.LoadScene("MainMenu");
    }
    private void Exit(){
        Application.Quit();
    }
}
