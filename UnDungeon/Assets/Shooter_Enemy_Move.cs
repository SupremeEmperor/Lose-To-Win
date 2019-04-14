﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Enemy_Move : MonoBehaviour
{
    private Vector3 target;
    public string playerObjectName = "Player";
    public int rotationSpeed = 0;
    public int expDrop = 50;
    public HealthScript healthScript;
    public MovementScript playerScript;
    //public Rigidbody2D body;
    public Spawn_Enemy spawnScript;
    private GameObject player;
    public GameObject drop;
    public Animator anim;
    public int shootPause = 1;
    public GameObject bullet;
    public GameObject death;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot_Loop());
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
            spawnScript.shooterDied();
            if (Random.Range(0, 100) <= 15)
            {
                Instantiate(drop, transform.position, transform.rotation);
            }
            Instantiate(death, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    IEnumerator Shoot_Loop()
    {
        while (enabled)
        {
            target = GameObject.FindWithTag(playerObjectName).GetComponent<Transform>().position;
            //Debug.Log("boop");
            if (target.x - transform.position.x > 0)
            {
                if (target.y - transform.position.y > 0)
                {
                    if (target.x - transform.position.x > target.y - transform.position.y)
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
                else if (target.y - transform.position.y < 0)
                {
                    if (target.x - transform.position.x > -(target.y - transform.position.y))
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
            else if (target.x - transform.position.x < 0)
            {
                if (target.y - transform.position.y > 0)
                {
                    if (-(target.x - transform.position.x) > target.y - transform.position.y)
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
                else if (target.y - transform.position.y < 0)
                {
                    if (-(target.x - transform.position.x) > -(target.y - transform.position.y))
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
            yield return new WaitForSeconds(shootPause);
            shoot();
        }
    }

    public void shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
