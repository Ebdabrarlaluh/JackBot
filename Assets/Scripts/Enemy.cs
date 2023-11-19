using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    bool goRight;
    public float flyTime = 1f;
    float remainTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainTime = flyTime;
    }
    void FixedUpdate()
    {
        if (goRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1); // Sağa baktığınızı temin etmek için scale'ı ayarlayın
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1); // Sola baktığınızı temin etmek için scale'ı ayarlayın
        }
        remainTime -= Time.deltaTime;
        if (remainTime <= 0f)
        {
            goRight = !goRight; // Süre dolduğunda yönü değiştir
            remainTime = flyTime; // Bekleme süresini yeniden ayarla
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(col.gameObject);
            EditorSceneManager.LoadScene("SampleScene");
        }

        if (col.CompareTag("Projectile"))
        {
            StartCoroutine(Levitate());
        }

    }
    private IEnumerator Levitate() 
    {
        rb.gravityScale = -5;
        yield return new WaitForSeconds(2f);
        rb.gravityScale = 2;
    }
}
