using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_Damage : MonoBehaviour
{
    public int damage;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthScript>().dealDamage(damage);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
