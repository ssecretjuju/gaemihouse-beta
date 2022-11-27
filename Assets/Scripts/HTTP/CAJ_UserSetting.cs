 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
//
// //유저정보 
// [Serializable]
// public class UserInfo
// {
//     public string id;
//     public string password;
//     public string childName;
//     public string childBirthday;
//     public string childGender;
//
//     //public int appleClearCount = 0;
//
// }

//로그인창에 아이디,비밀번호를 입력하고 서버에 json으로 보낸다

public class CAJ_UserSetting : MonoBehaviour
{
    public InputField id;
    public InputField password;
    public InputField childName;
    public InputField childBirthday;
    public Dropdown childGender;

    public InputField Logid;
    public InputField Logpassword;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // public void OnClickLogin()
    // {
    //     HttpRequester requester = new HttpRequester();
    //     requester.url = "http://3.34.133.115:8080/auth/login";
    //     requester.requestType = RequestType.POST;
    //
    //     requester.postData = JsonUtility.ToJson(data, true);
    //     print(requester.postData);
    //
    //     ///////////
    //     requester.onComplete = OnCilckDownload;
    //
    //     HttpManager.instance.SendRequest(requester);
    // }
    //
    // public void OnClickSignUp()
    // {
    //     HttpRequester requester = new HttpRequester();
    //     requester.url = "http://3.34.133.115:8080/auth/signup";
    //     requester.requestType = RequestType.POST;
    //     print("test");
    //
    //     requester.postData = JsonUtility.ToJson(data, true);
    //     print(requester.postData);
    //
    //     ///////////
    //
    //     HttpManager.instance.SendRequest(requester);
    // }
}
