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
    private Animator animator;
    //Clip
    public RuntimeAnimatorController townController;
    public RuntimeAnimatorController combatController;

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
        Debug.Log("1");
        Scene currentScene = SceneManager.GetActiveScene();
        animator = GetComponentInChildren<Animator>();
        if (currentScene.name != "TestRoom")
            this.enabled = false;
        else
            animator.SetBool("IsTown", true);


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
        if (Input.GetKeyDown(KeyCode.J))
        {
            showInventoryTab(3);
        }
    }

    private void FixedUpdate()
    { 
        if (move == 0) 
        { /*
            if (animator == null)
            {
                animator = GetComponentInChildren<Animator>();
                animator.SetBool("IsTown", true);
            }*/

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            Vector3 position = this.transform.position;
            Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;
            position += movement * runSpeed * Time.deltaTime;
            //play animation
            if (animator != null)
            {
                animator.SetFloat("Run", Math.Abs(movement.x));
                if (movement.x < 0)
                    transform.eulerAngles = new Vector3(0, 180, 0);
                else if (movement.x > 0)
                    transform.eulerAngles = new Vector3(0, 0, 0);
            }

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
