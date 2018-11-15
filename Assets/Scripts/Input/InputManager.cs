using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool Up() { return Input.GetKey(KeyCode.W); }
    public bool Down() { return Input.GetKey(KeyCode.S); }
    public bool Left() { return Input.GetKey(KeyCode.A); }
    public bool Right() { return Input.GetKey(KeyCode.D); }
    public bool ShootUp() { return Input.GetKey(KeyCode.UpArrow); }
    public bool ShootDown() { return Input.GetKey(KeyCode.DownArrow); }
    public bool ShootLeft() { return Input.GetKey(KeyCode.LeftArrow); }
    public bool ShootRight() { return Input.GetKey(KeyCode.RightArrow); }
}
