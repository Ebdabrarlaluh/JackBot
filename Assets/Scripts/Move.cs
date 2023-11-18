using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5;
    Animator playerAnimator;

    private float horizontalInput;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        float movement = horizontalInput * moveSpeed;

        if (horizontalInput != 0)
        {
            rb.velocity = new Vector2(movement, rb.velocity.y);
            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Sağa doğru yürüyor, scale'ı orijinal hale getir
            transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            
            transform.localScale = new Vector3(-1f, 1f, 1f); // Sola doğru yürüyor, scale'ı -1 katı al
            transform.GetChild(0).localScale = new Vector3(1f, 1f, 1f);
        }
        
    }
}
