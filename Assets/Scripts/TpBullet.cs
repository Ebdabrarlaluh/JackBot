using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpBullet : MonoBehaviour
{
    private bool isCollided = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isCollided && !col.gameObject.CompareTag("Player")) 
        {
            isCollided = true; 
            StartCoroutine(Teleport(col.contacts[0].point));
        }
    }

    IEnumerator Teleport(Vector3 contactPoint)
    {
        yield return new WaitForSeconds(0.1f);

        GameObject karakter = GameObject.FindGameObjectWithTag("Player");
        karakter.transform.position = new Vector2(contactPoint.x, contactPoint.y+1);
        Destroy(gameObject);
    }
}
