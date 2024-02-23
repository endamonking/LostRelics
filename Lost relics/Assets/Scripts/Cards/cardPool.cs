using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardPool : MonoBehaviour
{
    public static cardPool Instance;
    public List<Card> naturalPool = new List<Card>();

    private void Awake()
    {
        // Ensure there is only one instance of this class
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // If an instance already exists, destroy this new instance
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Card> getCharactCardList(string characterName)
    {
        List<Card> output = new List<Card>();
        switch (characterName)
        {
            case "Test":
                output.AddRange(naturalPool);
                break;
            default:
                output.AddRange(naturalPool);
                break;
        }

        return output;
    }

}
