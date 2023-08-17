using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class MainMenu : MonoBehaviour
{
    public Button OptionsButton;
    public Button Back;
    public GameObject StartMenu;
    public GameObject OptionMenu;

    private void Start()
    {
        OptionsButton.onClick.AddListener(ShowOptionMenu);
        Back.onClick.AddListener(ShowStartMenu);
        OptionMenu.SetActive(false);
    }
    private void ShowOptionMenu()
    {
         
        StartMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    private void ShowStartMenu()
    {
        
        OptionMenu.SetActive(false);
        StartMenu.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Character Selection");
        
    }
   
    public void Quit()
    {
        Application.Quit();
    }
}
