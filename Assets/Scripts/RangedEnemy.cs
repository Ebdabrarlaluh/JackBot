using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    //bool goRight;
    //float remainTime;
    public GameObject bullet;
    float bulletSpeed = 5f;
    CountDown countDown;
    void Start()
    {
        countDown = gameObject.AddComponent<CountDown>();
        countDown.ToplamSure = 3;
        countDown.Calistir();
        //remainTime = flyTime;
        if (countDown.Bitti)
        {
            Fire();
        }
    }

    void Update()
    {
        
    }
    void Fire()
    {
        GameObject mermi = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D bulletRB = mermi.GetComponent<Rigidbody2D>();
        bulletRB.velocity = transform.right * bulletSpeed;    
    }
    //void FixedUpdate()
    //{
    //if (goRight)
    //{
    //    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    //    transform.localScale = new Vector3(-1, 1, 1); // Sağa baktığınızı temin etmek için scale'ı ayarlayın
    //}
    //else
    //{
    //    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    //    transform.localScale = new Vector3(1, 1, 1); // Sola baktığınızı temin etmek için scale'ı ayarlayın
    //}
    //remainTime -= Time.deltaTime;
    //if (remainTime <= 0f)
    //{
    //    goRight = !goRight; // Süre dolduğunda yönü değiştir
    //    remainTime = flyTime; // Bekleme süresini yeniden ayarla
    //}
    //}
}
