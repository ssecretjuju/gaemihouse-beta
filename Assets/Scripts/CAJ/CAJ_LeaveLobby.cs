using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CAJ_LeaveLobby : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickLeaveLobby()
    {

        //1. æ¿¿¸»Ø
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("[Beta]CAJ_LobbyScene");
        //2. disconnect
    }
}
