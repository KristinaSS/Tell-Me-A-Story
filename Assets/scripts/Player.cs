using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;

    //State
    //bool isAlive = true;

    //Cached component references
    public Rigidbody2D rb;
    public Animator myAnimator;
    public CapsuleCollider2D myBodyCollider;
    public BoxCollider2D myFeet;
    public float gravityScaleAtStart;
    public Joystick joystick;
    public Joybutton joybutton;

    // Message then methods
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        gravityScaleAtStart = rb.gravityScale;
        joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        myBodyCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        myFeet = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        Run();
        Jump();
        ClimbLadder();
        FlipSprite();
    }

    private void Run()
    {
        float horizontalSpeed;
        if (joystick.Horizontal >= .2f)
        {
            horizontalSpeed = runSpeed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalSpeed = -runSpeed;
        }
        else
        {
            horizontalSpeed = 0f;
        }
        //float controlThrow = joystick.Horizontal; // -1 -> 0 -> 1
        Vector2 playerVelocity = new Vector2(horizontalSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            myAnimator.SetBool("Running", true);
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }
    }

    private void ClimbLadder()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("Climbing", false);
            rb.gravityScale = gravityScaleAtStart;
            return;
        }

        /*float controlThrow = Input.GetAxisRaw("Vertical");
        Vector2 climbVelocity = new Vector2(rb.velocity.x, controlThrow * climbSpeed);
        rb.velocity = climbVelocity;*/
        float VerticalSpeed;
        if (joystick.Vertical >= .2f)
        {
            VerticalSpeed = climbSpeed;
            rb.gravityScale = 0f;
        }
        else if (joystick.Vertical <= -.2f)
        {
            VerticalSpeed = -climbSpeed;
            rb.gravityScale = 0f;
        }
        else
        {
            VerticalSpeed = 0f;
        }
        Vector2 climbVelocity = new Vector2(rb.velocity.x, VerticalSpeed);
        rb.velocity = climbVelocity;


        if (Mathf.Abs(rb.velocity.y) > Mathf.Epsilon)
        {
            myAnimator.SetBool("Climbing", true);
        }

    }
    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; } //if it's in the air we don't continue

        if (joybutton.Pressed)
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rb.velocity = jumpVelocity;
        }
        /*if(Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rb.velocity = jumpVelocity;
        }*/
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            GameObject.FindGameObjectWithTag("Player").transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
}
