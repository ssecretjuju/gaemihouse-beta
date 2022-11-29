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
    public GameObject RainGameObject;

    private void Awake()
    {
        ////ó�� : �� ��ƼŬ ���� x
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

        // 1. 0�̸� �ʿ� �� ������
        // 2. ������ �ڽ��� ���� ���� 1�̸� �� ������ �ʴ´�
        Rain();


    }

    public void Rain()
    {
        if (kospiInfo == 0)
        {
            RainGameObject.SetActive(true);
            print("���� 0 ���� -> : " + kospiInfo + "�� �� ");
        }

        else
        {
            RainGameObject.SetActive(false);
            print("���� 0 �ƴ� -> : " + kospiInfo + "�� �� �� ");
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
