using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class RoomMenu : BaseMenu
{
    [SerializeField]
    TextMeshProUGUI roomName;
    [SerializeField]
    Button leaveRoomButton;
    public override void Open()
    {
        base.Open();
        leaveRoomButton.onClick.AddListener(LeaveRoomClicked);
    }
    public override void Close()
    {
        base.Close();
        leaveRoomButton.onClick.RemoveAllListeners();
    }
    public void SetRoomName(string name)
    {
        roomName.text = name;
    }
    public UnityAction OnLeaveRoomClicked;
    void LeaveRoomClicked()
    {
        OnLeaveRoomClicked?.Invoke();
    }
}
