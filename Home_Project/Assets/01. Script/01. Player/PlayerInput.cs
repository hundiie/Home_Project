using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerInput : MonoBehaviourPun
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public bool Mouse_Left { get; private set; }
    public bool Mouse_Right { get; private set; }

    public bool Key_Q { get; private set; }
    public bool Key_W { get; private set; }
    public bool Key_E { get; private set; }
    public bool Key_R { get; private set; }

    private void FixedUpdate()
    {
        if (!photonView.IsMine) { return; }

        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Mouse_Left = Input.GetMouseButton(0);
        Mouse_Right = Input.GetMouseButton(1);

        Key_Q = Input.GetKey(KeyCode.Q);
        Key_W = Input.GetKey(KeyCode.W);
        Key_E = Input.GetKey(KeyCode.E);
        Key_R = Input.GetKey(KeyCode.R);

    }
}
