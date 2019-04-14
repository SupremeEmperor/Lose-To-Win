using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Camera_Scipt : MonoBehaviour
{
    private bool isMoving = false;
    private Transform moveTo;
    public GameObject movingCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            movingCamera.transform.position = Vector3.Lerp(movingCamera.transform.position, moveTo.position, 2*Time.deltaTime);
        }
    }

    public void move(Transform positionToMove)
    {
        isMoving = true;
        moveTo = positionToMove;
    }
}
