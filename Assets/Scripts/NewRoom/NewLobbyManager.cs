using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Random = UnityEngine.Random;



//[Serializable]
//public class roomPostInfo
//{
//    public string roomTitle;
//    public int roomLimitedNumber;
//}

public class NewLobbyManager : MonoBehaviourPunCallbacks
{
    public Camera cam;

    public GameObject roomItemFactory1;
    public GameObject roomItemFactory2;
    public GameObject roomItemFactory3;
    public GameObject roomItemFactory4;
    public GameObject roomItemFactory5;
    
    ////방이름 InputField
    //public InputField inputRoomName;
    ////수익률 InputField
    //public InputField inputReturn;
    ////총인원 InputField
    //public InputField inputMaxPlayer;
    
    ////방참가 Button
    //public Button btnJoin;
    ////방생성 Button
    //public Button btnCreate;

    //방의 정보들   
    Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();
    //룸 리스트 Content
    public Transform trListContent;
    
    //룸 위치 리스트
    //public List<Transform> buildingPos;
    //public Vector3[] spawnPos;
    public List<Transform> spawnPos;

    //룸 종류 리스트
    //public List<GameObject> RoomItemFactory;
    

    ////map Thumbnail
    //public GameObject[] mapThumbs;

    //public void ClickRay()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        //Building 레이어만 충돌 체크 
    //        int mask = (1 << 3);
    //        if (Physics.Raycast(ray, out hit, 125f, mask))
    //        {
    //            Debug.Log(hit.transform.gameObject);
    //            string clickRoomName = hit.collider.gameObject.name.ToString();
    //            Debug.Log(clickRoomName);
    //            //클릭한 물체의 태그가 House라면 
    //            if (hit.collider.tag == "House")
    //            {
    //                JoinRoom(clickRoomName);
    //            }
    //            else
    //            {
    //                return;
    //            }
    //        }
    //    }
    //}

    //void Update()
    //{
    //    ClickRay();
    //}

    //void Start()
    //{
    //    //cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    //    // 방이름(InputField)이 변경될때 호출되는 함수 등록
    //    inputRoomName.onValueChanged.AddListener(OnRoomNameValueChanged);
    //    // 총인원(InputField)이 변경될때 호출되는 함수 등록
    //    inputMaxPlayer.onValueChanged.AddListener(OnMaxPlayerValueChanged);
    //}

    //public void OnRoomNameValueChanged(string s)
    //{
    //    //참가
    //    btnJoin.interactable = s.Length > 0;
    //    //생성
    //    btnCreate.interactable = s.Length > 0 && inputMaxPlayer.text.Length > 0;
    //}

    //public void OnMaxPlayerValueChanged(string s)
    //{
    //    //생성
    //    btnCreate.interactable = s.Length > 0 && inputRoomName.text.Length > 0;
    //}

    //public void PostRoomInfoClick()
    //{
    //    roomPostInfo data = new roomPostInfo();
    //    data.roomTitle = inputRoomName.text;
    //    //data.roomYield = float.Parse(inputReturn.text);
    //    data.roomLimitedNumber = int.Parse(inputMaxPlayer.text);
    //    // data.isOpen = true;
    //    // List<string> roomMember = new List<string>();

    //    HttpRequester requester = new HttpRequester();
    //    requester.url = "http://3.34.133.115:8080/shareholder-room";
    //    requester.requestType = RequestType.POST;
    //    print("Post test");
        
    //    requester.postData = JsonUtility.ToJson(data, true);
    //    print(requester.postData);
        
    //    HttpManager.instance.SendRequest(requester);
    //    print("Post 완료!");
    //}

    //방 생성
    //public void CreateRoom()
    //{
    //    // 방 옵션을 설정
    //    RoomOptions roomOptions = new RoomOptions();
    //    // 최대 인원 (0이면 최대인원)
    //    roomOptions.MaxPlayers = byte.Parse(inputMaxPlayer.text);
    //    // 룸 리스트에 보이지 않게? 보이게?
    //    roomOptions.IsVisible = true;
    //    // custom 정보를 셋팅
    //    ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
    //    //hash["desc"] = int.Parse(inputReturn.text);
    //    //hash["desc"] = float.Parse(inputReturn.text);
        
    //    hash["map_id"] = Random.Range(0, mapThumbs.Length);
    //    hash["room_name"] = inputRoomName.text;
    //    print("인풋 이름: "+ inputRoomName.text);
    //    print("방이름:" + hash["room_name"]);
    //    //inputReturn = 0;
    //    //hash["desc"] = float.Parse(inputReturn.text);
    //    hash["desc"] = 10.5f;
    //    //hash["desc"] = 0;
    //    //hash["password"] = float.Parse(inputReturn.text);
    //    roomOptions.CustomRoomProperties = hash;
    //    // custom 정보를 공개하는 설정
    //    // roomOptions.CustomRoomPropertiesForLobby = new string[] {
    //    //     "desc", "map_id", "room_name", "password"
    //    // };
    //    roomOptions.CustomRoomPropertiesForLobby = new string[] {
    //        "desc", "map_id", "room_name"
    //    };
    //    print(roomOptions);
                
    //    // 방 생성 요청 (해당 옵션을 이용해서)
    //    print(2222222);
    //    PhotonNetwork.CreateRoom(inputRoomName.text, roomOptions);
    //    //print(PhotonNetwork.CurrentRoom.Name);
    //}

    ////방이 생성되면 호출 되는 함수
    //public override void OnCreatedRoom()
    //{
    //    base.OnCreatedRoom();
    //    print("OnCreatedRoom");
    //}

    ////방 생성이 실패 될때 호출 되는 함수
    //public override void OnCreateRoomFailed(short returnCode, string message)
    //{
    //    base.OnCreateRoomFailed(returnCode, message);
    //    print("OnCreateRoomFailed , " + returnCode + ", " + message);
    //}

    ////방 참가 요청 (방 이름으로)
    //public void JoinRoom(string inputRoomname)
    //{
    //    PhotonNetwork.JoinRoom(inputRoomname);
    //}

    ////방 참가가 완료 되었을 때 호출 되는 함수
    //public override void OnJoinedRoom()
    //{
    //    base.OnJoinedRoom();
    //    print("OnJoinedRoom");
    //    if (PhotonNetwork.CurrentRoom.Name == "전체")
    //    {
    //        PhotonNetwork.LoadLevel("CAJ_LobbyRoomScene");
    //    }
    //    else
    //    {
    //        PhotonNetwork.LoadLevel("CAJ_RoomScene");
    //    }
    //}

    ////방 참가가 실패 되었을 때 호출 되는 함수
    //public override void OnJoinRoomFailed(short returnCode, string message)
    //{
    //    base.OnJoinRoomFailed(returnCode, message);
    //    print("OnJoinRoomFailed, " + returnCode + ", " + message);
    //}

    //방에 대한 정보가 변경되면 호출 되는 함수(추가/삭제/수정)
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            print(roomList[i].Name);
        }

        base.OnRoomListUpdate(roomList);

        //룸리스트 UI 를 전체삭제
        DeleteRoomListUI();
        //룸리스트 정보를 업데이트
        UpdateRoomCache(roomList);
        //룸리스트 UI 전체 생성
        //CreateRoomListUI();
    }

    void DeleteRoomListUI()
    {
        //foreach(Transform tr in spawnPos)
        foreach(Transform tr in trListContent)
        {
            Destroy(tr.gameObject);
        }
    }

    void UpdateRoomCache(List<RoomInfo> roomList)
    {
        for(int i = 0; i < roomList.Count; i++)
        {
            // 수정, 삭제
            if(roomCache.ContainsKey(roomList[i].Name))
            {
                //만약에 해당 룸이 삭제된것이라면
                if(roomList[i].RemovedFromList)
                {
                    //roomCache 에서 해당 정보를 삭제
                    roomCache.Remove(roomList[i].Name);
                }
                //그렇지 않다면
                else
                {
                    //정보 수정
                    roomCache[roomList[i].Name] = roomList[i];
                }
            }
            //추가
            else
            {
                roomCache[roomList[i].Name] = roomList[i];
            }
        }
    }

    
    
    //void CreateRoomListUI()
    //{
    //    print("CreateRoomListUI()");
    //    int count = 0;
    //    foreach(RoomInfo info in roomCache.Values)
    //    {
    //        float desc = (float)(info.CustomProperties["desc"]);
            
    //        //GameObject go = GameObject.Instantiate()
    //        //for (int i = 0; i < 10; i++)
    //        //for (int i = 0; i < 10; i++)
    //        {
    //            // 1. 수익률 < 0
    //            if (desc <= -10)
    //            {
    //                //for (roomCache.ContainsKey(roomList[i]))
    //                //룸아이템 만든다.
    //                GameObject go = Instantiate(roomItemFactory1, spawnPos[count]);
    //                //룸아이템 정보를 셋팅(방제목(0/0))
    //                RoomItem item = go.GetComponent<RoomItem>();
    //                item.SetInfo(info);
    //            }
    //            // 2. 수익률 == 0
    //            else if (desc > -10 && desc <=-3)
    //            {
    //                //룸아이템 만든다.
    //                GameObject go = Instantiate(roomItemFactory2, spawnPos[count]);
    //                //룸아이템 정보를 셋팅(방제목(0/0))
    //                RoomItem item = go.GetComponent<RoomItem>();
    //                item.SetInfo(info);
    //            }
    //            // 3. 0 < 수익률 < 100
    //            else if (desc > -3 && desc <= 3)
    //            {
    //                //룸아이템 만든다.
    //                GameObject go = Instantiate(roomItemFactory3, spawnPos[count]);
    //                //룸아이템 정보를 셋팅(방제목(0/0))
    //                RoomItem item = go.GetComponent<RoomItem>();
    //                item.SetInfo(info);
    //            }
    //            // 4. 수익률 > 100
    //            else if (desc > 3 && desc <= 20)
    //            {
    //                //룸아이템 만든다.
    //                GameObject go = Instantiate(roomItemFactory4, spawnPos[count]);
    //                //룸아이템 정보를 셋팅(방제목(0/0))
    //                RoomItem item = go.GetComponent<RoomItem>();
    //                item.SetInfo(info);
    //            }
    //            // 5. 수익률 > 20
    //            else
    //            {
    //                //룸아이템 만든다.
    //                GameObject go = Instantiate(roomItemFactory5, spawnPos[count]);
    //                //룸아이템 정보를 셋팅(방제목(0/0))
    //                RoomItem item = go.GetComponent<RoomItem>();
    //                item.SetInfo(info);

    //                //item.OnClickAction = JoinRoom;
    //            }

    //        }
            
    //        count++;
    //        print("룸 개수 : " + count);
    //        print(33333333);
    //        //float desc = (float)info.CustomProperties["desc"];
    //        //int map_id = (int)info.CustomProperties["map_id"];
    //        //float password = (float)info.CustomProperties["password"];
    //        //print("desc : " + desc);
    //        //print("password : " + password);
    //    }
    //}




    ////이전 Thumbnail id
    //int prevMapId = -1;
    ////void SetRoomName(string room, int map_id, float desc)
    //void SetRoomName(string room, int map_id)
    //{
    //    //룸이름 설정
    //    inputRoomName.text = room;
        
    //    //룸수익률 설정

    //    //만약에 이전 맵 Thumbnail이 활성화가 되어있다면
    //    if(prevMapId > -1)
    //    {
    //        //이전 맵 Thumbnail을 비활성화
    //        mapThumbs[prevMapId].SetActive(false);
    //    }

    //    //맵 Thumbnail 설정
    //    mapThumbs[map_id].SetActive(true);

    //    //이전 맵 id 저장
    //    prevMapId = map_id;
    //}
}