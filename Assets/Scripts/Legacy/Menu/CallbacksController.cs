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
    public UnityAction<List<RoomInfo>> OnJoinedRoomAct;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        OnJoinedRoomAct?.Invoke(roomList);
    }
}
