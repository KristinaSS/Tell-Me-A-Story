using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Move : SwitchCharachters
{
    private Rigidbody2D rb;
    private Collider2D playerCollider;
    private Collider2D groundCollider;
    private float dirX;
    private float moveSpeed = 10f;
    private float jumpForce = 700f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
            DoJump();

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        

    }

    void FixedUpdate()
    {
        if (avatar1.activeSelf)
        {
            rb.gravityScale = 5;
            moveSpeed = 10f;
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        else if (avatar2.activeSelf)
        {
            rb.gravityScale = 5;
            moveSpeed = 20f;
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.gravityScale = 2;
            moveSpeed = 10f;
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
    }

    public void DoJump()
    {
        
        
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        }
    }

}
