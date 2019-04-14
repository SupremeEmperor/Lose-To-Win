using System.Collections;
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Vector2.zero, 10, 5);
        if (colliders.Length > 0)
        {
            Debug.Log("Colliding with ground!");
        }
    }


}
