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

  
    [SerializeField] private float runSpeed = 10.0f;
   // [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject PlayerCanvas;
    [SerializeField] private GameObject player;
    [SerializeField]
    private BoxCollider footCollider;

    private int move =0;
    private bool isOpenOtherTab = false;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        
    }
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        if (currentScene.name != "TestRoom")
        {
            this.enabled = false;
            footCollider.center = new Vector3(0, -0.4f, -0.4f);
            spriteRenderer.flipX = false;
            Destroy(rb);
        }
        else
        {
            animator.SetBool("IsTown", true);
            footCollider.center = new Vector3(0, -0.2f, -0.3f);
            
        }


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
        { 


            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            //Vector3 position = this.transform.position;
            Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;
            //position += movement * runSpeed * Time.deltaTime;
            rb.velocity = new Vector3(horizontal*runSpeed, 0, vertical*runSpeed);
            //play animation
            if (animator != null)
            {
                animator.SetFloat("Run", Math.Abs(movement.x)+ Math.Abs(movement.z));
                if (movement.x < 0)
                {
                    //transform.eulerAngles = new Vector3(0, 180, 0);
                    spriteRenderer.flipX = true;
                }
                else if (movement.x > 0)
                {
                    //transform.eulerAngles = new Vector3(0, 0, 0);
                    spriteRenderer.flipX = false;
                }
            }

            //this.transform.position = position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {

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
        rb.velocity = new Vector3(0,0,0);
        isOpenOtherTab = true;
    }

    public void resumePlaterMovement()
    {
        move = 0;
        isOpenOtherTab = false;
    }

    public void playerSetAnimTown()
    {
        animator.SetBool("IsTown", true);
    }
}
