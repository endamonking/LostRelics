using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    private float horizontal;
    private float vertical;
   
     private Rigidbody2D body;
    [SerializeField] private  float runSpeed = 20.0f;
    [SerializeField] private Inventory inventory;
   
 

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log(collision.collider.name);
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Item item = AssetDatabase.LoadAssetAtPath<Item>($"Assets/Items/Helmet.asset");
        inventory.AddItem(item);
        inventory.EquipItem(item);
        
        
       
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
