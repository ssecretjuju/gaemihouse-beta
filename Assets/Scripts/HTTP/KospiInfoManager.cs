using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

//�α��� �� ���� ������
//�����ؾ��� �ڽ��� ��
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


        if (Instance != null)
        {
            return;
        }

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
    //public bool playRain = false;
    public GameObject rainObj;
    public GameObject rainLight;
    public GameObject clearLight;

    public void OnSaveKospi(DownloadHandler handler)
    {

        string data = System.Text.Encoding.Default.GetString(handler.data);
        print("Kospi : " + data);

        GetKospi KospiInfo = JsonUtility.FromJson<GetKospi>(data);

        kospiInfo = KospiInfo.data;
        print("kospiInfo : " + kospiInfo);

        // 1. 0�̸� �ʿ� �� ������
        // 2. 1�̸� �ʿ� �ɺ� ������ 
        if (kospiInfo == 0)
        {
            print("�񰡳�����");
            Rain();
        }

        else
        {
            print("�񰡾ȳ�����");
            NoRain();
        }

    }

    public void Rain()
    {

        rainObj.SetActive(true);
        rainLight.SetActive(true);
        //BrightLight.SetActive(false);
        //print("���� 0 ���� -> : " + kospiInfo + "�� �� ");
    }

    public void NoRain()
    {
        rainObj.SetActive(false);
        rainLight.SetActive(false);
        clearLight.SetActive(true);
        ////DarkLight.SetActive(false);
        //RainGameObject.SetActive(false);
        //print("���� 0 �ƴ� -> : " + kospiInfo + "�� �� �� ");
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
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    rainObj.SetActive(true);
        //    rainLight.SetActive(true);
        //    //clearObj.SetActive(false);
        //    clearLight.SetActive(false);
        //}

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    rainObj.SetActive(false);
        //    rainLight.SetActive(false);
        //    //clearObj.SetActive(true);
        //    clearLight.SetActive(true);
        //}
    }
}
