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
        ui.onBackToMenuClicked += BackToMenu;
    }

    public override void DisengageController()
    {
        base.DisengageController();
        ui.OnCreateRoomClicked -= CreateRoom;
        ui.onBackToMenuClicked -= BackToMenu;
    }

    void CreateRoom(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            name = PhotonNetwork.NickName + "'s game";
        }
        PhotonNetwork.CreateRoom(name);
        root.OpenMenu("loading");
    }

    private void BackToMenu()
    {
        root.OpenMenu("title");
    }
}
