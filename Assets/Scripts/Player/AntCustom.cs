using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

// 가져올 커스텀 정보
[Serializable]
public class CustomData
{
    //public string colorMemberNickname;
    public int faceType;
    public int bodyType;
    public int accType;
}

[Serializable]
public class ResponseCustomData
{
    public int status;
    public string message;
    public CustomData data;
}
public class AntCustom : MonoBehaviour
{
    public static AntCustom instance;


    public GameObject[] faceType;
    public GameObject[] bodyType;
    public GameObject[] accType;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene().name == "[Beta]LYJ_LobbyScene")
        {
            //CustomCanvas.SetActive(false);
            print("로비씬");
            onGetCustomData();
        }

        if (SceneManager.GetActiveScene().name == "LYJ_RoomScene")
        {
            //CustomCanvas.SetActive(false);
            print("룸씬");
            onGetCustomData();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CustomData customdata;
    public string colorMemberNickname;

    public void onGetCustomData()
    {
        colorMemberNickname = LoginManager.Instance.playerData.memberNickname;
        //print(colorMemberNickname);

        //서버에 저장된 커스텀값들을 가져온다.
        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/avatar/" + colorMemberNickname;
        requester.requestType = RequestType.GET;

        requester.onComplete = OnLoadCustom;

        HttpManager.instance.SendRequest(requester);
        print("커스텀 정보 겟 완료!");
    }

    
    public void OnLoadCustom(DownloadHandler handler)
    {
        //JObject jobject = JObject.Parse(handler.text);
        //print(jobject.ToString());


        string data = System.Text.Encoding.Default.GetString(handler.data);

        print("data : " + data);
        ResponseCustomData responseCustomData = JsonUtility.FromJson<ResponseCustomData>(data);

        customdata = responseCustomData.data;

        print(customdata.faceType);


        faceType[customdata.faceType].SetActive(true);
        bodyType[customdata.bodyType].SetActive(true);
        accType[customdata.accType].SetActive(true);

        
    }

}
