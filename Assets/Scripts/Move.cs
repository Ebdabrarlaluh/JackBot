 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    public float jumpForce = 5;
    Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    private bool onGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
}
