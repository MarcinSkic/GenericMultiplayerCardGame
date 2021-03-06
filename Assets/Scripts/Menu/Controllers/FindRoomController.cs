using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FindRoomController : SubController<FindRoomMenu>
{
    [SerializeField]
    RoomListButton prefab;
    List<RoomListButton> buttons = new List<RoomListButton>();

    public override void Init()
    {
        CallbacksController.Instance.OnRoomListUpdateAct += RoomListUpdate;
    }

    public override void EngageController()
    {
        ui.onBackToMenuClicked += BackToMenu;
        base.EngageController();
    }

    public override void DisengageController()
    {
        ui.onBackToMenuClicked -= BackToMenu;
        base.DisengageController();
    }

    void BackToMenu()
    {
        root.OpenMenu("title");
    }

    void RoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("RoomListUpdated");
        DeleteAllButtons();

        foreach(RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                continue;
            }

            if (info.IsOpen)
            {
                var copy = ui.AddRoomToList(prefab);
                copy.Init(info);
                copy.onRoomButtonClicked += JoinRoom;
                buttons.Add(copy);
            }          
        }
    }

    void DeleteAllButtons()
    {
        foreach(RoomListButton button in buttons)
        {
            Destroy(button.gameObject);   
        }
        buttons.Clear();
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        root.OpenMenu("loading");
    }
}
