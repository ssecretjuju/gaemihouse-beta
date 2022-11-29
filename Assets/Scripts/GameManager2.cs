using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager2 : MonoBehaviourPunCallbacks
{
    public static GameManager2 instance;
    public Transform playerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        //OnPhotonSerializeView 호출 빈도
        PhotonNetwork.SerializationRate = 60;
        //Rpc 호출 빈도
        PhotonNetwork.SendRate = 60;
        
        //플레이어를 생성한다.
        //PhotonNetwork.Instantiate("Player", spawnPos[idx], Quaternion.identity);
        PhotonNetwork.Instantiate("AntPlayer2", new Vector3(24, 8, 4), Quaternion.identity);
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
