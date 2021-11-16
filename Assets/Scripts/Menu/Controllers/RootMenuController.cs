using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RootMenuController : MonoBehaviour
{
    public static RootMenuController Instance;

    [SerializeField]
    List<SubController> menus = new List<SubController>();

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        Debug.Log("Connecting to Master");
        OpenMenu("loading");
        PhotonNetwork.ConnectUsingSettings();

        FirstInitOfControllers();
    }

    private void FirstInitOfControllers()
    {
        foreach (SubController menu in menus)
        {
            menu.root = this;
            menu.Init();
        }
    }

    public void OpenMenu(string menuName)
    {
        CloseAllMenus();
        menus.Find(c => c.menuName == menuName).EngageController();
    }

    public void ShowErrorMenu(string error)
    {
        CloseAllMenus();
        var result = (ErrorMenuController)menus.Find(c => c.menuName == "error");
        result.SetError(error);
        result.EngageController();
    }

    public void CloseAllMenus()
    {
        foreach (SubController menu in menus)
        {
            menu.DisengageController();
        }
    }
}
