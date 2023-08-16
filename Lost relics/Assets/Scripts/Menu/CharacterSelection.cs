using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void select_1()
    {
        Debug.Log("1");
    }
    public void select_2()
    {
        Debug.Log("2");
    }
    public void select_3()
    {
        Debug.Log("3");
    }
}
