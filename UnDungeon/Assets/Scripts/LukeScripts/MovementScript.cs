﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public int speed;
    public int exp = 0;
    public int lvl = 5;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<GunFire>().Fire(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<HealthScript>().health <= 0)
        {
            lvl -= 1;
            gameObject.GetComponent<HealthScript>().health = 100;
            if (lvl < 0)
            {
                lvl = 0;
                gameObject.GetComponent<HealthScript>().health = 100;
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
        if(exp >= 100)
        {
            lvl++;
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
