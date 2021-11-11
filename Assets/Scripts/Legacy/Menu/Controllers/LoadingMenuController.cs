using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LoadingMenuController : SubController<LoadingMenu>
{
    public override void EngageController()
    {
        base.EngageController();
        StartCoroutine(WaitForResponse());
    }
    public override void DisengageController()
    {
        base.DisengageController();
        StopAllCoroutines();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        root.OpenMenu("title");
        Debug.Log("Joined lobby");
    }
    public override void OnJoinedRoom()
    {
        root.OpenMenu("room");
        Debug.Log("Joined room");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        root.ShowErrorMenu("Room creation failed: " + message);
    }
    public override void OnLeftRoom()
    {
        root.OpenMenu("title");
    }
    IEnumerator WaitForResponse()
    {
        yield return new WaitForSeconds(5f);
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        root.ShowErrorMenu("Time for response was too long");
    }
}
