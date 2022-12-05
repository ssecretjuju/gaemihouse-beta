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
        GameObject antPlayer = PhotonNetwork.Instantiate("AntPlayer2", new Vector3(18, 10, 15), Quaternion.identity);

        //플레이어의 이익률이 10%이상이면 개미 크기 2배
        antPlayer.name = LoginManager.Instance.playerData.memberNickname;
        double a = double.Parse(LoginManager.Instance.playerData.yield);

        if (a > 5)
        {
            antPlayer.transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            antPlayer.transform.localScale = new Vector3(1, 1, 1);
        }

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
