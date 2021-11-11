using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class RoomListButton : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    Button button;
    RoomInfo info;
    public void Init(RoomInfo info)
    {
        button.onClick.AddListener(RoomButtonClicked);
        this.info = info;
        text.text = info.Name;
    }

    public UnityAction<RoomInfo> onRoomButtonClicked;
    void RoomButtonClicked()
    {
        Launcher.Instance.JoinRoom(info);
    }
}
