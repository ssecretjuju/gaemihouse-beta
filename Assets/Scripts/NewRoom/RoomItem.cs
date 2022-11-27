using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    //내용
    //public Text roomInfo;
    public TMP_Text roomInfo;

    //설명
    public TMP_Text roomDesc;

    //맵 id
    int map_id;

    //클릭이 되었을 때 호출되는 함수를 가지고있는 변수
    //public System.Action<string, int> onClickAction;
    //public System.Action<string> OnClickAction;

    void Start()
    {
       // NewLobbyManager LM = GetComponent<NewLobbyManager>();
    }
    
    public void SetInfo(string roomName, int currPlayer, byte maxPlayer)
    {
        //게임오브젝트의 이름을 roomName으로!
        name = roomName;
        //방이름 (0/0)
        roomInfo.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")"; 
    }

    public void SetInfo(RoomInfo info)
    {
        SetInfo((string)info.CustomProperties["room_name"], info.PlayerCount, info.MaxPlayers);
        
        //desc 설정
        string sreturn = info.CustomProperties["desc"].ToString();
        print("string return : " + sreturn);

        roomDesc.text = sreturn + " %";
        //roomDesc.text = (string)info.CustomProperties["desc"];
        //roomDesc.text = (int)info.CustomProperties["desc"];

   
        
        
        //roomReturn.text = (string)info.CustomProperties["password"];


        //desc 설정 (여기 뿐)


        //desc 설정
        //float desc = (float)(info.CustomProperties["desc"]);
        //roomDesc.text = (string)desc;
        //roomDesc.text = (float)info.CustomProperties["desc"];
        //roomDesc.text = (float)info.CustomProperties["desc"];
        
        
        

        //roomReturn.text = (string)info.CustomProperties["password"];

        //float return = float.Parse(roomDesc.text);

        //float.Parse(roomDesc.text) = (float)info.CustomProperties["desc"]);

        //map id ����
        //map_id = (int)info.CustomProperties["map_id"];
    }



    public void OnClick()
    {
        
        //GameObject inputRoomName = GameObject.Find("InputRoomName");
        //print("RoomItem 1. inputRoomName :: " + inputRoomName);
        //InputField input = inputRoomName.GetComponent<InputField>();
        //input.text = name;
        //print("input.text : " + name);
        //print("name : " + name);
        

        // //만약에 onClickAction 가 null이 아니라면
        //if(OnClickAction != null)
        //{
        //    //onClickAction 실행
        //    //onClickAction(name);
        //    OnClickAction(name);
        //    print("OnClickAction 실행");
        //    print(name);
        //}
        //else
        //{
        //    print("OnClickAction" + null);
        //}

        ////1. InputRoomName 게임오브젝 찾자
        //GameObject go = GameObject.Find("InputRoomName");
        ////2. InputField 컴포넌트 가져오자
        //InputField inputField = go.GetComponent<InputField>();
        ////3. text에 roomName 넣자.
        //inputField.text = name;
    }
}
