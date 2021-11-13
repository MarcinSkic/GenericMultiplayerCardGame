using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    [SerializeField] private TMP_InputField roomNameInputField;
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private TMP_Text roomName;
    [SerializeField] private Transform roomListContent;
    [SerializeField] private Transform playerListContent;

    [SerializeField] private RoomListButton roomButtonPrefab;
    [SerializeField] private PlayerItem playerItemPrefab;

    [SerializeField] private string defaultRoomName;

    private void Awake()
    {
        Instance = this;    
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("JoiningMaster");
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("JoinedMaster");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        MenuManager.Instance.OpenMenu("title");
        Debug.Log("LobbyJoined");
        PhotonNetwork.NickName = "Somebody " + Random.Range(1, 1000).ToString("0000");
    }

    public void CreateRoom()
    {
        var roomName = roomNameInputField.text;
        if (string.IsNullOrEmpty(roomName))
        {
            roomName = defaultRoomName+Random.Range(1,2000);
        }
        MenuManager.Instance.OpenMenu("loading");
        PhotonNetwork.CreateRoom(roomName);       
    }

    public void LeaveRoom()
    {
        MenuManager.Instance.OpenMenu("loading");
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");
        roomName.text = PhotonNetwork.CurrentRoom.Name;

        foreach (var item in PhotonNetwork.PlayerList)
        {
            AddPlayerToList(item);
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        MenuManager.Instance.OpenMenu("error");
        errorText.text = $"Room creation failed: {message}";
        Debug.LogWarning("Tried load error page");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in roomListContent) //Change to seperate method and maybe use list to destroy
        {
            Destroy(trans.gameObject);
        }

        foreach (var item in roomList)
        {
            if (item.IsOpen)
            {
                Instantiate(roomButtonPrefab, roomListContent).Init(item);
            }           
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerToList(newPlayer);
    }

    public void AddPlayerToList(Player newPlayer)
    {
        Instantiate(playerItemPrefab, playerListContent).Init(newPlayer);
    }
}
