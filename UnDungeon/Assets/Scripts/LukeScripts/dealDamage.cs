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
            //Debug.Log("Gottem");
            collision.GetComponent<HealthScript>().dealDamage(damage);
        }
        if(collision.tag != "Player" && collision.tag != "Hitbox" )
        {
            gameObject.GetComponent<Bullet>().speed = 0;
            gameObject.GetComponent<Animator>().SetBool("Explode", true);
        }

    }

}
