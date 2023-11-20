using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPlatform : MonoBehaviour
{
    public float hareketMesafesi = 5f; // Platformun hareket edeceği mesafe
    public float hareketHizi = 2f; // Platformun hareket hızı

    private Vector3 baslangicPozisyonu;

    void Start()
    {
        baslangicPozisyonu = transform.position;
    }

    void Update()
    {
        float yeniY = Mathf.PingPong(Time.time * hareketHizi, hareketMesafesi) + baslangicPozisyonu.y;
        transform.position = new Vector3(transform.position.x, yeniY, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D col)
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
}
