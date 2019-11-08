using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoard : MonoBehaviour
{
    public GameObject board;
    float smooth = 20.0f;
    float tiltAngle = 5.0f;
    Vector3 prev;
    //Vector3 prev = Input.mousePosition;

    // Start is called before the first frame update
    // Input get mouse down to get the object to rotate
    // use mouse position to get the mouse movement direction by comparing the previous frames
    // https://docs.unity3d.com/ScriptReference/Input-mousePosition.html

    void Start()
    {
        // board = GameObject.FindWithTag("board");
        prev = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        //if (Input.GetButtonDown("Fire1"))
        //{
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       // RaycastHit hit; //https://docs.unity3d.com/ScriptReference/RaycastHit.html
       // if (Physics.Raycast(ray,out hit))
           // {
               // if ((hit.collider.gameObject.name) == "Plane")
              //  {
                     if (Input.mousePosition != prev)
                    {
                        Quaternion target = Quaternion.Euler(Input.mousePosition.y, 0, Input.mousePosition.x);
                        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                    }
               // }
                //Debug.Log(hit.collider.gameObject.name);
          //}
                
       // }

        //Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

}
