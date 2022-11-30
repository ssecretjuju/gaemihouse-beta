using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

//로그인창에 아이디,비밀번호를 입력하고 서버에 json으로 보낸다
//서버에 내가 보낼 정보들
[Serializable]
public class LoginInfo
{
    public string memberId;
    public string memberPassword;
}

//로그인 버튼을 눌렀을때
//내가 서버에서 가져와야할 회원정보들

[Serializable]
public class PlayerData
{
    public int memberCode;
    public string memberId;
    public string memberPassword;
    public string memberRole;
    public string memberNickname;
    public string memberName;
    public string stockFirm;
    public int accountNum;
    public string appKey;
    public string appSecret;
    public string appKeyExpiresin;
    public string termsAgreementYn;
    public int reportCount;
    public string blacklistYn;
    public string stockCareer;
    public string withdrawYn;
    public string authorities;
    public bool enabled;
    public string username;
    public string password;
    public bool accountNonExpired;
    public bool accountNonLocked;
    public bool credentialsNonExpired;
    public string yield;

    //public string data; //수익률 data
}

[Serializable]
public class ResponseData
{
    public int status;
    public string message;
    public PlayerData data;
}

public class LoginManager : MonoBehaviour
{
    public static LoginManager Instance;

    private void Awake()
    {
        //만약에 instance가 null이라면
        if (Instance == null)
        {
            //instance에 나를 넣겠다.
            Instance = this;
            //씬이 전환이 되어도 나를 파괴되지 않게 하겠다.
            DontDestroyOnLoad(gameObject);
        }
        //그렇지 않으면
        else
        {
            //나를 파괴하겠다.
            Destroy(gameObject);
        }
    }
    public InputField id;
    public InputField password;
    public PlayerData playerData;

    public void OnClickLogin()
    {
        LoginInfo data = new LoginInfo();
        data.memberId = id.text;
        print(id.text);
        data.memberPassword = password.text;

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/member/id/" + id.text;
        print(requester.url);
        requester.requestType = RequestType.GET;

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);


        requester.onComplete = OnCilckDownload;


        HttpManager.instance.SendRequest(requester);
    }

    public void OnCilckDownload(DownloadHandler handler)
    {
        string data = System.Text.Encoding.Default.GetString(handler.data);

        print("data : " + data);

        ResponseData responseData = JsonUtility.FromJson<ResponseData>(data);

        playerData = responseData.data;

        print(playerData.yield);


        //PlayerPrefs.SetString("token", playerData.accessToken);

        //print("조회 완료");

        SceneManager.LoadScene("LYJ_CharacterSelection");

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