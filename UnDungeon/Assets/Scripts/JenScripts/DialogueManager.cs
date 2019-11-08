using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public MovementScript player;
    public GunFire shooting;
    public Animator animator;

    [SerializeField] bool isExitDialogue = false;
    
    private Queue<Dialogue> dialogue_q;

    // Start is called before the first frame update
    void Start()
    {
        dialogue_q = new Queue<Dialogue>();
        player = (MovementScript)GameObject.FindWithTag("Player").GetComponent(typeof(MovementScript));
        shooting = (GunFire)GameObject.FindWithTag("Player").GetComponent(typeof(GunFire));
    }

    public void StartDialogue(Dialogue[] conversation, bool isExit)
    {
        isExitDialogue = isExit;
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
        if(dialogue_q.Count == 0 && !isExitDialogue)
        {
            EndDialogue();
            return;
        }
        else if(dialogue_q.Count == 0 && isExitDialogue)
        {
            returnToMainMenu();
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
        player.setNoEnemies(false);
        shooting.setShoot(true);
        player.setStopMovement(true);
    }

    void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   
}
