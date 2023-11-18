using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPlatform : MonoBehaviour
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
        float yeniX = Mathf.PingPong(Time.time * hareketHizi, hareketMesafesi) + baslangicPozisyonu.x;
        transform.position = new Vector3(yeniX, transform.position.y, transform.position.z);
    }
}
