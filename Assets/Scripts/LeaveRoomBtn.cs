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

    //�泪���� ��ư�� �ޱ�
    public void ClickLobby()
    {
        PhotonNetwork.Disconnect();
        //�ش� ������ �̵� 
        SceneManager.LoadScene("[Beta]LYJ_LobbyScene");
    }
}
