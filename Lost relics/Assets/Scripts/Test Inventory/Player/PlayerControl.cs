using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{

    private float horizontal;
    private float vertical;

    // private Rigidbody2D body;
    private Rigidbody body;
  
    [SerializeField] private float runSpeed = 10.0f;
   // [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject PlayerCanvas;
    [SerializeField] private GameObject player;

    public GameObject boundaryCollider;

    private int move =0;
    private bool isOpenOtherTab = false;
    
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "TestRoom")
            this.enabled = false;
            
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            showInventoryTab(0);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            showInventoryTab(1);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            showInventoryTab(2);
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
    private void showInventoryTab(int tabIndex)
    {
        if (isOpenOtherTab != true)
            move = inventoryManager.Instance.playerCanvas.GetComponent<inventoryCanvas>().openTab(tabIndex);
    }

    public void stopPlaterMovement()
    {
        move = 1;
        isOpenOtherTab = true;
    }

    public void resumePlaterMovement()
    {
        move = 0;
        isOpenOtherTab = false;
    }

}
