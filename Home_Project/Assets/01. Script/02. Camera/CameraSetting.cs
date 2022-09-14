using System.Collections;
using System.Collections.Generic;
using Photon.Pun; // PUN 관련 코드
using UnityEngine;

public class CameraSetting : MonoBehaviourPun
{
    private GameObject CAMERA;

    
    private void Start()
    {
        CAMERA = Camera.main.gameObject;
        if (photonView.IsMine)// 이 코드로 내껀지 아닌지 알 수 있다.
        {
            CAMERA.GetComponent<CameraMove>().Target = this.gameObject;
        }
    }
}
