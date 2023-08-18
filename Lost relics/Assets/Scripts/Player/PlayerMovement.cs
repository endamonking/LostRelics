using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public float runSpeed = 20.0f;


    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log(collision.collider.name);
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
