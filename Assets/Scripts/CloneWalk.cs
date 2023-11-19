using UnityEngine;

public class CloneWalk : MonoBehaviour
{
    public float hareketHizi =5f; // Klonun hareket hızı
    public float cloneLiveTime = 4f;

    void Start()
    {
        // Klonun oluşturulduğu anda sadece ileri yönde hareket etmesi
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Sadece ileri yönde bir hareket vektörü oluşturma
        Vector2 hareketYonu = transform.right;
        rb.gravityScale = 1.0f;
        // Hareket yönüne ve hızına göre klona bir hareket vektörü uygulama
        rb.velocity = hareketYonu * hareketHizi;
    }
    void Update()
    {
        // Sadece ileri yönde bir hareket vektörü oluşturma
        Vector2 hareketYonu = transform.right;

        // Hareket yönüne ve hızına göre klona bir hareket vektörü uygulama
        GetComponent<Rigidbody2D>().velocity = hareketYonu * hareketHizi;
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
