using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Character Selection");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
