using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<HealthScript>().dealDamage(damage);
        }
        if(collision.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
