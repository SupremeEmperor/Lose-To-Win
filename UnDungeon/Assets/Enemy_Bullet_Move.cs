using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_Move : MonoBehaviour
{
    private Transform target;
    public string playerObjectName = "Player";
    public int bulletSpeed = 3;
    public HealthScript healthScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthScript.getDead())
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        target = GameObject.FindWithTag(playerObjectName).GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, target.position, bulletSpeed * Time.deltaTime);
    }
}
