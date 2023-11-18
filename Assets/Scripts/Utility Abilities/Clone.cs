using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public float cloneDelay;
    private float cloneDelaySeconds;
    public GameObject clone;

    public KeyCode cloneKeyCode=KeyCode.K;
    void Start()
    {
        cloneDelaySeconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cloneDelaySeconds > 0)
        {
            cloneDelaySeconds -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(cloneKeyCode))
            {
                Instantiate(clone, transform.position, transform.rotation);
                cloneDelaySeconds = cloneDelay;
            }
        }
    }
}
