﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Script_Two : MonoBehaviour
{
    public Door_Script door;
    public GameObject movingCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            door.goThroughDoor();
            movingCamera.transform
        }
    }
}
