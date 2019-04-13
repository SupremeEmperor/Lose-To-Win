using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Deal_Damage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthScript>().dealDamage(damage);
            Destroy(this.gameObject);
        }
    }

}


