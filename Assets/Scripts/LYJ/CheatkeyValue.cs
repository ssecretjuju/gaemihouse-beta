using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using SimpleJSON;

//��ư�� ������ ������ �ٲ� ���ͷ� ���� �����´�.

//���� ������ ������: ��Ÿ��Ʋ

public class RoomtitleInfo
{
    public string roomTitle;
}

//������ ���ͷ� ��
public class CheatYieldInfo
{
    public int status;
    public string message;
    public double data;
}

public class CheatkeyValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetRoomTitle()
    {
        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
        //print(requester.url);
        requester.requestType = RequestType.GET;

        requester.onComplete = OnTitleDownload;

        HttpManager.instance.SendRequest(requester);
        print("��Ÿ��Ʋ �� �Ϸ�!");
    }

    public string titles;
    public List<int> roomtitleinfo;
    public void OnTitleDownload(DownloadHandler handler)
    {
        JSONNode node = JSON.Parse(handler.text);
        roomtitleinfo.Clear();

        for (int i = 0; i < node["data"].Count; ++i)
        {
            //ss = node["data"][i]["roomCode"];
            //print(ss);
            roomtitleinfo.Add(node["data"][i]["roomTitle"]);
            print("��Ÿ��Ʋ :" + node["data"][i]["roomTitle"]);

            titles = node["data"][i]["roomTitle"];
            print(titles);

            HttpRequester requester = new HttpRequester();
            requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room/yield/" + titles;
            //print(requester.url);
            requester.requestType = RequestType.GET;
            requester.onComplete = DownloadYield;
            HttpManager.instance.SendRequest(requester);
        }


    }

    public double yielddata;

    public void DownloadYield(DownloadHandler handler)
    {
        string data = System.Text.Encoding.Default.GetString(handler.data);

        print("data : " + data);
        CheatYieldInfo responseyieldData = JsonUtility.FromJson<CheatYieldInfo>(data);

        yielddata = responseyieldData.data;

        print("ġƮŰ :" + yielddata);
    }
}
