using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Animator textAnimator;

    private readonly Queue<string> sentences = new Queue<string>();

    private void Start()
    {
                
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DisplayNextSentence();
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        textAnimator.SetBool("IsTalking", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void addSentences(string dialogue)
    {
        
        textAnimator.SetBool("IsTalking", true);
        sentences.Enqueue(dialogue);
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence =sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        textAnimator.SetBool("IsTalking", false);
    }
}
   
