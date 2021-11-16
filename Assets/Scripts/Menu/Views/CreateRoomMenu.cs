using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class CreateRoomMenu : BaseMenu
{
    [Space(10f)]
    [SerializeField]
    TMP_InputField roomNameInput;

    [SerializeField] private Button createRoom;
    [SerializeField] private Button backToMenu;
    public override void Open()
    {
        base.Open();
        createRoom.onClick.AddListener(CreateRoomClicked);
        backToMenu.onClick.AddListener(BackToMenuClicked);
    }
    public override void Close()
    {
        base.Close();
        roomNameInput.text = string.Empty;
        createRoom.onClick.RemoveListener(CreateRoomClicked);
        backToMenu.onClick.RemoveAllListeners();
    }

    public UnityAction<string> OnCreateRoomClicked;
    void CreateRoomClicked()
    {
        OnCreateRoomClicked?.Invoke(roomNameInput.text);
    }

    public UnityAction onBackToMenuClicked;
    void BackToMenuClicked()
    {
        onBackToMenuClicked?.Invoke();
    }
}
