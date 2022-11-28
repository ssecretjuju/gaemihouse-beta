using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

[Serializable]
public class LikeCountInfo
{
    public int pushMemberCode;
    public string pushedYn;
    public int roomboardCode;
}

[Serializable]
public class LikeServerInfo
{
    public int roomBoardCode;
    public string roomBoardTitle;
    public string roomBoardContent;
    public string roomBoardRegistDate;
    public int memberCode;
    public int shareholderRoomCode;
    public int likeCount;
}

[Serializable]
public class ResponseCount
{
    public int status;
    public string message;
    public LikeServerInfo data;
}

public class Likeybutton : MonoBehaviour
{

    public LikeServerInfo likeBoardData;

    public void PressLikey()
    {
        //좋아요 수를 받기위해 서버에 요청한다

        LikeCountInfo data = new LikeCountInfo();
        data.roomboardCode = PressF.Instance.roomboardcode;
        data.pushMemberCode = LoginManager.Instance.playerData.memberCode;
        data.pushedYn = "Y";


        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/roomBoard/updatelikecount";
        requester.requestType = RequestType.POST;

        requester.onComplete = GetLikeCount;
        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);


        HttpManager.instance.SendRequest(requester);
        print("좋아요 받기 위해 정보보내기 완료");


    }
    public Text LikeNumber;

    public void GetLikeCount(DownloadHandler handler)
    {
        string data = System.Text.Encoding.Default.GetString(handler.data);

        print("data : " + data);

        ResponseCount likeyinfo = JsonUtility.FromJson<ResponseCount>(data);

        likeBoardData = likeyinfo.data;
        print(likeBoardData.likeCount);

        LikeNumber.text = likeBoardData.likeCount.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
