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
using Photon.Pun;

// ������ Ŀ���� ����
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
public class AntCustom : MonoBehaviourPun
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
            print("�κ��");
            onGetCustomData();
        }

        if (SceneManager.GetActiveScene().name == "LYJ_RoomScene")
        {
            //CustomCanvas.SetActive(false);
            print("���");
            if (photonView.IsMine)
            {
                onGetCustomData();
            }
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

        //������ ����� Ŀ���Ұ����� �����´�.
        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/avatar/" + colorMemberNickname;
        requester.requestType = RequestType.GET;

        requester.onComplete = OnLoadCustom;

        HttpManager.instance.SendRequest(requester);
        print("Ŀ���� ���� �� �Ϸ�!");
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

        faceType[0].SetActive(false);
        bodyType[0].SetActive(false);
        accType[0].SetActive(false);

        faceType[customdata.faceType].SetActive(true);
        bodyType[customdata.bodyType].SetActive(true);
        accType[customdata.accType].SetActive(true);

        if (photonView.IsMine && photonView.Owner != null)
        {
            photonView.RPC("SetCharColor", RpcTarget.AllBuffered, customdata.faceType, customdata.bodyType, customdata.accType);
        }
    }

    [PunRPC]
    public void SetCharColor(int face, int body, int acc)
    {
        faceType[0].SetActive(false);
        bodyType[0].SetActive(false);
        accType[0].SetActive(false);

        faceType[face].SetActive(true);
        bodyType[body].SetActive(true);
        accType[acc].SetActive(true);
    }

}
