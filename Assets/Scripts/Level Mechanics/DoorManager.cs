using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

            StartCoroutine(YeniLevelYukleme());
        }
    }

    IEnumerator YeniLevelYukleme()
    {
        yield return new WaitForSeconds(1.8f);
        if (SceneManager.GetActiveScene().name == "TestScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (SceneManager.GetActiveScene().name=="Level2")
        {
            SceneManager.LoadScene("Level3");
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("Level4");
        }
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            SceneManager.LoadScene("Level5");
        }
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            SceneManager.LoadScene("Level6");
        }
        if (SceneManager.GetActiveScene().name == "Level6")
        {
            SceneManager.LoadScene("Level7");
        }
        if (SceneManager.GetActiveScene().name == "Level7")
        {
            SceneManager.LoadScene("Level8");
        }
    }
}
