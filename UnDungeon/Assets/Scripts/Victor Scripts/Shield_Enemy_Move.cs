using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Enemy_Move : MonoBehaviour
{
    private Transform target;
    public string playerObjectName = "Player";
    public int moveSpeed = 3;
    public int rotationSpeed = 0;
    public int expDrop = 15;
    public HealthScript healthScript;
    public MovementScript playerScript;
    public Spawn_Enemy spawnScript;
    private GameObject player;
    public GameObject drop;
    public Animator anim;
    public GameObject rightShield;
    public GameObject leftShield;
    public GameObject forwardShield;
    public GameObject backShield;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(playerObjectName);
        playerScript = (MovementScript)player.GetComponent(typeof(MovementScript));
        spawnScript = (Spawn_Enemy)player.GetComponent(typeof(Spawn_Enemy));
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.getDead())
        {
            playerScript.addXP(expDrop);
            spawnScript.enemyDied();
            if (Random.Range(0, 100) <= 5)
            {
                Instantiate(drop, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        target = GameObject.FindWithTag(playerObjectName).GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        //logic for setting object direction, shield direction, and animations
        if(target.position.x - transform.position.x > 0)
        {
            anim.SetBool("Left", false);
            leftShield.SetActive(false);
            if (target.position.y - transform.position.y > 0)
            {
                anim.SetBool("Forward", false);
                forwardShield.SetActive(false);
                if (target.position.x - transform.position.x > target.position.y - transform.position.y)
                {
                    anim.SetBool("Right", true);
                    anim.SetBool("Backwards", false);
                    rightShield.SetActive(true);
                    backShield.SetActive(false);
}
                else
                {
                    anim.SetBool("Backwards", true);
                    anim.SetBool("Right", false);
                    rightShield.SetActive(false);
                    backShield.SetActive(true);
                }
            }
            else if (target.position.y - transform.position.y < 0)
            {
                backShield.SetActive(false);
                anim.SetBool("Backwards", false);
                if (target.position.x - transform.position.x > -(target.position.y - transform.position.y))
                {
                    anim.SetBool("Right", true);
                    anim.SetBool("Forward", false);
                    rightShield.SetActive(true);
                    forwardShield.SetActive(false);
                }
                else
                {
                    anim.SetBool("Forward", true);
                    anim.SetBool("Right", false);
                    rightShield.SetActive(false);
                    forwardShield.SetActive(true);
                }
            }
        }
        else if(target.position.x - transform.position.x < 0)
        {
            anim.SetBool("Right", false);
            rightShield.SetActive(false);
            if (target.position.y - transform.position.y > 0)
            {
                anim.SetBool("Forward", false);
                forwardShield.SetActive(false);
                if (-(target.position.x - transform.position.x) > target.position.y - transform.position.y)
                {
                    anim.SetBool("Left", true);
                    anim.SetBool("Backwards", false);
                    leftShield.SetActive(true);
                    backShield.SetActive(false);
                }
                else
                {
                    anim.SetBool("Backwards", true);
                    anim.SetBool("Left", false);
                    leftShield.SetActive(false);
                    backShield.SetActive(true);
                }
            }
            else if (target.position.y - transform.position.y < 0)
            {
                anim.SetBool("Backwards", false);
                backShield.SetActive(false);
                if (-(target.position.x - transform.position.x) > -(target.position.y - transform.position.y))
                {
                    anim.SetBool("Left", true);
                    anim.SetBool("Forward", false);
                    leftShield.SetActive(true);
                    forwardShield.SetActive(false);
                }
                else
                {
                    anim.SetBool("Forward", true);
                    anim.SetBool("Left", false);
                    leftShield.SetActive(false);
                    forwardShield.SetActive(true);
                }
            }
        }
    }
}
