using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;
using Photon.Realtime;

public class CallbacksController : MonoBehaviourPunCallbacks
{
    public static CallbacksController Instance;
    private void Awake()
    {
        Instance = this;
    }

    public UnityAction<List<RoomInfo>> OnRoomListUpdateAct;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        OnRoomListUpdateAct?.Invoke(roomList);
    }

    public UnityAction<Player> OnMasterClientSwitchedAct;
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        OnMasterClientSwitchedAct?.Invoke(newMasterClient);
    }

    public UnityAction<Player> OnPlayerEnteredRoomAct;
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        OnPlayerEnteredRoomAct?.Invoke(newPlayer);
    }

    public UnityAction<Player> OnPlayerLeftRoomAct;
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        OnPlayerLeftRoomAct?.Invoke(otherPlayer);
    }
}
