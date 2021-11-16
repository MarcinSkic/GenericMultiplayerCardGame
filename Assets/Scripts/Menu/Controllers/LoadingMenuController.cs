using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LoadingMenuController : SubController<LoadingMenu>
{
    public override void EngageController()
    {
        base.EngageController();
        StartCoroutine(WaitForResponse());
    }

    public override void DisengageController()
    {
        base.DisengageController();
        StopAllCoroutines();
    }

    IEnumerator WaitForResponse()
    {
        yield return new WaitForSeconds(20f);
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        root.ShowErrorMenu("Time for response was too long");
    }
}
