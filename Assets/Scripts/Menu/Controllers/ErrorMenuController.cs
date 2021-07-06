using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMenuController : SubController<ErrorMenu>
{
    public override void EngageController()
    {
        base.EngageController();
    }
    public override void DisengageController()
    {
        base.DisengageController();
    }
    public void SetError(string error)
    {
        ui.SetErrorText(error);
    }
}
