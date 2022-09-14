using Photon.Pun; // 유니티용 포톤 컴포넌트들
using Photon.Realtime; // 포톤 서비스 관련 라이브러리
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviourPunCallbacks
{
    private static readonly string GAME_VERSION = "1"; // 게임 버전

    public Text connectionInfoText; // 네트워크 정보를 표시할 텍스트
    public Button joinButton; // 룸 접속 버튼

    // 게임 실행과 동시에 마스터 서버 접속 시도
    private void Start()
    {
        StopAllCoroutines();
        // 접속에 필요한 정보 설정
        PhotonNetwork.GameVersion = GAME_VERSION;

        // 마스터 서버로 접속을 시도한다.
        PhotonNetwork.ConnectUsingSettings();

        // 조인 버튼 비활성화 (UI 표시)
        joinButton.interactable = false;
        StartCoroutine(TextEffect("마스터 서버 접속 중"));

    }

    // 마스터 서버 접속 성공시 자동 실행
    public override void OnConnectedToMaster()
    {
        StopAllCoroutines();
        // UI 표시
        joinButton.interactable = true;
        connectionInfoText.text = "서버 접속 성공";
    }

    // 마스터 서버 접속 실패시 자동 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        StopAllCoroutines();
        // UI 표시
        joinButton.interactable = false;
        StartCoroutine(TextEffect($"서버 접속 실패 : {cause} 재접속 시도 중"));

        // 재접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    // 룸 접속 시도
    public void Connect()
    {
        StopAllCoroutines();
        // 접속 버튼 비활성화
        joinButton.interactable = false;
        // 서버에 접속 중일때
        if (PhotonNetwork.IsConnected)
        {
            // UI 표시
            StartCoroutine(TextEffect("룸에 접속 중"));
            // 접속을 실행
            PhotonNetwork.JoinRandomRoom();
        }
        // 서버에 접속 중이 아닐 때
        if (!PhotonNetwork.IsConnected)
        {
            // UI 표시
            StartCoroutine(TextEffect("서버 접속 실패 : 마스터 서버와 연결되지 않음 재접속 시도중"));
            // 재접속 시도
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    private IEnumerator TextEffect(string text)
    {
        while (true)
        {
            connectionInfoText.text = text + ".";
            yield return new WaitForSeconds(0.1f);
            connectionInfoText.text = text + ". .";
            yield return new WaitForSeconds(0.1f);
            connectionInfoText.text = text + ". . .";
            yield return new WaitForSeconds(0.1f);
        }
    }

    // 방 옵션 설정
    private static readonly RoomOptions options = new RoomOptions()
    {
        MaxPlayers = 4
    };

    // (빈 방이 없어)랜덤 룸 참가에 실패한 경우 자동 실행
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        StopAllCoroutines();
        // UI 표시
        StartCoroutine(TextEffect("비어있는 룸이 없어 새로운 룸 생성 중"));
        // 옵션을 토대로 방 만듬
        PhotonNetwork.CreateRoom(null, options);
    }

    // 룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom()
    {
        StopAllCoroutines();
        // UI 표시
        connectionInfoText.text = $"룸 접속 성공";

        //모든 클라이언트 Main 씬 로드
        PhotonNetwork.LoadLevel(1);
    }
}
