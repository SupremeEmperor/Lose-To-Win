using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int health;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Decreases the characters health by damage
    public void dealDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            dead = true;
        }
    }

    //Returns true if the character is dead
    public bool getDead()
    {
        return dead;
    }
}
