using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;


//회원가입창에 입력되어 json으로 저장하여 DB에 전송할 정보들

//public class CoinInfo
//{
//    public int memberCode;
//    public int coinAmount;
//}


[Serializable]
public class SignInfo
{
    public string memberId;
    public string memberPassword;
    public string memberName;
    public string memberNickname;
    public string stockCareer;
    public string stockFirm;
    public string termsAgreementYn;
    public string accountNum;
    public string appKey;
    public string appSecret;
}
public class SignupManager : MonoBehaviour
{
    public InputField memberId;
    public InputField memberPassword;
    public InputField memberName;
    public InputField memberNickname;
    public InputField stockCareer;
    public InputField stockFirm;
    public InputField termsAgreementYn;
    public InputField accountNum;
    public InputField appKey;
    public InputField appSecret;


    //signup 버튼을 누르면 정보수집 동의 창 UI가 뜬다
    public GameObject agreeCanvas;
    public GameObject signUpCanvas;
       
    public void OnClickSignBtn()
    {
        Debug.Log("동의창");
        agreeCanvas.SetActive(true);
    }

    //동의 버튼을 누르면 회원가입 창 UI가 뜬다.

    public void OnClickAgreeBtn()
    {
        agreeCanvas.SetActive(false);
        signUpCanvas.SetActive(true);
    }

    public void OnClickJoinBtn()
    {
        SignInfo data = new SignInfo();
        data.memberId = memberId.text;
        data.memberPassword = memberPassword.text;
        data.memberName = memberName.text;
        data.memberNickname = memberNickname.text;
        data.stockCareer = stockCareer.text;
        data.stockFirm = stockFirm.text;
        data.termsAgreementYn = termsAgreementYn.text;
        data.accountNum = accountNum.text;
        data.appKey = appKey.text;
        data.appSecret = appSecret.text;



        HttpRequester requester = new HttpRequester();
        //requester.url = "http://3.34.133.115:8080/auth/signup";
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/signup";
        requester.requestType = RequestType.POST;
        print("test");

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);

        HttpManager.instance.SendRequest(requester);

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
