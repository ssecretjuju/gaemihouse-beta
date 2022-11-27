using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

//로그인 시 값을 가져옴
//저장해야할 코스피 값
[Serializable]
public class KospiInfo
{
    public int kospiData;
}

[Serializable]
public class GetKospi
{
    public int status;
    public string message;
    public int data;
}

public class KospiInfoManager : MonoBehaviour
{
    public static KospiInfoManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OnGetKospi()
    {
        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/account/kospi";
        print(requester.url);
        requester.requestType = RequestType.GET;

        requester.onComplete = OnSaveKospi;


        HttpManager.instance.SendRequest(requester);
    }

    public int kospiInfo;

    public void OnSaveKospi(DownloadHandler handler)
    {

        string data = System.Text.Encoding.Default.GetString(handler.data);
        print("data : " + data);

        GetKospi KospiInfo = JsonUtility.FromJson<GetKospi>(data);

        kospiInfo = KospiInfo.data;
        print(kospiInfo);

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
