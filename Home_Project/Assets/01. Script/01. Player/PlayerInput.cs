using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public bool Mouse_Left { get; private set; }
    public bool Mouse_Right { get; private set; }


    private void FixedUpdate()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Mouse_Left = Input.GetMouseButton(0);
        Mouse_Right = Input.GetMouseButton(1);


    }
}
