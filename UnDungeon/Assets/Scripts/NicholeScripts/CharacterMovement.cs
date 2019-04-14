using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
       compareForces(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));     
    }

    private void compareForces(float HForce, float VForce)
    {
        if (Mathf.Abs(HForce) > Mathf.Abs(VForce))
        {
            findHorizontalForce(HForce);
        }
        else if (Mathf.Abs(VForce) > Mathf.Abs(HForce))
        {
            findVerticalForce(VForce);
        }
        else if (Mathf.Abs(HForce) == 0 && Mathf.Abs(VForce) == 0)
        {
            anim.SetBool("isMovingRight", false);
            anim.SetBool("isMovingLeft", false);
            anim.SetBool("isMovingUp", false);
            anim.SetBool("isMovingDown", false);
        }
        else if (Mathf.Abs(HForce) == Mathf.Abs(VForce))
        {
                findHorizontalForce(HForce);
        }
    }

    private void findHorizontalForce(float force)
    {
        anim.SetBool("isMovingUp", false);
        anim.SetBool("isMovingDown", false);
        if (force < 0)
        {
            anim.SetBool("isMovingRight", false);
            anim.SetBool("isMovingLeft", true);
        }
        else
        {
            anim.SetBool("isMovingRight", true);
            anim.SetBool("isMovingLeft", false);
        }
    }

    private void findVerticalForce(float force)
    {
        anim.SetBool("isMovingRight", false);
        anim.SetBool("isMovingLeft", false);
        if (force < 0)
        {
            anim.SetBool("isMovingUp", false);
            anim.SetBool("isMovingDown", true);
        }
        else
        {
            anim.SetBool("isMovingUp", true);
            anim.SetBool("isMovingDown", false);
        }
    }


}
