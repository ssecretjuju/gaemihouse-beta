using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

//�Խ��� ��ȸ �� �޾ƿ��� ����
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
    //�÷��̾ Ư�� �繰�� �ٰ������� FŰ�� ���� ���� ������ ���.

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
        //���� �浹�� ���� �÷��̾���
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
        print("���꺸�� ��ȸ �Ϸ�");

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
            print("���� +" + node["data"][i]["roomBoardTitle"]);
            subboardinfo.Add(node["data"][i]["roomBoardContent"]);
            print("���� +" + node["data"][i]["roomBoardContent"]);
            subboardinfo.Add(node["data"][i]["likeCount"]);
            print("���ƿ� �� +" + node["data"][i]["likeCount"]);


        }
    }
}

