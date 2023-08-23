using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button back;
    [SerializeField] private Button start;
    [SerializeField] private Button quit;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject optionMenu;

    private void Start()
    {
        start.onClick.AddListener(PlayGame);
        quit.onClick.AddListener(Quit);
        optionsButton.onClick.AddListener(ShowOptionMenu);
        back.onClick.AddListener(ShowStartMenu);
        optionMenu.SetActive(false);
    }
    private void ShowOptionMenu()
    {
         
        startMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    private void ShowStartMenu()
    {
        
        optionMenu.SetActive(false);
        startMenu.SetActive(true);
    }
    private void PlayGame()
    {
        SceneManager.LoadScene("Character Selection");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
