using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class CAJ_LobbyEnter : MonoBehaviourPunCallbacks
{
    public string roomInput = "��ü";


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
            print("�±� : �÷��̾� o");
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


            print("joinorCreateRoom �Ϸ�");
            Debug.Log("roonName " + roomInput);
            PhotonNetwork.JoinOrCreateRoom("Hi", roomOptions, TypedLobby.Default);


            // �� �����ϴµ�, ���� ������ �����ϰ� ����.
            //PhotonNetwork.JoinOrCreateRoom(roomInput, new RoomOptions { MaxPlayers = 2 }, null);
            //PhotonNetwork.LoadLevel("CAJ_LobbyRoomScene");
        }
    }
    public override void OnJoinedRoom()
    {
        print("�� ���� �Ϸ�.");
    }
}
