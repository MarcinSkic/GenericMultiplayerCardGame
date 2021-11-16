using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] private RootMenuController root;

    [SerializeField] private TextMeshProUGUI errorText;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        SetPlayersLaunchingSceneAtTheSameTime();
    }

    private void SetPlayersLaunchingSceneAtTheSameTime()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        root.OpenMenu("title");
        Debug.Log("LobbyJoined");

        SetPlayerTemporaryNickName();
    }

    private void SetPlayerTemporaryNickName()
    {
        PhotonNetwork.NickName = "Somebody " + Random.Range(1, 1000).ToString("0000");
    }

    public override void OnJoinedRoom()
    {
        root.OpenMenu("room");
    }

    public override void OnLeftRoom()
    {
        root.OpenMenu("title");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        root.OpenMenu("error");
        errorText.text = $"Room creation failed: {message}";
    }
}
