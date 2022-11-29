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


    //public ParticleSystem RainParticleSystem;
    public GameObject RainGameObject;

    private void Awake()
    {
        ////처음 : 비 파티클 실행 x
        //RainGameObject.SetActive(false);

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
        print("Kospi : " + data);

        GetKospi KospiInfo = JsonUtility.FromJson<GetKospi>(data);

        kospiInfo = KospiInfo.data;
        print("kospiInfo : " + kospiInfo);

        // 1. 0이면 맵에 비가 내린다
        // 2. 가져온 코스피 지수 값이 1이면 비가 내리지 않는다
        Rain();


    }

    public void Rain()
    {
        if (kospiInfo == 0)
        {
            RainGameObject.SetActive(true);
            print("지수 0 맞음 -> : " + kospiInfo + "비 옴 ");
        }

        else
        {
            RainGameObject.SetActive(false);
            print("지수 0 아님 -> : " + kospiInfo + "비 안 옴 ");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        OnGetKospi();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
