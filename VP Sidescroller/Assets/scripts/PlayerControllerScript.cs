using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    public float maxSpeed = 21f;
    bool facingRight = true;

    private SpriteRenderer mySpriteRenderer;

    Rigidbody2D playerRigidbody2D;

    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 24f;

    // Use this for initialization
    void Start ()

    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        playerRigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", playerRigidbody2D.velocity.y);

        float move = Input.GetAxis("Horizontal");

        if (anim.GetBool("Attack") == false)
            anim.SetFloat("Speed", Mathf.Abs(move));

        playerRigidbody2D.velocity = new Vector2(move * maxSpeed, playerRigidbody2D.velocity.y);
        if (playerRigidbody2D.velocity.x > 0 && mySpriteRenderer.flipX == true) //if moving right
            mySpriteRenderer.flipX = false;
        else if (playerRigidbody2D.velocity.x <= 0 && mySpriteRenderer == false) // if moving left
            mySpriteRenderer.flipX = true;

	}

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("Ground", false);
            playerRigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
