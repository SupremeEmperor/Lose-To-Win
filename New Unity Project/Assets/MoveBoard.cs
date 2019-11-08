using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoard : MonoBehaviour
{

    public GameObject board;
    float startX = Screen.width/2;
    float startY = Screen.height/2;

    // Update is called once per frame
    void Update()
    {
        float newX = Input.GetAxis("Mouse X");
        float newY = Input.GetAxis("Mouse Y");

        if (newX != startX && newY != startY)
        {
            board.transform.Rotate(newY, 0, -newX);
        }
    }
}
