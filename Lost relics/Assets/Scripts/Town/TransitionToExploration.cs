using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionToExploration : MonoBehaviour
{

    public GameObject[] players;

    private void OnTriggerEnter(Collider other)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("Player entered trigger. Number of players: " + players.Length);

        // Deactivate the player GameObjects in the current scene
        DeactivatePlayers();

        // Load the "Exploration" scene additively
        SceneManager.LoadScene("Exploration", LoadSceneMode.Additive);

        // Wait until the "Exploration" scene is loaded before moving the players
        StartCoroutine(MovePlayersWhenSceneLoaded());
    }

    private void DeactivatePlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(false);
        }
    }

    IEnumerator MovePlayersWhenSceneLoaded()
    {
        // Wait until the "Exploration" scene is loaded
        yield return new WaitUntil(() => SceneManager.GetSceneByName("Exploration").isLoaded);

        // Move all player GameObjects to the "Exploration" scene and make them persistent
        for (int i = 0; i < players.Length; i++)
        {
            DontDestroyOnLoad(players[i]);
            SceneManager.MoveGameObjectToScene(players[i], SceneManager.GetSceneByName("Exploration"));
            RemoveSpecificChild(players[i], "InteractionPoint");
            RemoveSpecificChild(players[i], "Canvas");
        }

        // Unload the "TestRoom" scene asynchronously
        SceneManager.UnloadSceneAsync("TestRoom");

        // Set the "Exploration" scene as the active scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Exploration"));
    }

    void RemoveSpecificChild(GameObject parent, string childName)
    {
        // Find the child GameObject
        Transform child = parent.transform.Find(childName);

        // If the child was found, destroy it
        if (child != null)
        {
            Destroy(child.gameObject);
        }
    }
}
