using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorMenu : BaseMenu
{
    [SerializeField]
    TextMeshProUGUI errorText;
    public override void Open()
    {
        base.Open();
    }
    public override void Close()
    {
        base.Close();
    }
    public void SetErrorText(string error)
    {
        errorText.text = "Room creation failed:\n" + error;
    }
}
