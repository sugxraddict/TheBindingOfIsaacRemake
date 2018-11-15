using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    private Shoot shoot;

    public enum ShootDirectionType
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum WalkDirection
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    static private bool leftEye;
    Rigidbody2D rgb2;
    public float speed = 10;

    private ShootDirectionType directionType;
    private Vector3 moveDirection;
    private Vector3 walkDirection;
    public Renderer renderer;
    // Use this for initialization

    void Start () {
        rgb2 = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        shoot = GameObject.Find("PlayerHead").GetComponent<Shoot>();
    }

	// Update is called once per frame
	void Update () {
        rgb2.transform.position += moveDirection * speed * Time.deltaTime;
    }

    public void SetDirectionType(ShootDirectionType type)
    {
        switch (type)
        {
            case ShootDirectionType.Up:
                moveDirection = Vector3.up;
                renderer.sortingOrder = 12;
                break;
            case ShootDirectionType.Down:
                moveDirection = Vector3.down;
                renderer.sortingOrder = 14;
                break;
            case ShootDirectionType.Left:
                //Debug.Log(shoot.leftEye);
                moveDirection = Vector3.left;
                
                if (leftEye)
                {
                    renderer.sortingOrder = 14;
                    leftEye = false;
                }
                else if(!leftEye)
                {
                    renderer.sortingOrder = 12;
                    leftEye = true;
                }
                
                break;
            case ShootDirectionType.Right:
                //Debug.Log(shoot.leftEye);
                moveDirection = Vector3.right;
                
                if (leftEye)
                {
                    renderer.sortingOrder = 12;
                    leftEye = false;
                }
                else if(!leftEye)
                {
                    renderer.sortingOrder = 14;
                    leftEye = true;
                }
                
                break;
        }
    }

    public void SetWalkDirectionType(WalkDirection type)
    {
        switch (type)
        {
            case WalkDirection.Up:
                moveDirection += new Vector3(0, 0.2f, 0);
                break;
            case WalkDirection.Down:
                moveDirection += new Vector3(0, -0.2f, 0);
                break;
            case WalkDirection.Left:
                moveDirection += new Vector3(-0.2f, 0, 0);
                break;
            case WalkDirection.Right:
                moveDirection += new Vector3(0.2f, 0, 0);
                break;
            case WalkDirection.None:
                moveDirection += new Vector3(0, 0, 0);
                break;
        }

    }

}
