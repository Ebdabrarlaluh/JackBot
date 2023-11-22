using UnityEngine;

public class CloneWalk : MonoBehaviour
{
    public float hareketHizi =5f; // Klonun hareket hızı
    public float cloneLiveTime = 4f;
    Vector2 moveDirection;
    Rigidbody2D rb;

    void Start()
    {
        // Klonun oluşturulduğu anda sadece ileri yönde hareket etmesi
        rb = GetComponent<Rigidbody2D>();
        
        rb.gravityScale = 1.0f;
        // Hareket yönüne ve hızına göre klona bir hareket vektörü uygulama
    }
    void Update()
    {
        float hareketYonu = Input.GetAxis("Horizontal");
        // Sadece ileri yönde bir hareket vektörü oluşturma
        if (hareketYonu > 0)
        {
            moveDirection = Vector2.right;
        }
        else
        {
            moveDirection = Vector2.left;
        }
        // Hareket yönüne ve hızına göre klona bir hareket vektörü uygulama
        rb.velocity = moveDirection * hareketHizi;
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
