using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Camera Target")]
    public GameObject Target;           // 카메라가 따라다닐 목표

    [Header("Camera Speed")]
    public float CameraSpeed = 0.0f;    // 카메라의 속도

    [Header("Camera Distance")]
    public float DistanceLimit = 0.0f;  // 카메라의 속도 제한
    public float CameraMaxSpeed = 0.0f; // 카메라의 최고속도
    public float AccelSpeed = 0.0f;     // 카메라의 가속도

    [Header("Camera Offset")]
    public float offsetX = 0.0f;        // 카메라의 x좌표
    public float offsetY = 0.0f;        // 카메라의 y좌표
    public float offsetZ = 0.0f;        // 카메라의 z좌표

    [Header("Camera Angle")]
    public float angleX = 0.0f;         // 카메라의 x각도
    public float angleY = 0.0f;         // 카메라의 y각도
    public float angleZ = 0.0f;         // 카메라의 z각도

    private Vector3 TargetPos;          // 타겟의 위치
    float saveCameraSpeed;

    private void Awake()
    {
        saveCameraSpeed = CameraSpeed;
    }

    void FixedUpdate()
    {
         
        // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        // 카메라 각도 변경
        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);

        //거리에 따라 속도 바꾸기
        float Distance = Vector3.Distance(transform.position, TargetPos);
        if (Distance >= DistanceLimit)
        {
            StartCoroutine(SetCameraSpeed(CameraMaxSpeed, AccelSpeed));
        }
        else if(CameraSpeed != saveCameraSpeed)
        {
            StartCoroutine(SetCameraSpeed(saveCameraSpeed, AccelSpeed));
        }

        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

    }

    private IEnumerator SetCameraSpeed(float Speed, float Accel)
    {
        StopAllCoroutines();

        if (Speed > CameraSpeed)
        {
            while (Speed >= CameraSpeed)
            {
                CameraSpeed += Accel * Time.deltaTime;
                yield return null;
            }
        }
        else if (Speed < CameraSpeed)
        {
            while (Speed <= CameraSpeed)
            {
                CameraSpeed -= Accel * Time.deltaTime;
                yield return null;
            }
        }
    }
}
