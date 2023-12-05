using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 5;
    float friction = 0.1f;
    float horizontalInput;

    [SerializeField] private Transform GroundCheck;
    private bool onGround;

    SpriteRenderer spriteRenderer;
    Animator playerAnimator; 
    Rigidbody2D rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, 0.25f, LayerMask.GetMask("Ground"));
        horizontalInput = Input.GetAxis("Horizontal");
        float movement = horizontalInput * moveSpeed;
        
        if (horizontalInput != 0)
        { 
            rb.velocity = new Vector2(movement, rb.velocity.y);
            playerAnimator.SetBool("isMoving", true);
            transform.parent = null;
        }
        else
        {
            rb.velocity = new Vector2(movement * friction, rb.velocity.y); //Burası Grapple Gunda bozulmaya neden oluyor
            playerAnimator.SetBool("isMoving", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && onGround || Input.GetKeyDown(KeyCode.W) && onGround)
        {
            playerAnimator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
