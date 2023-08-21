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
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        
        Vector2 position = body.position;
        position.x += horizontal * runSpeed * Time.deltaTime;
        position.y += vertical * runSpeed * Time.deltaTime;
        body.MovePosition(position);
    }
}
