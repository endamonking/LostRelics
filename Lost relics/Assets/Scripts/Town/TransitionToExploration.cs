using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToExploration : MonoBehaviour
{
    public GameObject playerPrefabTown;
    public GameObject playerPrefabExploration;
    public GameObject companionPrefabTown;
    public GameObject companionPrefabExploration;
   // public Transform playerSpawnPoint; // Reference to the player spawn point in "Exploration" scene
   // public Transform companionSpawnPoint; // Reference to the companion spawn point in "Exploration" scene

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered trigger.");

        // Load the "Exploration" scene without additive loading
        SceneManager.LoadScene("Exploration", LoadSceneMode.Single);

        // Subscribe to the scene loaded event to enable objects when the scene is fully loaded
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is "Exploration"
        if (scene.name == "Exploration")
        {
            // Instantiate and position the player and companion in the "Exploration" scene
            InstantiateAndPositionCharacters();

            // Unsubscribe from the scene loaded event to avoid duplicate calls
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void InstantiateAndPositionCharacters()
    {
        // Determine the active prefabs based on the current scene
        GameObject activePlayerPrefab = null;
        GameObject activeCompanionPrefab = null;

        if (SceneManager.GetActiveScene().name == "TestRoom")
        {
            activePlayerPrefab = playerPrefabTown;
            activeCompanionPrefab = companionPrefabTown;
        }
        else if (SceneManager.GetActiveScene().name == "Exploration")
        {
            activePlayerPrefab = playerPrefabExploration;
            activeCompanionPrefab = companionPrefabExploration;
        }

        // Instantiate and position characters at their respective spawn points
        if (activePlayerPrefab != null)
        {
            GameObject player = Instantiate(activePlayerPrefab, Vector3.zero, Quaternion.identity);
            // Deactivate the player in the "Exploration" scene
           // player.SetActive(false); Uan mnodify
        }

        if (activeCompanionPrefab != null)
        {
            GameObject companion = Instantiate(activeCompanionPrefab, Vector3.zero, Quaternion.identity);
            // Deactivate the companion in the "Exploration" scene
            //companion.SetActive(false);Uan mnodify
        }
    }
}
