using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    //Animation
    Animator anim;

    InputManager im;

    //Up and Down Animation
    private bool UporDown = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        im = GetComponent<InputManager>();
    }

    void Update()
    {
        MovingDirection();
        Debug.Log(UporDown);
    }

    void MovingDirection()
    {
        //Idle Movement
        if (!im.Up() && !im.Down() && !im.Left() && !im.Right())
        {
            anim.SetBool("Idle", true);
        }

        //Up Movement
        if (im.Up())
        {
            anim.SetBool("WalkUp", true);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("WalkUp", false);
        }

        //Down Movement
        if (im.Down())
        {
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", true);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
            anim.SetBool("Idle", false);
            UporDown = true;
        }
        else
        {
            anim.SetBool("WalkDown", false);
            UporDown = false;
        }

        //Left Movement
        if (im.Left() )
        {
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", true);
            anim.SetBool("WalkRight", false);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("WalkLeft", false);
        }

        //Right Movement
        if (im.Right())
        {
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", true);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("WalkRight", false);
        }

        //Stop Animation
        if(im.Left() && im.Right())
        {
            anim.SetBool("Idle", true);
        }
        else if (im.Up() && im.Down())
        {
            anim.SetBool("Idle", true);
        }

        if (anim.GetBool("Idle"))
        {
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
        }
    }
}
