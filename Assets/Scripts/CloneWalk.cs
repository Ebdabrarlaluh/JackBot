using UnityEngine;

public class CloneWalk : MonoBehaviour
{
    public float cloneLiveTime = 4f;
    Rigidbody2D rb;

    void Start()
    {
        // Klonun oluşturulduğu anda sadece ileri yönde hareket etmesi
        rb = GetComponent<Rigidbody2D>();
        
        rb.gravityScale = 0f;
        // Hareket yönüne ve hızına göre klona bir hareket vektörü uygulama
    }
    void Update()
    {
        if (cloneLiveTime <= 0)
        {
            Destroy(gameObject);
        }
        cloneLiveTime -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
