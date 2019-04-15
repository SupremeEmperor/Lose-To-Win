using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //public Dialogue dialogue;
    public Conversation conversation;

    public void TriggerDialogue()
    {
        //Time.timeScale = 0f;
        FindObjectOfType<DialogueManager>().StartDialogue(conversation.conversation);
        
    }

}
