using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpStrength = 10f;
    public LayerMask groundLayer;
    private Rigidbody2D _rigidbody2D;

    
    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Jump();
        IsGrounded();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * (Time.deltaTime * moveSpeed);
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody2D.AddForce(new Vector2(0f, jumpStrength), ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        Vector2 pos = transform.position;
        Vector2 dir = Vector2.down;
        float distance = GetComponent<BoxCollider2D>().bounds.size.y/2 + 0.05f;
        Debug.Log(distance);
        Debug.DrawRay(pos,dir,Color.red);
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
