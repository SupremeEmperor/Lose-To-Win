using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //public Dialogue dialogue;
    public Conversation conversation;

    public void TriggerDialogue()
    {
        foreach (Dialogue d in conversation.conversation)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(d);
        }
    }

}
