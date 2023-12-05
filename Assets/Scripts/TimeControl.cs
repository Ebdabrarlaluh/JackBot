using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    float normalTimeScale = 1.0f; // Normal zaman ölçeği (1.0 = normal hız)
    float yavasZamanOlcegi = 0.5f; // Yavaş zaman ölçeği (0.5 = yarı hız)
    public KeyCode keyCode = KeyCode.T;
    CountDown countDown;
    CountDown cooldown;

    void Start()
    {
        countDown = gameObject.AddComponent<CountDown>();
        cooldown = gameObject.AddComponent<CountDown>();
    }
    void Update()
    {
        
        if (Input.GetKeyDown(keyCode))
        {
            Time.timeScale = yavasZamanOlcegi;
            //countDown.ToplamSure = 5;
            //countDown.Calistir();
        }
        if (Input.GetKeyUp(keyCode))
        {
            Time.timeScale = normalTimeScale;
        }

        if (countDown.Bitti)
        {
            Time.timeScale = normalTimeScale;
            cooldown.Calistir();
        }
    }
}
