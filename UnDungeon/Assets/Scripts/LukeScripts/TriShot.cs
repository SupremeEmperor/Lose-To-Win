using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriShot : MonoBehaviour
{
    public GameObject bullet;
    Vector2 bulletPos;
    private bool fireBool;
    private int firecount;
    private bool beatBool;
    public float beatInterval, beatTimer;

    private void Update()
    {
        beatBool = false;
        beatTimer += Time.deltaTime;
        if (beatTimer >= beatInterval)
        {
            beatBool = true;
            beatTimer -= beatInterval;
        }

        if (firecount > 0 && beatBool)
        {
            triFire();
            firecount--;
        }
    }

    public void triFire()
    {
        Instantiate(bullet, bulletPos, transform.rotation);
        GameObject temp = Instantiate(bullet, bulletPos, transform.rotation);
    }

    public void Fire()
    {
        firecount = 2;
        bulletPos = transform.position;
        Instantiate(bullet, bulletPos, transform.rotation);
        GameObject temp = Instantiate(bullet, bulletPos, transform.rotation);
        
    }


}
