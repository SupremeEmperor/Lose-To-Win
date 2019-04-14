using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_Enemy_Move : MonoBehaviour
{
    private Transform target;
    public string playerObjectName = "Player";
    public int moveSpeed = 2;
    private bool moving = false;
    public float jumpPause = 2f;
    public float hopTime = 1f;
    public int rotationSpeed = 0;
    public int expDrop = 5;
    public HealthScript healthScript;
    public MovementScript playerScript;
    public Spawn_Enemy spawnScript;
    private GameObject player;
    public GameObject drop;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jump_Loop());
        player = GameObject.FindWithTag(playerObjectName);
        playerScript = (MovementScript)player.GetComponent(typeof(MovementScript));
        spawnScript = (Spawn_Enemy)player.GetComponent(typeof(Spawn_Enemy));
        anim.SetBool("Moving", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.getDead())
        {
            playerScript.addXP(expDrop);
            spawnScript.enemyDied();
            if (Random.Range(0, 100) <= 15)
            {
                Instantiate(drop, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        target = GameObject.FindWithTag(playerObjectName).GetComponent<Transform>();
        if (target.position.x - transform.position.x > 0)
        {
            if (target.position.y - transform.position.y > 0)
            {
                if (target.position.x - transform.position.x > target.position.y - transform.position.y)
                {
                    anim.SetBool("Right", true);
                    anim.SetBool("Left", false);
                    anim.SetBool("Forward", false);
                    anim.SetBool("Backwards", false);
                }
                else
                {
                    anim.SetBool("Backwards", true);
                    anim.SetBool("Right", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("Forward", false);
                }
            }
            else if (target.position.y - transform.position.y < 0)
            {
                if (target.position.x - transform.position.x > -(target.position.y - transform.position.y))
                {
                    anim.SetBool("Right", true);
                    anim.SetBool("Left", false);
                    anim.SetBool("Forward", false);
                    anim.SetBool("Backwards", false);
                }
                else
                {
                    anim.SetBool("Forward", true);
                    anim.SetBool("Right", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("Backwards", false);
                }
            }
        }
        else if (target.position.x - transform.position.x < 0)
        {
            if (target.position.y - transform.position.y > 0)
            {
                if (-(target.position.x - transform.position.x) > target.position.y - transform.position.y)
                {
                    anim.SetBool("Left", true);
                    anim.SetBool("Backwards", false);
                    anim.SetBool("Right", false);
                    anim.SetBool("Forward", false);
                }
                else
                {
                    anim.SetBool("Backwards", true);
                    anim.SetBool("Right", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("Forward", false);
                }
            }
            else if (target.position.y - transform.position.y < 0)
            {
                if (-(target.position.x - transform.position.x) > -(target.position.y - transform.position.y))
                {
                    anim.SetBool("Left", true);
                    anim.SetBool("Backwards", false);
                    anim.SetBool("Right", false);
                    anim.SetBool("Forward", false);
                }
                else
                {
                    anim.SetBool("Forward", true);
                    anim.SetBool("Right", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("Backwards", false);
                }
            }
        }
        if (moving)
        {
            anim.SetBool("Moving", false);
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //body.velocity = (target.position - transform.position).normalized * moveSpeed;
        }
        else
        {
            anim.SetBool("Moving", true);
        }
    }

    IEnumerator Jump_Loop()
    {
        while (enabled)
        {
            moving = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            yield return new WaitForSeconds(jumpPause);
            moving = true;
            yield return new WaitForSeconds(hopTime);
        }
    }
}
