using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class MainMenu : MonoBehaviour
{
    public Button OptionsButton;
    public Button Back;
    public GameObject StartButton;
    public GameObject OptionButton;

    private void Start()
    {
        OptionsButton.onClick.AddListener(ShowOptionMenu);
        Back.onClick.AddListener(ShowStartButton);
        OptionButton.SetActive(false);
    }
    private void ShowOptionMenu()
    {
         
        StartButton.SetActive(false);
        OptionButton.SetActive(true);
    }

    private void ShowStartButton()
    {
        
        OptionButton.SetActive(false);
        StartButton.SetActive(true);
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
