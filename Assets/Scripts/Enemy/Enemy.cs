using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float heightIncrease = 2f; 
    public float levitateTime = 3f;
    public Animator animator;
    public float flyTime = 1f;
    private Vector3 oldPosition;

    void Start()
    {
        oldPosition = transform.position; 
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

        oldPosition = transform.position;
        animator.SetBool("levitate", false);
    }
}
