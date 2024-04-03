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

    private void Start()
    {
        start.onClick.AddListener(PlayGame);
        quit.onClick.AddListener(Quit);
        //back.onClick.AddListener(ShowStartMenu);
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
