using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Networking;
using System;

//버튼을 누르면 다음날 바뀐 수익률 값을 가져온다.

//가져올 수익률 값
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

    public string roomtitle;
    public Text roomtitles;
    public int titleDataCount;

    
    public void onCheatKey()
    {
        titleDataCount = LobbyRoomList.instance.dataCount;

        for (int i = 0; i < titleDataCount; i++)
        {
            roomtitle = LobbyRoomList.instance.roomTitles[i];
        }

        print("룸타이틀 목록 :" + roomtitle);

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/keyword"; 
        //print(requester.url);
        requester.requestType = RequestType.GET;

        //requester.onComplete = OnCilckDownloadAll;


        HttpManager.instance.SendRequest(requester);
    }
}
