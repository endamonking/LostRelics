using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameMenu : MonoBehaviour
{
    public Button OptionsButton;
    public Button Back;
    public Button Resume;
    public GameObject Menu;
    public GameObject OptionButton;
    public GameObject Player;
    private void Start(){
        Menu.SetActive(false);
        OptionButton.SetActive(false);
        Resume.onClick.AddListener(MenuControl);
        OptionsButton.onClick.AddListener(ShowOptionMenu);
        OptionsButton.onClick.AddListener(ShowOptionMenu);
        Back.onClick.AddListener(ShowMenu);
        
    }
    private void ShowOptionMenu(){
        Menu.SetActive(false);
        OptionButton.SetActive(true);
    }

    private void ShowMenu(){
        Menu.SetActive(true);
        OptionButton.SetActive(false);
    }
    public void MenuControl(){
  
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit(){
        Application.Quit();
    }
}
