using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
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
        if (EditorSceneManager.GetActiveScene().name=="Level2")
        {
            EditorSceneManager.LoadScene("Level3");
        }
        if (EditorSceneManager.GetActiveScene().name == "Level3")
        {
            EditorSceneManager.LoadScene("Level4");
        }
        if (EditorSceneManager.GetActiveScene().name == "Level4")
        {
            EditorSceneManager.LoadScene("Level5");
        }
        if (EditorSceneManager.GetActiveScene().name == "Level5")
        {
            EditorSceneManager.LoadScene("Level6");
        }
        if (EditorSceneManager.GetActiveScene().name == "Level6")
        {
            EditorSceneManager.LoadScene("Level7");
        }
        if (EditorSceneManager.GetActiveScene().name == "Level7")
        {
            EditorSceneManager.LoadScene("Level8");
        }
    }
}
