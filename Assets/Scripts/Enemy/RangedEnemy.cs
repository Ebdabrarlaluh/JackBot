using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    CountDown freezeCountDown;
    CountDown countDown;
    Animator animator;
    
    private bool isFreezed = false;
    public bool rotateAxisX;
    public bool rotateAxisY;
    
    public GameObject bullet;
    public Transform firePoint;
    
    public float bulletSpeed = 5f;
    
    void Start()
    {
        freezeCountDown = gameObject.AddComponent<CountDown>();
        countDown = gameObject.AddComponent<CountDown>();
        animator = GetComponent<Animator>();
        
        countDown.ToplamSure = 4;
        countDown.Calistir();
        if (rotateAxisX)
        {
            transform.Rotate(0, 180, 0);
        }
        if (rotateAxisY)
        {
            transform.Rotate(180, 0, 0);
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
        if (rotateAxisX)
        {
            transform.Rotate(0, 180, 0);
        }
        if (rotateAxisY)
        {
            transform.Rotate(180, 0, 0);
        }
    }
    void Fire()
    {
        GameObject mermi = Instantiate(bullet, firePoint.position, transform.rotation);
        Rigidbody2D bulletRB = mermi.GetComponent<Rigidbody2D>();
        bulletRB.velocity = bulletSpeed * -transform.right;
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
