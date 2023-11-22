using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5;

    Animator playerAnimator;
    SpriteRenderer spriteRenderer;
  
    private float horizontalInput;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
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
            playerAnimator.SetBool("isMoving", false);
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
