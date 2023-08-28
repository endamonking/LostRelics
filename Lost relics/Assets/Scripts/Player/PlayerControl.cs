using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    private float horizontal;
    private float vertical;
    public Stats stats;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private  float runSpeed = 20.0f;


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
