using System;
using System.Collections;
using System.Net;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//HTTP
using UnityEngine.Networking;
using System.IO;
using Photon.Pun;
using Photon.Realtime;
using SimpleJSON;



//코인 계산위해 보내야하는거

[Serializable]
public class ForCoinUpdate
{
    public string memberId;
    public int coinAmount;
}

//업데이트된 코인정보

[Serializable]

public class CoinUpdateInfo
{
    public int status;
    public string message;
    public int data;
}


//GetRoomAll로 방 목록 정보 받아오기부터 하고,
//CreateRoomListUI를 해준다 
//->코루틴 사용 !! 
public class LobbyRoomList : MonoBehaviourPunCallbacks
{
    public static LobbyRoomList instance;

    public Camera cam;

    void Start()
    {
        //StartCoroutine("Test");
        //GetRoom();
        GetRoomAll();
    }



    // 1. 방 정보 받아오기

    public void GetRoom()
    {
        HttpRequester requester = new HttpRequester();

        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
        requester.requestType = RequestType.GET;
        requester.onComplete = CompleteGetRoomList;

        HttpManager.instance.SendRequest(requester);
    }

    public void CompleteGetRoomList(DownloadHandler handler)
    {
        RoomData roomData = JsonUtility.FromJson<RoomData>(handler.text);
        //print("조회 완료");
    }

    public void GetRoomAll()
    {
        HttpRequester requester = new HttpRequester();

        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
        requester.requestType = RequestType.GET;
        requester.onComplete = CompleteGetRoomListAll;

        HttpManager.instance.SendRequest(requester);

        //NormalCreateRoomListUI();
        //CreateRoomUI();
        print("CreateRoomListUI 생성 함수 시작");
    }


    //public static List<RoomData> roomdata;
    public RoomData roomdata;

    //저장 경로
    //private string path;

    public int dataCount;

    public List<RoomData> roomList = new List<RoomData>();

    public List<string> roomTitles = new List<string>();
    public List<double> roomYields = new List<double>();

    //방목록 정보
    public void CompleteGetRoomListAll(DownloadHandler handler)
    {
        ListenData array = JsonUtility.FromJson<ListenData>(handler.text);
        print($"테스트: {array.data[1].roomCode}가 룸 코드다");

        foreach (RoomData rData in array.data)
        {
            roomTitles.Add(rData.roomTitle);
            roomYields.Add(rData.roomYield);

        }

        
        
        //전역 변수에 저장
        dataCount = array.data.Length;

        CreateRoom();

        //for (int i = 0; i < array.data.Count; i++)
        //{
        //    //print(array.data[i].roomTitle);
        //    //print(array.data[i].roomYield);
        //    //print("조회 완료");
        //}
    }

    // 2. 방 만들기
    public GameObject roomItemFactory1;
    public GameObject roomItemFactory2;
    public GameObject roomItemFactory3;
    public GameObject roomItemFactory4;
    public GameObject roomItemFactory5;

    public List<Transform> spawnPos;

    public Array NameArray;


    //방의 정보들
    private Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();

    //방 UI 만들기 
    public void CreateRoom()
    {
        int count = 0;

        //foreach (RoomInfo info in roomCache.Values)
        {
            //for (int i = dataCount; i > 0; i++)
            for (int i = 0; i < dataCount; i++)
            {
                double yield = roomYields[i];
                //double roomYields[i] = yield;
                
                // 1. 수익률 < -10
                if (yield <= -10)
                {
                    GameObject go = Instantiate(roomItemFactory1, spawnPos[count]);
                    LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                    //건물 밖 <- 방 이름
                    item.SetInfoName(roomTitles[i]);
                    //건물 밖 <- 방 수익률
                    item.SetInfoYield(roomYields[i]);

                    //건물 오브젝트 이름 = 방 이름
                    go.name = roomTitles[i];

                    count++;
                    print("생성됨!");
                }

                // 2.-10 < 수익률 < -3
                else if (yield > -10 && yield <= -3)
                {
                    GameObject go = Instantiate(roomItemFactory2, spawnPos[count]);
                    LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                    //건물 밖 <- 방 이름
                    item.SetInfoName(roomTitles[i]);
                    //건물 밖 <- 방 수익률
                    item.SetInfoYield(roomYields[i]);

                    //건물 오브젝트 이름 = 방 이름
                    go.name = roomTitles[i];

                    count++;
                    print("생성됨!");
                }

                // 3. -3 < 수익률 < 3
                else if (yield > -3 && yield <= 3)
                {
                    GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
                    LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                    //건물 밖 <- 방 이름
                    item.SetInfoName(roomTitles[i]);
                    //건물 밖 <- 방 수익률
                    item.SetInfoYield(roomYields[i]);

                    //건물 오브젝트 이름 = 방 이름
                    go.name = roomTitles[i];

                    count++;
                    print("생성됨!");
                }

                // 4. 3 < 수익률 < 20
                else if (yield > 3 && yield <= 20)
                {
                    GameObject go = Instantiate(roomItemFactory4, spawnPos[count]);
                    LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                    //건물 밖 <- 방 이름
                    item.SetInfoName(roomTitles[i]);
                    //건물 밖 <- 방 수익률
                    item.SetInfoYield(roomYields[i]);

                    //건물 오브젝트 이름 = 방 이름
                    go.name = roomTitles[i];

                    count++;
                    print("생성됨!");
                }

                // 5. 20 < 수익률 
                else
                {
                    GameObject go = Instantiate(roomItemFactory5, spawnPos[count]);
                    LobbyRoomItem item = go.GetComponent<LobbyRoomItem>();
                     //건물 밖 <- 방 이름
                item.SetInfoName(roomTitles[i]);
                //건물 밖 <- 방 수익률
                item.SetInfoYield(roomYields[i]);

                //건물 오브젝트 이름 = 방 이름
                go.name = roomTitles[i];

                count++;
                print("생성됨!");
                }
            }
        }
    }

    //public IEnumerator CreateRoomUI()
    //{
    //    yield return null;
    //    print("CreateRoomListUI 생성 함수 들어옴!");
    //    int count = 0;

    //    yield return null;

    //    print("dataCount : " + dataCount);

    //    yield return null;
    //    for (int i = 0; i < dataCount; i++)
    //    {
    //        print("for문 들어옴");
    //        GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
    //        count++;
    //        print("생성됨!");
    //    }
    //}


    //우선 룸 이름으로만! < 원래 : roomName (currPlayer / maxPlayer) >
    public void NormalSetInfo(string roomName)
    {
        //이름을 지정해준다 : 어느 정보의 룸네임으로! 
        //NormalSetInfo();

        //수익률 설정 
        //string sreturn = double정보.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ClickRay();
    }

    public string clickRoomName;
    public GameObject joinPop;

    public void ClickRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //int mask = (1 << 3);

            int mask = 1 << LayerMask.NameToLayer("Building");
            if (Physics.Raycast(ray, out hit, 150f, mask))
            {
                clickRoomName = hit.collider.gameObject.name.ToString();
                //클릭한 물체의 태그가 House라면 
                if (hit.collider.tag == "House")
                {
                    //가입창 팝업이 뜬다
                    joinPop.SetActive(true);

                    //1. 서버 접속 요청
                    //OnClickConnectLobby();

                    ////2. 로비 접속 요청
                    //print("LobbyJoin완료?");
                }
                else
                {
                    return;
                }
            }
        }
    }

    public void Okjoin()
    {
        //가입ok버튼을 누르면 300쿠키가 깎임
        ForCoinUpdate data = new ForCoinUpdate();
        data.memberId = LoginManager.Instance.playerData.memberId;
        data.coinAmount = -300;
        print(data.coinAmount);


        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/coin/update";
        requester.requestType = RequestType.POST;

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);


        requester.onComplete = OnUpdateCoin;
        HttpManager.instance.SendRequest(requester);

        OnClickConnectLobby();
        print("roomJoin완료");
    }

    public int coinData;
    public void OnUpdateCoin(DownloadHandler handler)
    {
        //깎인 쿠키를 받아온다
        string data = System.Text.Encoding.Default.GetString(handler.data);

        print("data : " + data);
        CoinUpdateInfo updateCoin = JsonUtility.FromJson<CoinUpdateInfo>(data);

        coinData = updateCoin.data;
        print(coinData);

        Coincanvas.Instance.coinText.text = coinData.ToString();

        joinPop.SetActive(false);
    }

    public void OnClickConnectLobby()
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

        RoomOptions roomOptions = new RoomOptions();
        //roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 20;

        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
        hash["room_name"] = clickRoomName;
        roomOptions.CustomRoomProperties = hash;
        roomOptions.CustomRoomPropertiesForLobby = new string[] {
            "room_name"
        };
        print(roomOptions);


        print("joinorCreateRoom 완료");
        Debug.Log("clickRoomName " + clickRoomName);
        
        PhotonNetwork.JoinOrCreateRoom("HIHI", roomOptions, TypedLobby.Default);
        print("111111111111111");
        
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
    }

    //방 참가가 완료 되었을 때 호출 되는 함수
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        //PhotonNetwork.LoadLevel("LYJ_RoomScene");
        print("방 참가 완료, 방 이름 : " + PhotonNetwork.CurrentRoom.Name);
        print("현재 방 인원 : " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    //방이 생성되면 호출 되는 함수
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
        print("방 이름 : " + PhotonNetwork.CurrentRoom.Name);
    }

    //방 생성이 실패 될때 호출 되는 함수
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed , " + returnCode + ", " + message);
    }

    //방 참가 요청 (방 이름으로)
    public void JoinRoom(string inputRoomname)
    {
        PhotonNetwork.JoinRoom(inputRoomname);
    }


    //방 참가가 실패 되었을 때 호출 되는 함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + ", " + message);
    }

}


