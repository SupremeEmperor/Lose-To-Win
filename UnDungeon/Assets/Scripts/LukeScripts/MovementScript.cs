using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public int speed;
    public int exp = 0;
    public int lvl = 5;
    public bool noEnemies;
    public DialogueTrigger levelUpDialogue1;
    public DialogueTrigger levelUpDialogue2;
    public DialogueTrigger levelUpDialogue3;
    public DialogueTrigger levelDownTo3;
    public DialogueTrigger levelDownTo2;
    public DialogueTrigger levelDownTo1;
    public bool leveledDownTo3 = false;
    public bool leveledDownTo2 = false;
    public bool leveledDownTo1 = false;
    public bool leveledUp1 = false;
    public bool leveledUp2 = false;
    public bool leveledUp3 = false;
    public GameObject deathAnim;
    public GameObject lvlUpAnim;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<GunFire>().Fire(1);
    }

    public void setNoEnemies(bool input)
    {
        noEnemies = input;
    }

    // Update is called once per frame
    void Update()
    {
        print("3 " + leveledDownTo3);
        print("2 " + leveledDownTo2);
        print("1 " + leveledDownTo1);

        if (lvl > 4)
        {
            lvl = 4;
        }
        if (gameObject.GetComponent<HealthScript>().health <= 0)
        {
            exp = 0;
            lvl -= 1;
            Instantiate(deathAnim, this.transform.position, Quaternion.identity);
            gameObject.GetComponent<HealthScript>().health = 100;
            if (lvl < 0)
            {
                lvl = 0;
                gameObject.GetComponent<HealthScript>().health = 100;
            }
            if(!leveledDownTo3 && !leveledDownTo2 && !leveledDownTo1)
            {
                Debug.Log("Dialogue1");
                levelDownTo3.TriggerDialogue();
                leveledDownTo3 = true;
            }
            else if(leveledDownTo3 && !leveledDownTo2 && !leveledDownTo1)
            {
                Debug.Log("Dialogue2");
                levelDownTo2.TriggerDialogue();
                leveledDownTo2 = true;
            }
            else if(leveledDownTo3 && leveledDownTo2 && !leveledDownTo1)
            {
                Debug.Log("Dialogue3");
                levelDownTo1.TriggerDialogue();
                leveledDownTo1 = true;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 force = new Vector3(speed * Input.GetAxisRaw("Horizontal"), speed * Input.GetAxisRaw("Vertical"), 0);
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
        
        gameObject.GetComponent<Rigidbody2D>().AddForce(force);
    }

    public void addXP(int xpAmount)
    {
        int h = gameObject.GetComponent<HealthScript>().health;
        exp += xpAmount;
        if(exp >= 100 && lvl!= 4)
        {
            lvl++;
            Instantiate(lvlUpAnim, this.transform.position, Quaternion.identity);
            if (!leveledUp1 && !leveledUp2 && !leveledUp3)
            {
                levelUpDialogue1.TriggerDialogue();
                leveledUp1 = true;
            }
            else if (leveledUp1 && !leveledUp2 && !leveledUp3)
            {
                levelUpDialogue2.TriggerDialogue();
                leveledUp2 = true;
            }
            else if (leveledUp1 && leveledUp2 && !leveledUp3)
            {
                levelUpDialogue3.TriggerDialogue();
                leveledUp3 = true;
            }
            h = 100;
            exp = 0;
        }
        if (lvl > 4)
        {
            lvl = 4;
        }

    }

    public int getXP()
    {
        return exp;
    }
}
