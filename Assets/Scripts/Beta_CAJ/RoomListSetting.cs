using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Pun;
using Photon.Realtime;

[Serializable]
public class roomPostInfo
{
    public string roomTitle;
    public int roomLimitedNumber;
    public string memberId;
}

[Serializable]
public class roomDeleteInfo
{
    public string roomTitle;
}

//[Serializable]
//public class roomHolderInfo
//{
//    public int memberCode;
//}


public class RoomListSetting : MonoBehaviourPunCallbacks
{
    //방이름 InputField
    public InputField inputRoomName;
    //총인원 InputField
    public InputField inputMaxPlayer;

    //방생성 Button
    public Button btnCreate;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetRoom());
        // 방이름(InputField)이 변경될때 호출되는 함수 등록
        //inputRoomName.onValueChanged.AddListener(OnRoomNameValueChanged);
        // 총인원(InputField)이 변경될때 호출되는 함수 등록
        //inputMaxPlayer.onValueChanged.AddListener(OnMaxPlayerValueChanged);

    }

    public void OnRoomNameValueChanged(string s)
    {
        //생성
        btnCreate.interactable = s.Length > 0 && inputMaxPlayer.text.Length > 0;
    }

    public void OnMaxPlayerValueChanged(string s)
    {
        //생성
        btnCreate.interactable = s.Length > 0 && inputRoomName.text.Length > 0;
    }


    public void PostRoomInfoClick()
    {
        roomPostInfo data = new roomPostInfo();
        data.roomTitle = inputRoomName.text;
        //data.roomYield = float.Parse(inputReturn.text);
        data.roomLimitedNumber = int.Parse(inputMaxPlayer.text);
        // data.isOpen = true;
        // List<string> roomMember = new List<string>();
        string id = LoginManager.Instance.playerData.memberId;

        data.memberId = id;
        print(id);
        print(LoginManager.Instance.playerData.memberId);
        //print(LoginManager.Instance.playerData.username);
        //print(LoginManager.Instance.playerData);

        HttpRequester requester = new HttpRequester();       
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
        requester.requestType = RequestType.POST;
        print("Post test");

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);

        HttpManager.instance.SendRequest(requester);
        print("Post 완료!");
    }

    public void CreateRoom()
    {
        // 방 옵션을 설정
        RoomOptions roomOptions = new RoomOptions();
        // 최대 인원 (0이면 최대인원)
        roomOptions.MaxPlayers = byte.Parse(inputMaxPlayer.text);
        // 룸 리스트에 보이지 않게? 보이게?
        roomOptions.IsVisible = true;
        // custom 정보를 셋팅
        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
        //hash["desc"] = int.Parse(inputReturn.text);
        //hash["desc"] = float.Parse(inputReturn.text);

        hash["room_name"] = inputRoomName.text;
        print("인풋 이름: " + inputRoomName.text);
        print("방이름:" + hash["room_name"]);
        //inputReturn = 0;
        //hash["desc"] = float.Parse(inputReturn.text);
        hash["desc"] = 0f;
        //hash["desc"] = 0;
        //hash["password"] = float.Parse(inputReturn.text);
        roomOptions.CustomRoomProperties = hash;
        // custom 정보를 공개하는 설정
        // roomOptions.CustomRoomPropertiesForLobby = new string[] {
        //     "desc", "map_id", "room_name", "password"
        // };
        roomOptions.CustomRoomPropertiesForLobby = new string[] {
            "desc", "map_id", "room_name"
        };
        print(roomOptions);

        // 방 생성 요청 (해당 옵션을 이용해서)
        print(2222222);

        //OnClickConnect();


        //PhotonNetwork.CreateRoom(inputRoomName.text, roomOptions);
        //print(PhotonNetwork.CurrentRoom.Name);
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


        //내 닉네임 설정
        //PhotonNetwork.NickName = inputNickName.text;
        //로비 진입 요청
        //PhotonNetwork.JoinLobby();
    }

    //로비 진입 성공시 호출
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        //LobbyScene으로 이동
        //PhotonNetwork.LoadLevel("CAJ_LobbyScene");
        //PhotonNetwork.LoadLevel("CAJ_CreateScene");
        //print("닉네임 : " + PhotonNetwork.NickName);]

        RoomOptions roomOptions = new RoomOptions();
        //roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.JoinOrCreateRoom(inputRoomName.text, roomOptions, TypedLobby.Default);
    }

    public void OnClickConnect()
    {
        //서버 접속 요청
        PhotonNetwork.ConnectUsingSettings();
    }

    //방이 생성되면 호출 되는 함수
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
    }

    //방 생성이 실패 될때 호출 되는 함수
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed , " + returnCode + ", " + message);
    }

    //방 참가 요청 (방 이름으로)
    //public void JoinRoom(string inputRoomname)
    //{
    //    PhotonNetwork.JoinRoom(inputRoomname);
    //}

    //방 참가가 완료 되었을 때 호출 되는 함수ge
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        if (PhotonNetwork.CurrentRoom.Name == "전체")
        {
            PhotonNetwork.LoadLevel("CAJ_LobbyRoomScene");
        }
        else
        {
            PhotonNetwork.LoadLevel("LYJ_RoomScene");
        }
    }

    //방 참가가 실패 되었을 때 호출 되는 함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + ", " + message);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator GetRoom()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

    ////방 만들 때, 방장 정보를 넘겨주고 싶다.
    //public void OnClickHolder()
    //{
    //    roomHolderInfo data = new roomHolderInfo();
    //    data.memberCode = LoginManager.Instance.playerData.memberCode;
    //    print(data.memberCode);

    //    HttpRequester requester = new HttpRequester();

    //    requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
    //    requester.requestType = RequestType.POST;


    //    print("test");

    //    requester.postData = JsonUtility.ToJson(data, true);
    //    print(requester.postData);


    //    ///////////
    //    requester.onComplete = OnCompleteHolder;
    //    HttpManager.instance.SendRequest(requester);
    //}

    //public void OnCompleteHolder(DownloadHandler handler)
    //{
    //    print("회원정보 보내기 완료 ");
    //}


    public InputField roomName;



    //roomTitle, roomDeleteInfo

    public RoomData roomData;
    public void OnClickDelete()
    {
        roomDeleteInfo data = new roomDeleteInfo();
        data.roomTitle = roomName.text;
        print("삭제하려는 방 이름 : " + roomName.text);
        

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room" +roomName.text;
        print(requester.url);
        requester.requestType = RequestType.DELETE;

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);


        //requester.onComplete = OnCilckDownload;


        HttpManager.instance.SendRequest(requester);

    }


}
