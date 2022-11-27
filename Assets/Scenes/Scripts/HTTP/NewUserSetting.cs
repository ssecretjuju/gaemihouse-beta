// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Networking;
// using UnityEngine.UI;
//
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
//
// public class LoginInfo
// {
//     public string id;
//     public string password;
// }
//
// //토큰 ! 
// [Serializable]
// public class PostTokenData
// {
//     public string accessToken;
// }
//
//
//
// public class NewUserSetting : MonoBehaviour
// {
//     public InputField id;
//     public InputField password;
//     public InputField childName;
//     public InputField childBirthday;
//     public Dropdown childGender;
//
//     public InputField Logid;
//     public InputField Logpassword;
//
//     
//
//     //��ư�� �������� ������ ������ �����ϰ� �ʹ�.
//
//     void Start()
//     {
//         
//     }
//
//     void Update()
//     {
//         
//     }
//
//     //회원가입
//     public void OnClickSave()
//     {
//         UserInfo data = new UserInfo();
//         data.id = id.text;
//         data.password = password.text;
//         data.childName = childName.text;
//         data.childBirthday = childBirthday.text;
//         data.childGender = childGender.options[childGender.value].text;
//
//         HttpRequester requester = new HttpRequester();
//         requester.url = "http://192.168.1.77:8801/member";
//         requester.requestType = RequestType.POST;
//         print("test");
//
//         requester.postData = JsonUtility.ToJson(data, true);
//         print(requester.postData);
//
//         ///////////
//
//         HttpManager.instance.SendRequest(requester);
//         
//     }
//
//
//     //로그인
//     public void OnClickLogin()
//     {
//         LoginInfo data = new LoginInfo();
//         data.id = Logid.text;
//         data.password = Logpassword.text;
//      
//
//         HttpRequester requester = new HttpRequester();
//         requester.url = "http://192.168.1.77:8801/login";
//         requester.requestType = RequestType.POST;
//
//         requester.postData = JsonUtility.ToJson(data, true);
//         print(requester.postData);
//
//         ///////////
//         requester.onComplete = OnCilckDownload;
//
//         HttpManager.instance.SendRequest(requester);
//         
//     }
//
//     //토큰 (정보 암호화된 -> 요청보낼 때 같이보내줘야된다~)
//     public void OnCilckDownload(DownloadHandler handler)
//     {
//         //�迭 �����͸� Ű���� �ִ´�.
//         //string s = "{\"accessToken\":" + handler.text + "}";
//
//         //List<PostData>
//         PostTokenData postTokenData = JsonUtility.FromJson<PostTokenData>(handler.text);
//
//         print(postTokenData.accessToken);
//
//         PlayerPrefs.SetString("token", postTokenData.accessToken);
//      
//         print("��ȸ �Ϸ�");
//     }
//     ///
//
// }
