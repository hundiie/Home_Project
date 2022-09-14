using System.Collections;
using System.Collections.Generic;
using Photon.Pun; // PUN ���� �ڵ�
using UnityEngine;

public class CameraSetting : MonoBehaviourPun
{
    private GameObject CAMERA;

    
    private void Start()
    {
        CAMERA = Camera.main.gameObject;
        if (photonView.IsMine)// �� �ڵ�� ������ �ƴ��� �� �� �ִ�.
        {
            CAMERA.GetComponent<CameraMove>().Target = this.gameObject;
        }
    }
}
