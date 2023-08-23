using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Sprite First;
    [SerializeField] private Sprite Second;
    [SerializeField] private Sprite Third;
     private SpriteRenderer spriteRenderer;
    public void Awake()
    {
         spriteRenderer =  player.GetComponentInChildren<SpriteRenderer>();
    }
    
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void select_1()
    {
        
        spriteRenderer.sprite = First;
        Debug.Log("1");
        SceneManager.LoadScene("Testroom");
    }
    public void select_2()
    {
         
        spriteRenderer.sprite = Second;
        Debug.Log("2");
        SceneManager.LoadScene("Testroom");
    }
    public void select_3()
    {
       
        spriteRenderer.sprite = Third;
        Debug.Log("3");
        SceneManager.LoadScene("Testroom");
    }
}
