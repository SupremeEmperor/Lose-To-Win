using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject bullet;
    Vector2 bulletPos;

    public void Fire()
    {
        bulletPos = transform.position;
        Instantiate(bullet, bulletPos, transform.rotation).GetComponent<Rigidbody2D>();
    }
}
