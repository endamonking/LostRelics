using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exploration_sceneManager : MonoBehaviour
{
    public static exploration_sceneManager Instance;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnableMainSceneObjects()
    {
        Scene mainScene = SceneManager.GetSceneByName("Exploration");

        if (mainScene.IsValid())
        {
            GameObject[] mainSceneObjects = mainScene.GetRootGameObjects();

            foreach (GameObject obj in mainSceneObjects)
            {
                obj.SetActive(true);
            }
        }
    }

    private void DisableMainSceneObjects()
    {
        Scene mainScene = SceneManager.GetSceneByName("Exploration");

        if (mainScene.IsValid())
        {
            GameObject[] mainSceneObjects = mainScene.GetRootGameObjects();

            foreach (GameObject obj in mainSceneObjects)
            {
                obj.SetActive(false);
            }
        }
    }

    public void loadCombatScene()
    {
        // Load the additional scene additively
        SceneManager.LoadScene("Combat", LoadSceneMode.Additive);

        // Disable all GameObjects in the main scene
        DisableMainSceneObjects();
    }

    public void ReturnToExplorationScene()
    {
        // Unload the additional scene
        SceneManager.UnloadScene("Combat");

        // Enable all GameObjects in the main scene
        EnableMainSceneObjects();
    }

}
