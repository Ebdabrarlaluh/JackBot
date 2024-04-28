using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitation : MonoBehaviour
{
    public GameObject mermiPrefab; 
    public Transform firePoint;
    public KeyCode fireKeyCode = KeyCode.E;
    public float bulletSpeed =25f;
    public float delayTime=3f;
    bool fireOn = true;
    public AudioSource audio;
    Rigidbody2D rb;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(fireKeyCode) && fireOn)
        { 
            Fire();
            fireOn = false;
            StartCoroutine("ReloadTime");
        }
    }
    
    void Fire()
    {
        audio.Play();
        GameObject mermi = Instantiate(mermiPrefab, firePoint.position, Quaternion.identity);
        rb = mermi.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 characterPosition = rb.position;

            Vector2 direction = (mousePosition - characterPosition).normalized;

            rb.velocity = direction * bulletSpeed;
        }
    }
    private IEnumerator ReloadTime() 
    {
        yield return new WaitForSeconds(delayTime);
        fireOn = true;
    }
}
