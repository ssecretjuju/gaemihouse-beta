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
    //public GameObject RainEffect;
    //public GameObject DarkLight;
    //public GameObject BrightLight;
    public GameObject RainGameObject;
    public GameObject PetalGameObject;

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
        //RainEffectGetComponentInChildren<ParticleSystem>().gameObject;
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
    public bool playRain = false;
    public ParticleSystem particleObject;
    public void OnSaveKospi(DownloadHandler handler)
    {

        string data = System.Text.Encoding.Default.GetString(handler.data);
        print("Kospi : " + data);

        GetKospi KospiInfo = JsonUtility.FromJson<GetKospi>(data);

        kospiInfo = KospiInfo.data;
        print("kospiInfo : " + kospiInfo);

        // 1. 0이면 맵에 비가 내린다
        // 2. 1이면 맵에 꽃비가 내린다 
        if (kospiInfo == 0)
        {
            Rain();
        }

        else
        {
            NoRain();
        }




    }

    public void Rain()
    {

        //RainGameObject.SetActive(true);
        ////DarkLight.SetActive(true);
        //BrightLight.SetActive(false);
        //print("지수 0 맞음 -> : " + kospiInfo + "비 옴 ");
    }

    public void NoRain()
    {
        ////BrightLight.SetActive(true);
        ////DarkLight.SetActive(false);
        //RainGameObject.SetActive(false);
        //print("지수 0 아님 -> : " + kospiInfo + "비 안 옴 ");
    }

    public void PetalRain()
    {

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
