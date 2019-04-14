using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
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
                Destroy(this.gameObject);
            }
        }
        
    }
}

