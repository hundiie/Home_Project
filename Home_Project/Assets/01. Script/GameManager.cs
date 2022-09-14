using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // 생성할 플레이어 캐릭터 프리팹

    void Start()
    {
        Vector3 SpawnPos = new Vector3(0, 1, 0);
        
        // 네트워크 상의 모든 클라이언트들에서 생성 실행
        // 단, 해당 게임 오브젝트의 주도권은, 생성 메서드를 직접 실행한 클라이언트에게 있음
        PhotonNetwork.Instantiate(playerPrefab.name, SpawnPos, Quaternion.identity);
    }
}
