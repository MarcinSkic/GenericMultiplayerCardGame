using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenuController : SubController<TitleMenu>
{
    public override void EngageController()
    {
        ui.OnCreateRoomClicked += OpenCreateRoom;
        ui.OnQuitGameClicked += QuitGame;
        base.EngageController();
    }
    public override void DisengageController()
    {
        ui.OnCreateRoomClicked -= OpenCreateRoom;
        ui.OnQuitGameClicked -= QuitGame;
        base.DisengageController();
    }
    void OpenCreateRoom()
    {
        root.OpenMenu("createRoom");
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
