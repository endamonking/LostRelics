using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardPool : MonoBehaviour
{
    public static cardPool Instance;
    public List<Card> naturalPool = new List<Card>();
    public List<Card> EmmaPool = new List<Card>();
    public List<Card> AveryPool = new List<Card>();
    public List<Card> SylviaPool = new List<Card>();
    public List<Card> KristPool = new List<Card>();
    public List<Card> SeraphinaPool = new List<Card>();
    public List<Card> ChloePool = new List<Card>();


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
            case "Emma":
                output.AddRange(EmmaPool);
                break;
            case "Avery":
                output.AddRange(AveryPool);
                break;
            case "Sylvia":
                output.AddRange(SylviaPool);
                break;
            case "Krist":
                output.AddRange(KristPool);
                break;
            case "Seraphina":
                output.AddRange(SeraphinaPool);
                break;
            case "Chloe":
                output.AddRange(ChloePool);
                break;
            default:
                output.AddRange(naturalPool);
                break;
        }

        return output;
    }

}
