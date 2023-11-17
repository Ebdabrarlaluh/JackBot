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

    float horizontalInput;
    bool canDash = true;
    bool isDashing = false;
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
        if (true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float movement = horizontalInput * moveSpeed;
            rb.velocity = new Vector2(movement, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Z) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash() 
    {
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(horizontalInput * dashForce, 0f);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = 1f;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
