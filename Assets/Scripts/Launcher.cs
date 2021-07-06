using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class Launcher : MonoBehaviourPunCallbacks
{
    //TODO: Rework architecture
    [SerializeField] TMP_InputField roomNameInput;
    [SerializeField] TextMeshProUGUI roomName;
    [SerializeField] TextMeshProUGUI errorMessage;

    void Start()
    {
        Debug.Log("Connecting to Master");
        MenuManager.Instance.OpenMenu("loading");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");
        Debug.Log("Joined lobby");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInput.text))
        {
            //TODO: Add roomName generated with nick of player
            return;
        }
        
        PhotonNetwork.CreateRoom(roomNameInput.text);  
        MenuManager.Instance.OpenMenu("loading");
    }
    public override void OnJoinedRoom()
    {
        roomName.text = PhotonNetwork.CurrentRoom.Name;
        MenuManager.Instance.OpenMenu("room");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorMessage.text = "Room creation failed: " + message;
        MenuManager.Instance.OpenMenu("error");
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }
    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }
}
