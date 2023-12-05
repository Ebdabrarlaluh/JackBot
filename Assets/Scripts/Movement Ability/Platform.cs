using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float hareketMesafesi = 5f; // Platformun hareket edeceği mesafe
    public float hareketHizi = 2f; // Platformun hareket hızı
    bool isFreezed = false;
    CountDown countDown;
    public bool upDown = true;

    private Vector3 baslangicPozisyonu;

    void Start()
    {
        baslangicPozisyonu = transform.position;
        countDown = gameObject.AddComponent<CountDown>();
    }

    void Update()
    {
        if (!isFreezed && upDown)
        {
            float yeniY = Mathf.PingPong(Time.time * hareketHizi, hareketMesafesi) + baslangicPozisyonu.y;
            transform.position = new Vector3(transform.position.x, yeniY, transform.position.z);
        }
        else if (!isFreezed)
        {
            float yeniX = Mathf.PingPong(Time.time * hareketHizi, hareketMesafesi) + baslangicPozisyonu.x;
            transform.position = new Vector3(yeniX, transform.position.y, transform.position.z);
        }
        if (countDown.Bitti)
        {
            isFreezed = false;
        }
        
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {        
            col.transform.parent = transform; 
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("IceBullet"))
        {
            countDown.ToplamSure = 5;
            countDown.Calistir();
            Destroy(col.gameObject);
            isFreezed = true;
        }
    }
}
