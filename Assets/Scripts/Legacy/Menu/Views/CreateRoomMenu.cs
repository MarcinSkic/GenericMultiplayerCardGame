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
    [SerializeField]
    Button createRoom;
    public override void Open()
    {
        base.Open();
        createRoom.onClick.AddListener(CreateRoomClicked);
    }
    public override void Close()
    {
        base.Close();
        roomNameInput.text = string.Empty;
        createRoom.onClick.RemoveListener(CreateRoomClicked);
    }

    public UnityAction<string> OnCreateRoomClicked;
    void CreateRoomClicked()
    {
        OnCreateRoomClicked?.Invoke(roomNameInput.text);
    }
}
