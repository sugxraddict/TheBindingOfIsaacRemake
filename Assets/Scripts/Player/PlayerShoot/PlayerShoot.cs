using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerMovement movement;
    private InputManager im;
    public BulletMovement bulletPrefab;
    public float initialTimer = 1;
    public float timer;
    public BulletMovement.ShootDirectionType shootDirection;
    public BulletMovement.WalkDirection walkDirection;
    public float maxVelocity = 0.05f;

    public bool shooting = false;
	public bool leftEye = false;
    private Vector3 bulletSpawnPos;


    // Use this for initialization
    void Start ()
    {
        im = GetComponent<InputManager>();
        movement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    
    public void Shot(BulletMovement.ShootDirectionType shootDir, BulletMovement.WalkDirection walkDir)
    {
            shooting = true;
			BulletMovement bullet = Instantiate(bulletPrefab, bulletSpawnPos, Quaternion.identity);
            bullet.SetDirectionType(shootDir);
            bullet.SetWalkDirectionType(walkDir);
    }
    
    public bool CanShoot()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return false;
        }
        else if (timer <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	void Update ()
    {
        if (CanShoot())
        {
            if (movement.velocity.y > maxVelocity)
            {
                walkDirection = BulletMovement.WalkDirection.Up;
            }
            else if (movement.velocity.y < -maxVelocity)
            {
                walkDirection = BulletMovement.WalkDirection.Down;
            }

            if(movement.velocity.x > maxVelocity)
            {
                walkDirection = BulletMovement.WalkDirection.Right;
            }
            else if(movement.velocity.x < -maxVelocity)
            {
                walkDirection = BulletMovement.WalkDirection.Left;
            }

            if(movement.velocity.y < maxVelocity &&
               movement.velocity.y > -maxVelocity &&
               movement.velocity.x < maxVelocity &&
               movement.velocity.x > -maxVelocity)
            {
                walkDirection = BulletMovement.WalkDirection.None;
            }

            //Debug.Log(movement.velocity.x);
            
            if (im.ShootUp())
            {
                if (leftEye)
                {
                    bulletSpawnPos = new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y+0.1f, gameObject.transform.position.z);
                    leftEye = false;
                }
                else if (!leftEye)
                {
                    bulletSpawnPos = new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y+ 0.1f, gameObject.transform.position.z);
                    leftEye = true;
                }
                Shot(BulletMovement.ShootDirectionType.Up, walkDirection);
                timer = initialTimer;
            }
            else if (im.ShootDown())
            {
                if (leftEye)
                {
                    bulletSpawnPos = new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y-0.3f, gameObject.transform.position.z);
                    leftEye = false;
                }
                else if (!leftEye)
                {
                    bulletSpawnPos = new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y-0.3f, gameObject.transform.position.z);
                    leftEye = true;
                }
                Shot(BulletMovement.ShootDirectionType.Down, walkDirection);
                timer = initialTimer;
                
            
            }

            else if (im.ShootLeft())
            {
                bulletSpawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                Shot(BulletMovement.ShootDirectionType.Left, walkDirection);
                timer = initialTimer;
            }
            else if (im.ShootRight())
            {
                bulletSpawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                Shot(BulletMovement.ShootDirectionType.Right, walkDirection);
                timer = initialTimer;
            }

            
        }

    }

}
