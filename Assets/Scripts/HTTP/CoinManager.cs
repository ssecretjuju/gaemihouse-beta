using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using SimpleJSON;



//서버에서 가져올 정보들
[Serializable]
public class CoinInfo
{
    public int memberCode;
    public int coinAmount;
}

[Serializable]
public class CoinResponseData
{
    public int status;
    public string message;
    public CoinInfo data;
}

public class CoinPostInfo
{
    public int memberCode;
    public int coinAmount;
}

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        OnGetCoin();
        ClickPostCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnGetCoin()
    {
        CoinInfo data = new CoinInfo();

        HttpRequester requester = new HttpRequester();
        //requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/coin";
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/coin/select";
        print(requester.url);

        requester.requestType = RequestType.GET;
        
        requester.onComplete = OnSaveCoin;
        HttpManager.instance.SendRequest(requester);
    }

    //public void s(DownloadHandler hangler)
    //{
    //    Debug.Log("??");
    //}

    //public int coinInfo;
    ////public CoinRe

    public CoinInfo coinInfo;
    public PlayerData coinData;

    public void OnSaveCoin(DownloadHandler handler)
    {
        string coindata = System.Text.Encoding.Default.GetString(handler.data);
        print("coin : " + coindata);

        CoinResponseData coinResponseData = JsonUtility.FromJson<CoinResponseData>(coindata);

        coinInfo = coinResponseData.data;
    }

    //정착금 받기 : 1000코인 주기 
    public void ClickPostCoin()
    {
        CoinPostInfo data = new CoinPostInfo();
        data.memberCode = LoginManager.Instance.playerData.memberCode;
        print("멤버코드 : " + data.memberCode);
        data.coinAmount = 1000;

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/coin/update";
        requester.requestType = RequestType.POST;
        print("Post test");
        print(coinData);

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);

        HttpManager.instance.SendRequest(requester);
        print("Post 완료!");
    }

}
