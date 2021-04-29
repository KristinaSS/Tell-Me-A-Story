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
    private float jumpForce = 100f;
    
    private static readonly string ANIMATION_H_SPEED = "hSpeed";
    private static readonly string ANIMATION_V_SPEED = "vSpeed";
    private static readonly string ANIMATION_EX_SPEED = "exSpeed";
    private static readonly string ANIMATION_JUMP = "jump";
    private static readonly string ANIMATION_GROUNDED = "grounded";
    private static readonly string ANIMATION_DASHING = "dashing";
    private static readonly string ANIMATION_WALL = "onWall";
    private static readonly string ANIMATION_FACING = "facingRight";
    private static readonly string ANIMATION_LADDER = "onLadder";
    private static readonly string ANIMATION_INVULNERABLE = "invulnerable";


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
            jumpForce = 50f;
        }
        else if (avatar2.activeSelf)
        {
            rb.gravityScale = 5;
            moveSpeed = 50f;
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            jumpForce = 0f;
        }
        else
        {
            rb.gravityScale = 2;
            moveSpeed = 2f;
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            jumpForce = 100f;
        }
    }

    private void DoJump()
    {
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        }
    }

}


