using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
public class PlayerControl : MonoBehaviour
{

    private float horizontal;
    private float vertical;

    // private Rigidbody2D body;
    private Rigidbody body;
  
    [SerializeField] private float runSpeed = 10.0f;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject PlayerCanvas;
    [SerializeField] private GameObject player;

    private int move =0;
    public GameObject boundaryCollider;
    public Quest[] activeQuest;

    public void AddQuest(Quest newQuest)
    {
        // Check if activeQuest is null or empty
        if (activeQuest == null)
        {
            // Create a new array with size 1 and add the new quest
            activeQuest = new Quest[] { newQuest };
            return;
        }

        // Check if the quest with the same ID already exists
        if (Array.Exists(activeQuest, quest => quest != null && quest.id == newQuest.id))
        {
            // Quest with the same ID already exists, do nothing and return
            Debug.Log("Quest with ID " + newQuest.id + " already exists!");
            return;
        }

        // Create a new array with increased size to accommodate the new quest
        Quest[] newArray = new Quest[activeQuest.Length + 1];

        // Copy existing quests from activeQuest to newArray
        for (int i = 0; i < activeQuest.Length; i++)
        {
            newArray[i] = activeQuest[i];
        }

        // Add the new quest at the end of newArray
        newArray[activeQuest.Length] = newQuest;

        // Assign newArray to activeQuest
        activeQuest = newArray;
    }



    void Start()
    {
        
    }


    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerInventory();
        }
    }

    private void FixedUpdate()
    { if (move == 0) { 
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 position = this.transform.position;
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;
        position += movement * runSpeed * Time.deltaTime;
        this.transform.position = position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected!");
        if (collision.gameObject == boundaryCollider)
        {
            Debug.Log("In the bound");
            body.velocity = Vector3.zero;
        }
        else
        {
            Debug.Log("Collided with: " + collision.gameObject.name);
        }
    }
    private void PlayerInventory()
    {

        if (PlayerCanvas.activeSelf)
        {
            PlayerCanvas.SetActive(false);
            move = 0;
        }
        else
        {
            PlayerCanvas.SetActive(true);
            move = 1;
            
        }
    }
}
