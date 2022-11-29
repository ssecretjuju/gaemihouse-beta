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
public class MemoBoardInfo
{
    public int status;
    public string message;
    public MemoBoardInfo data;
}


public class PressF1 : MonoBehaviour
{

    public GameObject Memoboard;
    public Transform MemoItemParent;
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
                OnGetMemoboard();

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

    

    public void OnGetMemoboard()
    {
        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/community/select";
        requester.requestType = RequestType.GET;

        requester.onComplete = GetMemoBoard;

        HttpManager.instance.SendRequest(requester);
        print("서브보드 조회 완료");

    }

    public List<int> memoboardinfo;
    //public GameObject confirmWriting;

    public void GetMemoBoard(DownloadHandler handler)
    {
        
        JSONNode node = JSON.Parse(handler.text);
        memoboardinfo.Clear();
        //confirmWriting = SubboardManager.Instance.confirmWindow;
        //confirmWriting = GameObject.Find("SubBoardCanvas").transform.GetChild(0).gameObject;

        for (int i = 0; i < node["data"].Count; ++i)
        {
            //ss = node["data"][i]["roomCode"];
            //print(ss);
            memoboardinfo.Add(node["data"][i]["communityTitle"]);
            print("제목 +" + node["data"][i]["roomBoardTitle"]);
            memoboardinfo.Add(node["data"][i]["communityContent"]);

            GameObject Item = Instantiate(Memoboard, MemoItemParent);
            //SubboardClick subboardClick = Item.GetComponent<SubboardClick>();
            //subboardClick.subContent = node["data"][i]["roomBoardContent"];
            //subboardClick.subLikey = node["data"][i]["likeCount"].ToString();
            //subboardClick.subTitle = node["data"][i]["roomBoardTitle"];

            Item.transform.GetChild(0).GetComponent<InputField>().text = node["data"][i]["communityTitle"];
            Item.transform.GetChild(1).GetComponent<InputField>().text = node["data"][i]["communityContent"];           
            

            //content.text = node["data"][i]["roomBoardContent"];           
            //confirmTitle.text = node["data"][i]["roomBoardTitle"]; 
           
            //SubboardManager.Instance.confirmWindow.transform.GetChild(1).GetComponent<Text>().text = node["data"][i]["roomBoardContent"];
            //Item.transform.GetChild(2).GetComponent<Text>().text = node["data"][i]["roomBoardRegistDate"];
            //SubboardManager.Instance.confirmWindow.transform.GetChild(3).GetComponent<Text>().text = node["data"][i]["likeCount"];

            //SubboardClick confirmSet = Item.GetComponent<SubboardClick>();
            //confirmSet.Set(Item.transform.GetChild(0).GetComponent<InputField>().text, SubboardManager.Instance.confirmWindow.transform.GetChild(1).GetComponent<Text>().text, SubboardManager.Instance.confirmWindow.transform.GetChild(3).GetComponent<Text>().text, confirmWriting);
        }

    }

    public GameObject boardCanvas;
    public void OnEscBtn()
    {
        boardCanvas.SetActive(false);
       
    }

}

