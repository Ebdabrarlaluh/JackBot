using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float cloneDelay;
    private float cloneDelaySeconds;
    public GameObject clone;
    Vector2 moveDirection = Vector2.right;
    SpriteRenderer cloneSprite;

    public KeyCode cloneKeyCode=KeyCode.K;
    void Start()
    {
        cloneDelaySeconds = 0;
        cloneSprite = clone.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float hareketYonu = Input.GetAxis("Horizontal");

        if (hareketYonu > 0)
        {
            moveDirection = Vector2.right;
            cloneSprite.flipX = false;
        }
        else if (hareketYonu < 0)
        {
            moveDirection = Vector2.left;
            cloneSprite.flipX = true;
        }
        
        if (cloneDelaySeconds > 0)
        {
            cloneDelaySeconds -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(cloneKeyCode))
            {
                GameObject newClone = Instantiate(clone, new Vector2(transform.position.x + moveDirection.x, transform.position.y), transform.rotation);
                Rigidbody2D rb = newClone.GetComponent<Rigidbody2D>();
                rb.velocity = moveDirection * moveSpeed;
                cloneDelaySeconds = cloneDelay;
            }
        }
    }
}
