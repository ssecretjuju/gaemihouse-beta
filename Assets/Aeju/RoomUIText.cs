using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomUIText : MonoBehaviourPun
{
    public Text roomName1;
    //public Text roomName2;

    public Text roomMember;

    // Start is called before the first frame update
    void Start()
    {
        roomName1.text = PhotonNetwork.CurrentRoom.Name;
        //roomName2.text = PhotonNetwork.CurrentRoom.Name;

        //roomMember.text = PhotonNetwork.CurrentRoom.Players;
        //Dictionary<int, Photon.Realtime.Player>members = PhotonNetwork.CurrentRoom.Players;
        roomMember.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
