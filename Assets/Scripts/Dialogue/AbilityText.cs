using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityText : MonoBehaviour
{
    public Dialogue dialogue;

    public string firstAbility, secondAbility;

    spinJackBot jackpot;

    public void AbilityDialogue(string name,int i){

        dialogue.sentences[i] = name + dialogue.sentences[i];

        FindObjectOfType<DialogueManager>().addSentences(dialogue.sentences[i]);
        
    }
}
