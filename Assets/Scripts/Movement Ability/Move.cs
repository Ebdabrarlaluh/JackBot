using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;

    Animator playerAnimator;

    private bool m_FacingRight=true;
    private float horizontalInput;
    Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;

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
        

        if (horizontalInput > 0 && !m_FacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            m_FacingRight = true;
        }
        else if (horizontalInput < 0&& m_FacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            m_FacingRight = false;
        }

    }

    
}
