using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_Move : MonoBehaviour
{
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag(playerObjectName).GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
