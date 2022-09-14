using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviourPun
{
    private PlayerInput _PlayerInput;
    private NavMeshAgent _NavMeshAgent;

    [Header("Move")]
    public float MoveSpeed;

    private void Awake()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        _NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine){return;}

        if (_PlayerInput.Mouse_Right)
        {
            Vector3 Movement = GetMousePosition();
            SetMove(Movement);
        }
    }

    private void SetMove(Vector3 vector)
    {
        _NavMeshAgent.destination = vector;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        
        return point;
    }
}
