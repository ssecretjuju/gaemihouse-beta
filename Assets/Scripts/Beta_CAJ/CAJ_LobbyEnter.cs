using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class CAJ_LobbyEnter : MonoBehaviourPunCallbacks
{
    public string roomInput = "전체";


    //void JoinOrCreateRoom()
    //{
    //    Room
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("태그 : 플레이어 o");
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsVisible = false;
            roomOptions.MaxPlayers = 20;

            ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
            hash["room_name"] = roomInput;
            roomOptions.CustomRoomProperties = hash;
            roomOptions.CustomRoomPropertiesForLobby = new string[] {
                "room_name"
            };
            print(roomOptions);


            print("joinorCreateRoom 완료");
            Debug.Log("roonName " + roomInput);
            PhotonNetwork.JoinOrCreateRoom("Hi", roomOptions, TypedLobby.Default);


            // 방 참가하는데, 방이 없으면 생성하고 참가.
            //PhotonNetwork.JoinOrCreateRoom(roomInput, new RoomOptions { MaxPlayers = 2 }, null);
            //PhotonNetwork.LoadLevel("CAJ_LobbyRoomScene");
        }
    }
    public override void OnJoinedRoom()
    {
        print("방 참가 완료.");
    }
}
