using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LYJ_ConnectionManager : MonoBehaviourPunCallbacks
{
    //접속 Button
    public Button btnConnect;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClickConnect()
    {
        //서버 접속 요청
        PhotonNetwork.ConnectUsingSettings();
    }
    
    //마스터 서버 접속성공시 호출(Lobby에 진입할 수 없는 상태)
    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    //마스터 서버 접속성공시 호출(Lobby에 진입할 수 있는 상태)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        
        //로비 진입 요청
        PhotonNetwork.JoinLobby();
    }

    //로비 진입 성공시 호출
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        //LobbyScene으로 이동
        PhotonNetwork.LoadLevel("LYJ_LobbyScene");
    }
}
