using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CreateRoomMenuController : SubController<CreateRoomMenu>
{
    public override void EngageController()
    {
        base.EngageController();
        ui.OnCreateRoomClicked += CreateRoom;
    }
    public override void DisengageController()
    {
        base.DisengageController();
        ui.OnCreateRoomClicked -= CreateRoom;
    }
    void CreateRoom(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            //TODO: Add roomName generated with nick of player
            return;
        }
        PhotonNetwork.CreateRoom(name);
        root.OpenMenu("loading");
    }
}
