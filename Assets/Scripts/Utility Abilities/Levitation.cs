using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitation : MonoBehaviour
{
    public GameObject mermiPrefab; 
    public Transform gun;
    public Transform firePoint;
    public KeyCode fireKeyCode = KeyCode.E;
    public float bulletSpeed =25f;
    public float delayTime=3f;
    float rotationSpeed = 10f;
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
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RotateGun(mousePos);
    }
    void RotateGun(Vector3 lookPoint)
    {
        Vector3 distanceVector = lookPoint - gun.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Lerp(gun.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
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
