using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Enemy_Move : MonoBehaviour
{
    private Transform target;
    public string playerObjectName = "Player";
    public int moveSpeed = 3;
    public int rotationSpeed = 0;
    public int damageAmt = 10;
    public int expDrop = 5;
    public HealthScript healthScript;
    public MovementScript playerScript;
    public Spawn_Enemy spawnScript;
    private GameObject player;
    public GameObject drop;

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
    }
}
