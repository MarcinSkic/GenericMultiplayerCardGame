using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TitleMenu : BaseMenu
{
    [SerializeField]
    Button findRoom;
    [SerializeField]
    Button createRoom;
    [SerializeField]
    Button quitGame;
    public override void Open()
    {
        findRoom.onClick.AddListener(FindRoomClicked);
        createRoom.onClick.AddListener(CreateRoomClicked);
        quitGame.onClick.AddListener(QuitGameClicked);
        base.Open();
    }
    public override void Close()
    {
        findRoom.onClick.RemoveAllListeners();
        createRoom.onClick.RemoveAllListeners();
        quitGame.onClick.RemoveAllListeners();
        base.Close();
    }
    public UnityAction OnFindRoomClicked;
    void FindRoomClicked()
    {
        OnFindRoomClicked?.Invoke();
    }
    public UnityAction OnCreateRoomClicked;
    void CreateRoomClicked()
    {
        OnCreateRoomClicked?.Invoke();
    }
    public UnityAction OnQuitGameClicked;
    void QuitGameClicked()
    {
        OnQuitGameClicked?.Invoke();
    }
}
