using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;


public class LeaveRoomBtn : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //방나가기 버튼에 달기
    public void ClickLobby()
    {
        PhotonNetwork.Disconnect();
        //해당 씬으로 이동 
        SceneManager.LoadScene("[Beta]LYJ_LobbyScene");
    }
}
