﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove_From_Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Debug.Log("Hey Kiddo");
            Destroy(transform.parent.gameObject);
        }
    }
}
