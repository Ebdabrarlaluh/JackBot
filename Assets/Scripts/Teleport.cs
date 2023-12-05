using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject tpBulletPrefab; // Mermi prefabı
    public Transform firePoint; // Mermi atış noktası
    public float bulletSpeed = 10f; // Mermi atış hızı

    void Update()
    {
        Vector2 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        if (Input.GetButtonDown("Fire1")) // Ateşleme tuşu
        {
            Fire(angle); // Ateşleme fonksiyonunu çağır
        }
    }

    void Fire(float angle)
    {
        GameObject bullet = Instantiate(tpBulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, angle)); // Mermiyi oluştur ve dönme açısını belirle
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed; 
    }
}
