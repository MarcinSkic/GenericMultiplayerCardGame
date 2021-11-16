using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using Photon.Realtime;

public class RoomMenu : BaseMenu
{
    [SerializeField] private Transform playerListContent;
    [SerializeField] private TextMeshProUGUI roomName;
    [SerializeField] private Button leaveRoomButton;
    [SerializeField] private Button startGameButton;

    public override void Open()
    {
        base.Open();
        leaveRoomButton.onClick.AddListener(LeaveRoomClicked);
        startGameButton.onClick.AddListener(StartGameClicked);
    }

    public override void Close()
    {
        base.Close();
        leaveRoomButton.onClick.RemoveAllListeners();
        startGameButton.onClick.RemoveAllListeners();
    }

    public void SetRoomName(string name)
    {
        roomName.text = name;
    }

    public UIPlayerItem AddPlayerToList(UIPlayerItem playerItemPrefab)
    {
        return Instantiate(playerItemPrefab, playerListContent);
    }

    public void SetStartButtonState(bool state)
    {
        startGameButton.gameObject.SetActive(state);
    }

    public UnityAction OnLeaveRoomClicked;
    private void LeaveRoomClicked()
    {
        OnLeaveRoomClicked?.Invoke();
    }

    public UnityAction OnStartGameClicked;
    private void StartGameClicked()
    {
        OnStartGameClicked?.Invoke();
    }
}
