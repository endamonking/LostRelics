using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private float horizontal;
    private float vertical;

    // private Rigidbody2D body;
    private Rigidbody body;
    [SerializeField] private float runSpeed = 10.0f;
    [SerializeField] private Inventory inventory;





    void Start()
    {
        body = transform.Find("PlayerCollider").GetComponent<Rigidbody>();
    



    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 position = this.transform.position;
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;
        position += movement * runSpeed * Time.deltaTime;
        this.transform.position = position;
    }
}
