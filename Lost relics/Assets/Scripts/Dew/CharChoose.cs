using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharChoose : MonoBehaviour
{
    public int characterID;

    public void GetCharAndGameStart()
    {
        // Save the selected character name to PlayerPrefs
        PlayerPrefs.SetInt("SelectedCharacter", characterID);

        // Log the character ID to the console
        Debug.Log("Selected Character ID: " + characterID);
        sendCharacterName(characterID);
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
    private void sendCharacterName(int index)
    {
        string characterName = "Test";

        switch (index)
        {
            case 1:
                characterName = "Emma";
                break;
            case 2:
                characterName = "Avery";
                break;
            case 3:
                characterName = "Sylvia";
                break;

        }

        Backend.instance.sendCharacter(characterName);
    }
}
