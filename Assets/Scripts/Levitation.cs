using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject mermiPrefab; 
    public Transform ateşNoktası;
    public KeyCode fireKeyCode = KeyCode.E;
    Rigidbody2D rb;

    void Update()
    {
        if (Input.GetKeyDown(fireKeyCode))
        { 
            AtesEt();
        }
    }

    void AtesEt()
    {
        GameObject mermi = Instantiate(mermiPrefab, ateşNoktası.position, Quaternion.identity);
        rb = mermi.GetComponent<Rigidbody2D>();
        //rb.velocity =;
    }
}
