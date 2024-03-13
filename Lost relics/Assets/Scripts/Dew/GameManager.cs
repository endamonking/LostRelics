using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [Header("MC")]
    public int selectedCharacterID;
    public CharacterStatsScriptableObject characterStats;
    public GameObject MCPrefab;
    public GameObject MC;
    [Header("Companion")]
    public GameObject ComPrefab;
    

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
    public void spawnMC(Transform location, PlayerCamera pCam)
    {
        if (MC != null)
            rePositionMC(location, pCam);
        else
            initMC(location, pCam);
    }

    private void initMC(Transform location, PlayerCamera pCam)
    {
        GameObject player = Instantiate(MCPrefab, location.position, Quaternion.identity);
        MC = player;
        pCam.player = player.transform;
    }
    private void rePositionMC(Transform location, PlayerCamera pCam)
    {
        MC.transform.position = location.position;
        pCam.player = MC.transform;
        MC.SetActive(true);
        MC.GetComponent<PlayerControl>().playerSetAnimTown();
    }
    public void spawnCompanion(int companionNumber, Transform comLocation)
    {
        GameObject companion = Instantiate(ComPrefab, comLocation.position + new Vector3 (0,1,0), Quaternion.identity);
        companion.GetComponent<Companion>().companionNumber = companionNumber;
       
    }

}
