using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralShot : MonoBehaviour
{
    int check;
    // Update is called once per frame
    void Update()
    {
        check++;
        if(check%3 == 2)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, -2F));
        }

        if (check == 300)
            Destroy(this.gameObject);
    }
}
