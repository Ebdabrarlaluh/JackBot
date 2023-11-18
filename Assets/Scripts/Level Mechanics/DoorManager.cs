using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animator door;
    private bool newLevel=false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !newLevel)
        {
            door.SetTrigger("Open");
            newLevel = true;
            Animator player = other.GetComponent<Animator>();
            player.SetTrigger("newLevel");
        }
    }
}
