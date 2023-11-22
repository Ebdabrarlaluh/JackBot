using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 5;
    Rigidbody2D rb;
    Animator playerAnimator;
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
        if (Input.GetKeyDown(KeyCode.Space) && onGround || Input.GetKeyDown(KeyCode.W) && onGround)
        {
            playerAnimator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
