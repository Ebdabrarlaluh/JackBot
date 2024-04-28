using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public KeyCode fireKeyCode = KeyCode.F;
    CountDown countDown;

    private void Start()
    {
        countDown = gameObject.AddComponent<CountDown>();
        countDown.ToplamSure = 3;
        countDown.Calistir();
    }

    void Update()
    {
        if (Input.GetKeyDown(fireKeyCode))
        {
            if (countDown.Bitti)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                countDown.Calistir();
            }
        }
    }   
}


 



    

