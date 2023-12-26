using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int selectedCharacterID;
    public CharacterStatsScriptableObject characterStats;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        selectedCharacterID = PlayerPrefs.GetInt("SelectedCharacter", 1);

        characterStats = Resources.Load<CharacterStatsScriptableObject>("CharacterStats");
    }

    private void Start()
    {
        // Retrieve the selected character ID from PlayerPrefs
        selectedCharacterID = PlayerPrefs.GetInt("SelectedCharacter", 1);
        Debug.Log(selectedCharacterID);
    }
}
