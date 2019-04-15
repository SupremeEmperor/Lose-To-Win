using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject crown;
    public DialogueTrigger levelDownTo3;
    public bool leveledDownTo3 = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            levelDownTo3.TriggerDialogue();
            Instantiate(crown,transform.position,Quaternion.identity);
        }
    }
}
