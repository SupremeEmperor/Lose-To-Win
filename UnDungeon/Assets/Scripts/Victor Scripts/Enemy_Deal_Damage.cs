using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Deal_Damage : MonoBehaviour
{
    public int damage;
    public Spawn_Enemy spawnScript;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnScript = (Spawn_Enemy)player.GetComponent(typeof(Spawn_Enemy));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthScript>().dealDamage(damage);
            spawnScript.enemyDied();
            Destroy(this.gameObject);
        }
    }

}


