using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 5f;
    CountDown countDown;
    public int direction;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        countDown = gameObject.AddComponent<CountDown>();
        countDown.ToplamSure = 3;
        countDown.Calistir();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (countDown.Bitti)
        {
            Fire();
        }
        
    }
    void Fire()
    {
        GameObject mermi = Instantiate(bullet, new Vector2(transform.position.x + (2 * direction), transform.position.y), transform.rotation);
        Rigidbody2D bulletRB = mermi.GetComponent<Rigidbody2D>();
        bulletRB.velocity = bulletSpeed * direction * transform.right;
        countDown.Calistir();
    }
}
