using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public static InGameMenu Instance;
    [Header("UI")]
    public GameObject menuTab;
    public GameObject optionTab;
    public GameObject Menu;

    private bool isOpFirstTime = true;
    private void Awake()
    {
        // If an instance already exists, destroy the new one
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Set the instance to this if it doesn't exist
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        optionTab.SetActive(true);
        menuTab.SetActive(true);
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            openMenu();
        }
    }

    public void openMenu()
    {
        Time.timeScale = 0;


        Menu.SetActive(true);
        menuTab.SetActive(true);
        if (!isOpFirstTime)
            optionTab.SetActive(false);
        else
        {
            optionTab.SetActive(true);
            isOpFirstTime = false;
        }
    }

    public void openOption()
    {
        optionTab.SetActive(true);
        menuTab.SetActive(false);
    }

    public void closeOption()
    {
        optionTab.SetActive(false);
        menuTab.SetActive(true);
    }
    public void closeMenu()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void destroyME()
    {
        Destroy(gameObject);
    }
}
