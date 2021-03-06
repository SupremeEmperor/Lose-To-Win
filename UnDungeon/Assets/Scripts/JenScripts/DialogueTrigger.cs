﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //public Dialogue dialogue;
    public Conversation conversation;
    public MovementScript player;
    public GunFire shooting;

    [SerializeField] bool isExitDialogue = false;

    private void Start()
    {
        
    }

    public void TriggerDialogue()
    {
        //Time.timeScale = 0f;
        player = (MovementScript)GameObject.FindWithTag("Player").GetComponent(typeof(MovementScript));
        shooting = (GunFire)GameObject.FindWithTag("Player").GetComponent(typeof(GunFire));
        player.setNoEnemies(true);
        shooting.setShoot(false);
        player.setStopMovement(false);
        FindObjectOfType<DialogueManager>().StartDialogue(conversation.conversation, isExitDialogue);
    }

}
