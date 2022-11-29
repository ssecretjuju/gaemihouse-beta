using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

//게시판 조회 시 받아오는 정보
public class RoomBoardInfo
{
    public int status;
    public string message;
    public RoomBoardInfo data;
}


public class PressF : MonoBehaviour
{

    public GameObject Subboard;
    public Transform boardItemParent;
    //플레이어가 특정 사물에 다가갔을때 F키를 눌러 실행 문구가 뜬다.

    bool onPlayer = false;
    public GameObject interObject;
    public GameObject popUpImage;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onPlayer == true)
        {
            popUpImage.SetActive(true);
            popUpImage.transform.forward = Camera.main.transform.forward;

            if (Input.GetKeyDown(KeyCode.F))
            {
                interObject.SetActive(true);
                OnGetSubboard();

            }
        }



        if (onPlayer == false)
        {
            popUpImage.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //만약 충돌한 것이 플레이어라면
        if (other.tag == "Player")
        {
            onPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onPlayer = false;
        }
    }

    

    public void OnGetSubboard()
    {
        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/roomBoard/select";
        requester.requestType = RequestType.GET;

        requester.onComplete = GetRoomBoard;

        HttpManager.instance.SendRequest(requester);
        print("서브보드 조회 완료");

    }

    public List<int> subboardinfo;
    GameObject confirmWriting;
    public int boardmembercode;
    public int roomboardcode;
    public void GetRoomBoard(DownloadHandler handler)
    {
        
        JSONNode node = JSON.Parse(handler.text);
        subboardinfo.Clear();
        confirmWriting = SubboardManager.Instance.confirmWindow;
        //confirmWriting = GameObject.Find("SubBoardCanvas").transform.GetChild(0).gameObject;

        for (int i = 0; i < node["data"].Count; ++i)
        {
            //ss = node["data"][i]["roomCode"];
            //print(ss);
            subboardinfo.Add(node["data"][i]["roomBoardTitle"]);
            print("제목 +" + node["data"][i]["roomBoardTitle"]);
            subboardinfo.Add(node["data"][i]["roomBoardContent"]);
            print("내용 +" + node["data"][i]["roomBoardContent"]);
            subboardinfo.Add(node["data"][i]["roomBoardRegistDate"]);
            print("날짜 +" + node["data"][i]["roomBoardRegistDate"]);
            subboardinfo.Add(node["data"][i]["memberNickname"]);
            subboardinfo.Add(node["data"][i]["likeCount"]);
            print("좋아요 수 +" + node["data"][i]["likeCount"]);
            subboardinfo.Add(node["data"][i]["memberCode"]);
            print("게시판멤버코드 +" + node["data"][i]["memberCode"]);
            subboardinfo.Add(node["data"][i]["roomBoardCode"]);

            GameObject Item = Instantiate(Subboard, boardItemParent);
            SubboardClick subboardClick = Item.GetComponent<SubboardClick>();
            subboardClick.subContent = node["data"][i]["roomBoardContent"];
            subboardClick.subLikey = node["data"][i]["likeCount"].ToString();
            subboardClick.subTitle = node["data"][i]["roomBoardTitle"];
            print("subboardClick " + i + " 번째 likey" + subboardClick.subLikey);
            Item.transform.GetChild(0).GetComponent<InputField>().text = node["data"][i]["roomBoardTitle"];
            Item.transform.GetChild(1).GetComponent<Text>().text = node["data"][i]["memberNickname"];         
            Item.transform.GetChild(2).GetComponent<Text>().text = node["data"][i]["roomBoardRegistDate"];
            roomboardcode = node["data"][i]["roomBoardCode"];
            print("룸보드 코드:" + roomboardcode);

            //content.text = node["data"][i]["roomBoardContent"];           
            //confirmTitle.text = node["data"][i]["roomBoardTitle"]; 

            //SubboardManager.Instance.confirmWindow.transform.GetChild(1).GetComponent<Text>().text = node["data"][i]["roomBoardContent"];
            //Item.transform.GetChild(2).GetComponent<Text>().text = node["data"][i]["roomBoardRegistDate"];
            //SubboardManager.Instance.confirmWindow.transform.GetChild(3).GetComponent<Text>().text = node["data"][i]["likeCount"];

            //SubboardClick confirmSet = Item.GetComponent<SubboardClick>();
            //confirmSet.Set(Item.transform.GetChild(0).GetComponent<InputField>().text, SubboardManager.Instance.confirmWindow.transform.GetChild(1).GetComponent<Text>().text, SubboardManager.Instance.confirmWindow.transform.GetChild(3).GetComponent<Text>().text, confirmWriting);
        }
        



    }
}

