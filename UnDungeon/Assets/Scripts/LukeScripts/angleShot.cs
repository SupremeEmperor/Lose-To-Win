using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleShot : MonoBehaviour
{
    public int damage;
    public int direction;
    public int bounces;
    public GameObject go;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag != "Player" && collision.tag != "Hitbox")
        {
            go.transform.Rotate(new Vector3(0, 0, 90 * direction));
            bounces--;
            if (bounces <= 0)
            {
                go.GetComponent<Bullet>().speed = 0;
                go.GetComponent<Animator>().SetBool("Explode", true);
            }
        }
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<HealthScript>().dealDamage(damage);
            go.GetComponent<Bullet>().speed = 0;
            go.GetComponent<Animator>().SetBool("Explode", true);
        }

    }
}
