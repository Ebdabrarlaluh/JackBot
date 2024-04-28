using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    bool goRight;
    float remainTime;
    float moveTime = 3f;
    float moveSpeed = 5f;
    bool isFreezed = false;
    CountDown countDown;
    public Animator animator;
    Vector3 oldPosition;
    public float heightIncrease = 2f;
    public float levitateTime = 3f;

    public float flyTime = 1f;

    private void Start()
    {
        remainTime = moveTime;
        countDown = gameObject.AddComponent<CountDown>(); 
    }
    void FixedUpdate()
    {
        if (!isFreezed)
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
                remainTime = moveTime; // Bekleme süresini yeniden ayarla
            }
        }
        if (countDown.Bitti)
        {
            isFreezed = false;
            animator.SetBool("isFreeze", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("IceBullet"))
        {
            countDown.ToplamSure = 5;
            countDown.Calistir();
            Destroy(col.gameObject);
            animator.SetBool("isFreeze", true);
            isFreezed = true;
        }
        if (col.CompareTag("Bubblet"))
        {
            StartCoroutine(Levitate());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(col.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    private IEnumerator Levitate()
    {
        isFreezed = true;
        oldPosition = transform.position;
        Vector3 targetHeight = transform.position + Vector3.up * heightIncrease; // Yükseklik artışının hedef pozisyonu

        float startTime = Time.time; // Başlangıç zamanını kaydet
        float passingTime = 0f; // Geçen süreyi sakla

        while (passingTime < levitateTime)
        {
            passingTime = Time.time - startTime; // Geçen süreyi hesapla
            float riseRatio = Mathf.Clamp01(passingTime / levitateTime); // Yukarı çıkma oranı
            animator.SetBool("isLevitate", true);
            // Yavaşça yukarı çıkma
            transform.position = Vector3.Lerp(oldPosition, targetHeight, riseRatio);

            yield return null;
        }

        yield return new WaitForSeconds(1.5f);

        oldPosition = transform.position;
        animator.SetBool("isLevitate", false);
        isFreezed = false;
    }
}


