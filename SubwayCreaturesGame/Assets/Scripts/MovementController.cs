using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpStrength = 10f;
    public LayerMask groundLayer;
    private Rigidbody2D playerBody;
    private bool _jump = false;

    
    private void Awake()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Move();
        if(_jump && IsGrounded()) {
            playerBody.AddForce(new Vector2(0f, jumpStrength), ForceMode2D.Impulse);
            _jump = false;
        }
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
            _jump = true;
        }
    }

    bool IsGrounded()
    {
        Vector2 pos = transform.position;
        Vector2 dir = Vector2.down;
        float distance = GetComponent<BoxCollider2D>().bounds.size.y/2 + 0.05f;
        Debug.DrawRay(pos,dir,Color.red);
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
