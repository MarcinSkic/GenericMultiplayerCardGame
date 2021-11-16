using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomMenuController : SubController<RoomMenu>
{
    [SerializeField] private UIPlayerItem playerItemPrefab;

    private List<UIPlayerItem> playerButtons = new List<UIPlayerItem>();
    public override void Init()
    {
        CallbacksController.Instance.OnMasterClientSwitchedAct += SetStartButtonState;
        CallbacksController.Instance.OnPlayerEnteredRoomAct += AddPlayerToList;
        CallbacksController.Instance.OnPlayerLeftRoomAct += RemovePlayerFromList;
    }

    public override void EngageController()
    {
        ui.SetRoomName(PhotonNetwork.CurrentRoom.Name);

        UpdatePlayersList();
        SetStartButtonState(PhotonNetwork.LocalPlayer);

        ui.OnLeaveRoomClicked += LeaveRoom;
        ui.OnStartGameClicked += StartGame;

        base.EngageController();
    }

    public override void DisengageController()
    {
        ui.OnLeaveRoomClicked -= LeaveRoom;
        ui.OnStartGameClicked -= StartGame;

        base.DisengageController();
    }

    public void RemovePlayerFromList(Player player)
    {
        UpdatePlayersList();
    }

    public void UpdatePlayersList()
    {
        RemovePlayersFromList();
        LoadPlayersList();
    }

    private void RemovePlayersFromList()
    {
        foreach (var item in playerButtons)
        {
            Destroy(item.gameObject);
        }
        playerButtons.Clear();
    }

    public void LoadPlayersList()
    {
        foreach (var item in PhotonNetwork.PlayerList)
        {
            AddPlayerToList(item);
        }
    }

    private void AddPlayerToList(Player player)
    {
        var copy = ui.AddPlayerToList(playerItemPrefab);
        copy.Init(player);
        playerButtons.Add(copy);
    }

    private void SetStartButtonState(Player uselessReference)
    {
        ui.SetStartButtonState(PhotonNetwork.IsMasterClient);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        root.OpenMenu("loading");
    }

    private void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
