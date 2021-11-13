using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] Menu[] menus;
    public void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)   
    {
        CloseAllMenus();

        for(int i = 0; i < menus.Length; i++)//TODO: change into foreach
        {
            if(menus[i].menuName.Equals(menuName))
            {
                OpenMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        menu.Open();
    }

    private void CloseAllMenus()
    {
        foreach (var item in menus)
        {
            item.Close();
        }
    }
}
