using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    //Animation
    Animator anim;
    EnemyMovement em;

    private Vector3 velocity;

    void Start()
    {
        anim = GetComponent<Animator>();
        //velocity = GetComponent<EnemyMovement>()._velocity;
        em = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        MovingDirection();
        velocity = em.velocity;
        //Debug.Log(em._velocity);
    }

    void MovingDirection()
    {
        //Idle Movement
        if (velocity.x == 0 && velocity.x == 0 && velocity.y == 0  && velocity.y == 0)
        {
            anim.SetBool("EnemyIdle", true);
        }

        //Up Movement
        if (velocity.y > 0)
        {
            anim.SetBool("EnemyWalkUp", true);
            anim.SetBool("EnemyWalkDown", false);
            anim.SetBool("EnemyWalkLeft", false);
            anim.SetBool("EnemyWalkRight", false);
            anim.SetBool("EnemyIdle", false);
        }
        else
        {
            anim.SetBool("EnemyWalkUp", false);
        }

        //Down Movement
        if (velocity.y < 0)
        {
            anim.SetBool("EnemyWalkUp", false);
            anim.SetBool("EnemyWalkDown", true);
            anim.SetBool("EnemyWalkLeft", false);
            anim.SetBool("EnemyWalkRight", false);
            anim.SetBool("EnemyIdle", false);
        }
        else
        {
            anim.SetBool("EnemyWalkDown", false);
        }

        //Left Movement
        if (velocity.x < 0)
        {
            anim.SetBool("EnemyWalkUp", false);
            anim.SetBool("EnemyWalkDown", false);
            anim.SetBool("EnemyWalkLeft", true);
            anim.SetBool("EnemyWalkRight", false);
            anim.SetBool("EnemyIdle", false);
        }
        else
        {
            anim.SetBool("EnemyWalkLeft", false);
        }

        //Right Movement
        if (velocity.x > 0)
        {
            anim.SetBool("EnemyWalkUp", false);
            anim.SetBool("EnemyWalkDown", false);
            anim.SetBool("EnemyWalkLeft", false);
            anim.SetBool("EnemyWalkRight", true);
            anim.SetBool("EnemyIdle", false);
        }
        else
        {
            anim.SetBool("EnemyWalkRight", false);
        }

        //Stop Animation
        if (anim.GetBool("EnemyIdle"))
        {
            anim.SetBool("EnemyWalkUp", false);
            anim.SetBool("EnemyWalkDown", false);
            anim.SetBool("EnemyWalkLeft", false);
            anim.SetBool("EnemyWalkRight", false);
        }
    }
}
