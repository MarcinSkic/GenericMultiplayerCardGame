using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomMenuController : SubController<RoomMenu>
{
    public override void EngageController()
    {
        ui.SetRoomName(PhotonNetwork.CurrentRoom.Name);
        ui.OnLeaveRoomClicked += LeaveRoom;
        base.EngageController();
    }
    public override void DisengageController()
    {
        ui.OnLeaveRoomClicked -= LeaveRoom;
        base.DisengageController();
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        root.OpenMenu("loading");
    }
}
