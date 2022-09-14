using Photon.Pun; // ����Ƽ�� ���� ������Ʈ��
using Photon.Realtime; // ���� ���� ���� ���̺귯��
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviourPunCallbacks
{
    private static readonly string GAME_VERSION = "1"; // ���� ����

    public Text connectionInfoText; // ��Ʈ��ũ ������ ǥ���� �ؽ�Ʈ
    public Button joinButton; // �� ���� ��ư

    // ���� ����� ���ÿ� ������ ���� ���� �õ�
    private void Start()
    {
        StopAllCoroutines();
        // ���ӿ� �ʿ��� ���� ����
        PhotonNetwork.GameVersion = GAME_VERSION;

        // ������ ������ ������ �õ��Ѵ�.
        PhotonNetwork.ConnectUsingSettings();

        // ���� ��ư ��Ȱ��ȭ (UI ǥ��)
        joinButton.interactable = false;
        StartCoroutine(TextEffect("������ ���� ���� ��"));

    }

    // ������ ���� ���� ������ �ڵ� ����
    public override void OnConnectedToMaster()
    {
        StopAllCoroutines();
        // UI ǥ��
        joinButton.interactable = true;
        connectionInfoText.text = "���� ���� ����";
    }

    // ������ ���� ���� ���н� �ڵ� ����
    public override void OnDisconnected(DisconnectCause cause)
    {
        StopAllCoroutines();
        // UI ǥ��
        joinButton.interactable = false;
        StartCoroutine(TextEffect($"���� ���� ���� : {cause} ������ �õ� ��"));

        // ������ �õ�
        PhotonNetwork.ConnectUsingSettings();
    }

    // �� ���� �õ�
    public void Connect()
    {
        StopAllCoroutines();
        // ���� ��ư ��Ȱ��ȭ
        joinButton.interactable = false;
        // ������ ���� ���϶�
        if (PhotonNetwork.IsConnected)
        {
            // UI ǥ��
            StartCoroutine(TextEffect("�뿡 ���� ��"));
            // ������ ����
            PhotonNetwork.JoinRandomRoom();
        }
        // ������ ���� ���� �ƴ� ��
        if (!PhotonNetwork.IsConnected)
        {
            // UI ǥ��
            StartCoroutine(TextEffect("���� ���� ���� : ������ ������ ������� ���� ������ �õ���"));
            // ������ �õ�
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

    // �� �ɼ� ����
    private static readonly RoomOptions options = new RoomOptions()
    {
        MaxPlayers = 4
    };

    // (�� ���� ����)���� �� ������ ������ ��� �ڵ� ����
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        StopAllCoroutines();
        // UI ǥ��
        StartCoroutine(TextEffect("����ִ� ���� ���� ���ο� �� ���� ��"));
        // �ɼ��� ���� �� ����
        PhotonNetwork.CreateRoom(null, options);
    }

    // �뿡 ���� �Ϸ�� ��� �ڵ� ����
    public override void OnJoinedRoom()
    {
        StopAllCoroutines();
        // UI ǥ��
        connectionInfoText.text = $"�� ���� ����";

        //��� Ŭ���̾�Ʈ Main �� �ε�
        PhotonNetwork.LoadLevel(1);
    }
}
