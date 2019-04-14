﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetDamage : MonoBehaviour
{
    public int damage;
    public int direction;
    public int bounces;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<HealthScript>().dealDamage(damage);
        }
        if (collision.tag != "Player" && collision.tag != "Hitbox")
        {
            gameObject.transform.Rotate(new Vector3(0,0,90 * direction));
            bounces--;
            if (bounces <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
