using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] bool canJump = true;
    [SerializeField] float gravityIndex = 1f;

    public GameObject deathMenu;
    public GameObject playerButtons;

    private bool pauseGame = false;

    //State
    bool isAlive = true;

    //Cached component references
    public Rigidbody2D rb;
    public Animator myAnimator;
    public CapsuleCollider2D myBodyCollider;
    public BoxCollider2D myFeet;
    public float gravityScaleAtStart;
    public Joystick joystick;
    public Joybutton joybutton;
    public GameObject avatar1, avatar2, avatar3;

    // Message then methods
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        deathMenu.SetActive(false);
        playerButtons.SetActive(true);

        gravityScaleAtStart = rb.gravityScale;
        joybutton = FindObjectOfType<Joybutton>();
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!isAlive) { return; }
        myAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        myBodyCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        myFeet = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        Run();
        Jump();
        ClimbLadder();
        FlipSprite();
        Die();
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
        if (!canJump || !myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (joybutton.Pressed)
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rb.velocity = jumpVelocity;
            rb.gravityScale = gravityIndex;
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

    public void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");

            /*FindObjectOfType<GameSession>().ProcessPlayerDeath();*/

            StartCoroutine(SimulateDying());

        }
    }

    IEnumerator SimulateDying()
    {
        yield return new WaitForSecondsRealtime(1f);
        deathMenu.SetActive(true);
        playerButtons.SetActive(false);

        ToggleTime();
    }

    private void ToggleTime()
    {
        pauseGame = !pauseGame;

        Time.timeScale = pauseGame ? 0 : 1;
    }

    public void Retry()
    {
        ToggleTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SwitchAvatarOne()
    {
        canJump = true;
        jumpSpeed = 30f;
        gravityIndex = 1f;
        rb.velocity = Vector2.zero;
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
    }

    public void SwitchAvatarTwo()
    {
        canJump = true;
        jumpSpeed = 40f;
        gravityIndex = 0f;
        rb.velocity = Vector2.zero;
        avatar1.gameObject.SetActive(false);
        avatar2.gameObject.SetActive(true);
        avatar3.gameObject.SetActive(false);
    }

    public void SwitchAvatarThree()
    {

        canJump = false;
        gravityIndex = 0.5f;
        rb.velocity = Vector2.zero;
        avatar1.gameObject.SetActive(false);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(true);
    }

}
