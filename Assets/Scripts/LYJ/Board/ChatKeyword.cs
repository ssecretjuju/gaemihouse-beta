using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;


//서버에서 가져오는 정보

[Serializable]
public class KeywordData
{
    public string keywordId;
    public string keywordContent;
    public string keywordCount;
    public string keywordDate;
}

[Serializable]
public class ResponseKeywordData
{
    public int status;
    public string message;
    public KeywordData data;
}

public class ChatKeyword : MonoBehaviour
{
    //public static ChatKeyword Instance;

    public GameObject interObject;
    public GameObject popUpImage;
    public GameObject keywordBoard;
    bool onPlayer = false;

    void Update()
    {
        if (onPlayer == true)
        {
            popUpImage.SetActive(true);
            popUpImage.transform.forward = Camera.main.transform.forward;

            if (Input.GetKeyDown(KeyCode.F))
            {

                interObject.SetActive(true);
                OnKeywordClickAll();

            }
        }

        if (onPlayer == false)
        {
            popUpImage.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //만약 충돌한 것이 플레이어라면
        if (other.tag == "Player")
        {
            onPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onPlayer = false;
        }
    }


    public void OnKeywordClickAll()
    {
        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/keyword";
        //print(requester.url);
        requester.requestType = RequestType.GET;

        requester.onComplete = OnKeyword;


        HttpManager.instance.SendRequest(requester);
    }

    public List<int> keywordInfo;
    public List<Text> keywordText;
    public void OnKeyword(DownloadHandler handler)
    {
        JSONNode node = JSON.Parse(handler.text);
        keywordInfo.Clear();

        for (int i = 0; i < node["data"].Count; ++i)
        {

            keywordInfo.Add(node["data"][i]["keywordContent"]);
            print("제목 +" + node["data"][0]["keywordContent"]);

            keywordText[0].text = node["data"][0]["keywordContent"];
            keywordText[1].text = node["data"][1]["keywordContent"];
            keywordText[2].text = node["data"][2]["keywordContent"];
            //keywordText[3].text = node["data"][3]["keywordContent"];
            //keywordText[4].text = node["data"][4]["keywordContent"];

        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame

    }
}
