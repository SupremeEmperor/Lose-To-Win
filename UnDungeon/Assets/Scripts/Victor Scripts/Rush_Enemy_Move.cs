using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_Enemy_Move : MonoBehaviour
{
    private Transform target;
    public string playerObjectName = "temp name";
    public int moveSpeed = 2;
    private bool moving = false;
    public float jumpPause = 2f;
    public float hopTime = 1f;
    public int rotationSpeed = 0;
    public int damageAmt = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jump_Loop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            target = GameObject.Find(playerObjectName).GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
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
            Debug.Log("Waited for " + hopTime + " seconds, and it's now " + Time.time);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //add damaging code
    }
}
