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
    public int damageAmt = 10;
    public int expDrop = 5;
    public Rigidbody2D body;
    public HealthScript healthScript;
    public MovementScript playerScript;
    public Spawn_Enemy spawnScript;
    private GameObject player;
    public GameObject drop;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jump_Loop());
        player = GameObject.FindWithTag(playerObjectName);
        playerScript = (MovementScript)player.GetComponent(typeof(MovementScript));
        spawnScript = (Spawn_Enemy)player.GetComponent(typeof(Spawn_Enemy));
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.getDead())
        {
            playerScript.addXP(expDrop);
            spawnScript.enemyDied();
            if (Random.Range(0, 100) <= 25)
            {
                Instantiate(drop, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            target = GameObject.FindWithTag(playerObjectName).GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //body.velocity = (target.position - transform.position).normalized * moveSpeed;
        }
    }

    IEnumerator Jump_Loop()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(jumpPause);
            moving = true;
            yield return new WaitForSeconds(hopTime);
            moving = false;
            body.velocity = Vector3.zero;
            //Debug.Log("Waited for " + hopTime + " seconds, and it's now " + Time.time);
        }
    }
}
