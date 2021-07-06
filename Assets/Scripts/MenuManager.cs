using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField]
    Menu[] menus;

    private void Awake()
    {
        Instance = this;
    }
    public void OpenMenu(string menuName)
    {
        CloseAllMenus();
        foreach (Menu menu in menus)
        {
            if (menu.menuName.Equals(menuName))
            {
                menu.Open();
                break;
            }
        }
    }
    public void CloseAllMenus()
    {
        foreach (Menu menu in menus)
        {
            menu.Close();
        }
    }
}
