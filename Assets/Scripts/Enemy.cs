using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float heightIncrease = 2f; 
    public float levitateTime = 3f;
    public Animator animator;

    //bool goRight;
    public float flyTime = 1f;
    //float remainTime;
    private Vector3 oldPosition;
    void Start()
    {
        //remainTime = flyTime;
        oldPosition = transform.position;
        
    }
    void FixedUpdate()
    {
        //if (goRight)
        //{
        //    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        //    transform.localScale = new Vector3(-1, 1, 1); // Sağa baktığınızı temin etmek için scale'ı ayarlayın
        //}
        //else
        //{
        //    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        //    transform.localScale = new Vector3(1, 1, 1); // Sola baktığınızı temin etmek için scale'ı ayarlayın
        //}
        //remainTime -= Time.deltaTime;
        //if (remainTime <= 0f)
        //{
        //    goRight = !goRight; // Süre dolduğunda yönü değiştir
        //    remainTime = flyTime; // Bekleme süresini yeniden ayarla
        //}
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Projectile"))
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

        
        Vector3 targetHeight = transform.position + Vector3.up * heightIncrease; // Yükseklik artışının hedef pozisyonu

        float startTime = Time.time; // Başlangıç zamanını kaydet
        float passingTime = 0f; // Geçen süreyi sakla

        while (passingTime < levitateTime)
        {
            passingTime = Time.time - startTime; // Geçen süreyi hesapla
            float riseRatio = Mathf.Clamp01(passingTime / levitateTime); // Yukarı çıkma oranı
            animator.SetBool("levitate", true);
            // Yavaşça yukarı çıkma
            transform.position = Vector3.Lerp(oldPosition, targetHeight, riseRatio);
            
            yield return null;
        }

        
        yield return new WaitForSeconds(1f);

        //// Aşağı inme işlemi
        //startTime = Time.time; // Yeniden başlangıç zamanını kaydet
        //passingTime = 0f; // Geçen süreyi sıfırla

        //while (passingTime < levitateTime)
        //{
        //    passingTime = Time.time - startTime; // Geçen süreyi hesapla
        //    float fallRatio = Mathf.Clamp01(passingTime / levitateTime); // Aşağı inme oranı

        //    // Yavaşça aşağı inme
        //    transform.position = Vector3.Lerp(targetHeight, oldPosition, fallRatio);

        //    yield return null;
        //}



        oldPosition = transform.position;
        animator.SetBool("levitate", false);

    }
}
