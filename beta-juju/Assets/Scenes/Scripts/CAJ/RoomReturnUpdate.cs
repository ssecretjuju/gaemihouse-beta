using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RoomReturnUpdate : MonoBehaviourPunCallbacks
{
    public InputField ReturnInput;

    public Button ReturnBtn;


    // Start is called before the first frame update
    void Start()
    {
        print("현재 방 CustomProperties : " + PhotonNetwork.CurrentRoom.CustomProperties);
    }

    public void ReturnChange()
    {
        //1. 룸의 상태를 취득
        //Room room = PhotonNetwork.CurrentRoom;
        print("현재 방 상태 : " + PhotonNetwork.CurrentRoom);

        // 2. 룸의 커스텀 프로퍼티 취득
        float newReturn = float.Parse(ReturnInput.text);

        print("1. 입력받은 newReturn : " + newReturn + " null값 아닌지 확인!");

        ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
        setValue["desc"] = newReturn;

        PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);

        print("커스텀 프로퍼티 변경되었음? : " + PhotonNetwork.CurrentRoom.CustomProperties);

        //if (newReturn < 0)
        //{
        //    PhotonNetwork.LoadLevel("GameScene");
        //}

        //else if (newReturn == 0)
        //{
        //    PhotonNetwork.LoadLevel("GameScene_Igloo");

        //}

        //else if (newReturn > 0 && newReturn < 100)
        //{
        //    PhotonNetwork.LoadLevel("GameScene_Fire");
        //}

        ////else  (newReturn >= 100)
        //else
        //{
        //    PhotonNetwork.LoadLevel("GameScene_Gold");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
