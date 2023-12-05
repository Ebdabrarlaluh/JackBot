using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Animator animator; 
    CountDown freezeCountDown;
    CountDown countDown;

    public GameObject bullet;
    public float bulletSpeed = 5f;
    public int direction;
    bool isFreezed=false;
    
    void Start()
    {
        freezeCountDown = gameObject.AddComponent<CountDown>();
        countDown = gameObject.AddComponent<CountDown>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        countDown.ToplamSure = 4;
        countDown.Calistir();
        
        if (direction==1)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction==-1)
        {
            spriteRenderer.flipX = false;
        }
    }
    void Update()
    {
        if (!isFreezed)
        {
            if (countDown.Bitti)
            {
                Fire();
            }
        }
        if (freezeCountDown.Bitti)
        {
            isFreezed = false;
            animator.SetBool("isFreezed", false);
        }
    }
    void Fire()
    {
        GameObject mermi = Instantiate(bullet, new Vector2(transform.position.x + (2 * direction), transform.position.y), transform.rotation);
        Rigidbody2D bulletRB = mermi.GetComponent<Rigidbody2D>();
        bulletRB.velocity = bulletSpeed * direction * transform.right;
        countDown.Calistir();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("IceBullet"))
        {
            isFreezed = true;
            freezeCountDown.ToplamSure = 6;
            animator.SetBool("isFreezed", true);
            freezeCountDown.Calistir();
        }
    }
}
