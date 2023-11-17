 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    public float jumpForce = 5;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 hareket = new Vector2(horizontalInput, 0f) * moveSpeed;
            rb.velocity = new Vector2(hareket.x, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
