using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    public float jumpForce = 5;
    public float dashForce = 30;
    public float dashTime = 1;
    public float dashCooldown = 3;
    Animator playerAnimator;

    private bool m_FacingRight=true;
    private float horizontalInput;
    Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    private bool onGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, 0.25f, LayerMask.GetMask("Ground"));
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
        
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerAnimator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
