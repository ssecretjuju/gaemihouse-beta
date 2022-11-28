using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

public class RoomTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("방 제목 : " + LobbyRoomList.instance.roomTitles);
        ;
        
        List<string> arr; 

        print(LobbyRoomList.instance.roomdata.roomTitle);

        print(LobbyRoomList.instance.roomTitles);

        print(LobbyRoomList.instance.NameArray);


        //LobbyRoomList.instance.roomdata.roomTitle;
        //List<string> arr1;
        //LobbyRoomList.instance.roomdata.roomTitle[1];


        //ListenData = LobbyRoomList.instance.roomTitles;
        //LobbyRoomList.instance.NameArray.
        
        string strArr = "";
        int number = LobbyRoomList.instance.roomTitles.Count;
        print(number );

        for (int i = 0; i < number; i++)
        {
            strArr = strArr + LobbyRoomList.instance.roomTitles[i];
        }

        print("배열 : " + strArr);



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
