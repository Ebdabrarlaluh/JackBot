using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    float totalTime = 0;
    float elapsedTime = 0;
    bool isWorking = false;
    bool isStart = false;
    /// <summary>
    /// Süre ataması yapılan yer
    /// </summary>
    public float ToplamSure
    {
        set
        {
            if (!isWorking)
            {
                totalTime = value;
            }
        }
    }
    /// <summary>
    /// Çalıştırma komutu
    /// </summary>
    public void Calistir()
    {
        if (totalTime > 0)
        {
            isWorking = true;
            isStart = true;
            elapsedTime = 0;
        }
    }
    /// <summary>
    /// Bitip bitmediğini kontrol ederiz
    /// </summary>
    public bool Bitti
    {
        get
        {
            return isStart && !isWorking;
        }
    }
    void Update()
    {
        if (isWorking)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= totalTime)
            {
                isWorking = false;
            }
        }
    }
}

