﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    
    private Queue<Dialogue> dialogue_q;

    // Start is called before the first frame update
    void Start()
    {
        dialogue_q = new Queue<Dialogue>();
    }

    public void StartDialogue(Dialogue[] conversation)
    {
        animator.SetBool("isOpen", true);

        dialogue_q.Clear();

        foreach (Dialogue dialogue in conversation)
        {
            dialogue_q.Enqueue(dialogue);
        }
        
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if(dialogue_q.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue dialogue = dialogue_q.Dequeue();
        nameText.text = dialogue.name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogue.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        //Time.timeScale = 1f;
    }
   
}
