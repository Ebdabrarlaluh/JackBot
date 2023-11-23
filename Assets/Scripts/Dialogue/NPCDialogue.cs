using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public Dialogue dialogue;

    void Start()
    {
        if (dialogue != null)
        {
            TriggerDialogue();
        }
        else
        {
            Debug.LogError("Dialogue object is null!");
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
