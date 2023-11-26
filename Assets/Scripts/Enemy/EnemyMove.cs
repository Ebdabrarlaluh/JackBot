using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    bool goRight;
    float remainTime;
    float moveTime = 3f;
    float moveSpeed = 5f;
    private void Start()
    {
        remainTime = moveTime;
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
            remainTime = moveTime; // Bekleme süresini yeniden ayarla
        }
    }
}
