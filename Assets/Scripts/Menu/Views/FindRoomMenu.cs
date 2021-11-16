using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FindRoomMenu : BaseMenu
{
    [SerializeField]
    Button backToMenu;
    [SerializeField]
    Transform listContent;

    public override void Open()
    {
        backToMenu.onClick.AddListener(BackToMenuClicked);
        base.Open();
    }
    public override void Close()
    {
        backToMenu.onClick.RemoveAllListeners();
        base.Close();
    }

    public UnityAction onBackToMenuClicked;
    void BackToMenuClicked()
    {
        onBackToMenuClicked?.Invoke();
    }

    public RoomListButton AddRoomToList(RoomListButton prefab)
    {
        var copy = Instantiate(prefab, listContent);
        return copy;
    }

}
