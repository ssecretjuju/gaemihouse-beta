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
            //popUpImage.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                interObject.SetActive(true);
                OnGetSubboard();

            }
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

        GameObject Item = Instantiate(Subboard, boardItemParent);
    }

    public List<int> subboardinfo;

    public void GetRoomBoard(DownloadHandler handler)
    {
        JSONNode node = JSON.Parse(handler.text);
        subboardinfo.Clear();

        for (int i = 0; i < node["data"].Count; ++i)
        {
            //ss = node["data"][i]["roomCode"];
            //print(ss);
            subboardinfo.Add(node["data"][i]["roomBoardTitle"]);
            print("제목 +" + node["data"][i]["roomBoardTitle"]);
            subboardinfo.Add(node["data"][i]["roomBoardContent"]);
            print("내용 +" + node["data"][i]["roomBoardContent"]);
            subboardinfo.Add(node["data"][i]["likeCount"]);
            print("좋아요 수 +" + node["data"][i]["likeCount"]);


        }
    }
}

