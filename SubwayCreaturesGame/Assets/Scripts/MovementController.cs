using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpStrength = 10f;
    public bool isGrounded = false;

    private Rigidbody2D _rigidbody2D;

    
    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Jump();
       
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * (Time.deltaTime * moveSpeed);
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rigidbody2D.AddForce(new Vector2(0f, jumpStrength), ForceMode2D.Impulse);
        }
    }
}
