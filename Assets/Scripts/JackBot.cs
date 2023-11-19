using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackBot : MonoBehaviour
{
    public float gorunmeSuresi = 20f; // Objenin ekranda kalacağı süre
    private float zamanlayici;

    void Start()
    {
        zamanlayici = gorunmeSuresi; // Zamanlayıcıyı başlat
    }

    void Update()
    {
        zamanlayici -= Time.deltaTime;

        if (zamanlayici <= 0f)
        {
            gameObject.SetActive(false); // Objeyi devre dışı bırak
            // gameObject.SetActive(true); // Eğer objenin tekrar görünmesini istiyorsanız bu satırı ekleyebilirsiniz
            zamanlayici = gorunmeSuresi; // Zamanlayıcıyı sıfırla veya tekrar başlat
        }
    }
}
