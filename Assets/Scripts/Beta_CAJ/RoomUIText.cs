using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomUIText : MonoBehaviourPun
{
    public Text roomName;

    // Start is called before the first frame update
    void Start()
    {
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
