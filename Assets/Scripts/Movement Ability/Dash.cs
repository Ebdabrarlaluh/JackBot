using UnityEngine;

public class Dash : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin normal hareket hızı
    public float stoppingDistance = 1f; // Hedefe ulaşıldığında duracak mesafe

    private Vector2 targetPosition; // Fare tıklaması sonucu hedeflenen pozisyon
    private Vector2 startPosition;
    private bool isMoving = false; // Karakter hareket ediyor mu?
    private bool isDash = false;

    public Transform player;

    public GhostEffect ghost;

    public KeyCode dashKeyCode = KeyCode.J;

    void Update()
    {
        if (Input.GetKeyDown(dashKeyCode)) // Fare sol tuşuna tıklama algılama
        {
            SetTargetPosition(); // Hedef pozisyonu belirle
        }

        if (isMoving)
        {
            ghost.makeGhost = true;
            MovePlayer(); // Karakteri hareket ettir
        }
    }

    void SetTargetPosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Fare konumunu ekran koordinatlarından dünya koordinatlarına dönüştür
        targetPosition = new Vector2(mousePosition.x, mousePosition.y); // Hedef pozisyonu ayarla
        isMoving = true; // Hareket durumunu aktif et
        isDash = true;
    }

    void MovePlayer()
    {
        if (isDash)
        {
            startPosition = transform.position;
            isDash = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); // Hedefe doğru hareket et

        if(Vector2.Distance(transform.position, targetPosition) == 0) {
            isMoving = false;
            ghost.makeGhost = false;
        }
        if (Vector2.Distance(startPosition, targetPosition)-Vector2.Distance(transform.position, targetPosition)>=stoppingDistance) // Hedefe belirli bir mesafede mi?
        {
            isMoving = false; // Hareket durumunu kapat
            ghost.makeGhost = false;
        }
    }
}