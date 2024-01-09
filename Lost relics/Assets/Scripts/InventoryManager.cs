using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    public static inventoryManager Instance;
    public int money = 0;

    public List<GameObject> equipmentList = new List<GameObject>();

    [Header("UI")]
    public GameObject playerCanvas;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
