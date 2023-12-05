using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'ı
    public Transform gun; // Silahın Transform bileşeni
    public Transform firePoint;
    float rotationSpeed =10f;
    CountDown countDown;

    private void Start()
    {
        countDown = gameObject.AddComponent<CountDown>();
        countDown.ToplamSure = 3;
        countDown.Calistir();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (countDown.Bitti)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                countDown.Calistir();
            }
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
}



    

