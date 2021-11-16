using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class UIPlayerItem : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text playerName;
    public Player player;

    public void Init(Player player)
    {
        this.player = player;
        this.playerName.text = player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
