using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum MenuControllerType { Loading, Title, CreateRoom, FindRoom, Room, Error};
public class SubController : MonoBehaviourPunCallbacks
{
    public string menuName;
    [HideInInspector]
    public RootMenuController root;

    public virtual void Init()
    {

    }

    public virtual void EngageController()
    {
        gameObject.SetActive(true);
    }
    public virtual void DisengageController()
    {
        gameObject.SetActive(false);
    }
}
public abstract class SubController<T> : SubController where T : BaseMenu 
{
    [SerializeField]
    protected T ui;
    public T UI => ui;

    public override void EngageController()
    {
        base.EngageController();
        ui.Open();
    }
    public override void DisengageController()
    {
        base.DisengageController();
        ui.Close();
    }
}
