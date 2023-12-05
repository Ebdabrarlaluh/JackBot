using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float bulletSpeed = 10f; // Mermi hızı

    private Vector2 mousePosition; // Fare tıklama noktası
    private Vector2 moveDirection; // Mermi hareket yönü

    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Fare tıklama noktasını alır
        moveDirection = (mousePosition - (Vector2)transform.position).normalized; // Mermi hareket yönünü belirler
    }

    void Update()
    {
        // Mermi, fare konumuna doğru hareket eder
        transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }  
    }
}
