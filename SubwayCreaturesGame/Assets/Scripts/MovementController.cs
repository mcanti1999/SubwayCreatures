using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpStrength = 10f;
    public float fastFallStrength = 10f;
    public LayerMask groundLayer;
    private Rigidbody2D playerBody;
    private bool _jump = false;
    private bool _canFastFall = false;
    private void Awake()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Move();
        //jump
        if(_jump && IsGrounded()) {
            playerBody.AddForce(new Vector2(0f, jumpStrength), ForceMode2D.Impulse);
            _jump = false;
        }
        //fast falling
        if (_canFastFall)
        {
            playerBody.AddForce(new Vector2(0f,-fastFallStrength));
            
        }
    }

    void Update()
    {
        Jump();
        IsGrounded();
        FastFall();
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
    //draws raycast and checks if we are standing on the ground
    bool IsGrounded()
    {
        Vector2 pos = transform.position;
        Vector2 dir = Vector2.down;
        float distance = GetComponent<BoxCollider2D>().bounds.size.y/2 + 0.05f;
        Debug.DrawRay(pos,dir,Color.red);
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, distance, groundLayer);
        if (hit.collider != null)
        {
            _canFastFall = false;
            return true;
        }
        return false;
    }
    //fast falling is a mechanic popular in platform fighters like super smash bros
    void FastFall()
    {
        if (playerBody.velocity.y < 1 && Input.GetKeyDown(KeyCode.S) && !IsGrounded())
        {
            
            _canFastFall = true;
        }
    }
}
