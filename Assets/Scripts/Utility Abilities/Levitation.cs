using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitation : MonoBehaviour
{
    public GameObject mermiPrefab; 
    public Transform ateşNoktası;
    public KeyCode fireKeyCode = KeyCode.E;
    public float bulletSpeed =25f;
    public float delayTime=3f;
    int lookRight = 1;
    bool fireOn = true;
    Rigidbody2D rb;

    void Update()
    {
        if (Input.GetKeyDown(fireKeyCode) && fireOn)
        { 
            Fire();
            fireOn = false;
            StartCoroutine("ReloadTime");
        }
        ; // Varsayılan olarak sağa bakıyor varsayalım

        // Karakterin yönünü hareketine göre güncelleme örneği
        float hareketYonu = Input.GetAxis("Horizontal");
        if (hareketYonu > 0)
        {
            lookRight = 1;
        }
        else if (hareketYonu < 0)
        {
            lookRight = -1;
        }
    }

    void Fire()
    {
        GameObject mermi = Instantiate(mermiPrefab, ateşNoktası.position, Quaternion.identity);
        rb = mermi.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(lookRight * bulletSpeed,0);
        }
    }
    private IEnumerator ReloadTime() 
    {
        yield return new WaitForSeconds(delayTime);
        fireOn = true;
    }
}
