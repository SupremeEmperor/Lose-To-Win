using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public int speed;
    private int exp;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<GunFire>().Fire(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 force = new Vector3(speed * Input.GetAxisRaw("Horizontal"), speed * Input.GetAxisRaw("Vertical"), 0);
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
        
        gameObject.GetComponent<Rigidbody2D>().AddForce(force);
    }

    public void addXP()
    {

    }
}
