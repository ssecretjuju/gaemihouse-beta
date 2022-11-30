using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEditor;

public class GameManager2 : MonoBehaviourPunCallbacks
{
    public static GameManager2 instance;
    //public Transform playerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        //OnPhotonSerializeView 호출 빈도
        PhotonNetwork.SerializationRate = 60;
        //Rpc 호출 빈도
        PhotonNetwork.SendRate = 60;
        
        //플레이어를 생성한다.
        //PhotonNetwork.Instantiate("Player", spawnPos[idx], Quaternion.identity);

        //PhotonNetwork.Instantiate("AntPlayer2", new Vector3(18, 19, 15), Quaternion.identity);
        GameObject playerObject = PhotonNetwork.Instantiate("AntPlayer2", new Vector3(18, 10, 15), Quaternion.identity);
        playerObject.name = LoginManager.Instance.playerData.memberNickname;
        //int returns = int.Parse(LoginManager.Instance.playerData.yield);
        double a = double.Parse(LoginManager.Instance.playerData.yield);
        print("return : " + a);

        if (a > 5)
        {
            playerObject.transform.localScale = new Vector3(2, 2, 2);
        }

        else if (a > 10)
        {
            playerObject.transform.localScale = new Vector3(3, 3, 3);
        }

        else
        {
            playerObject.transform.localScale = new Vector3(1, 1, 1);
        }

        //LoginManager.Instance.playerData.yield;
        //int returnb = Int32.Parse(LoginManager.Instance.playerData.yield);
        //print("returns: " + returns);
        //print("returnb: " + returnb);

        //if(returns > 5)
        //    playerObject.transform.localScale = new Vector3(3,3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //방에 플레이어가 참여 했을 때 호출해주는 함수
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print(newPlayer.NickName + "이 방에 들어왔습니다.");
    }

}
