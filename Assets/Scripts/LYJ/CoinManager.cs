using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;


// 가져올 코인 정보

[Serializable]
public class CoinInsertInfo
{
    public string memberId;
    public int coinAmount;
}

// 받는 정보

[Serializable]
public class CoinInfo
{
    public int status;
    public string message;
    public CoinInsertInfo data;
}
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
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
    }
    public string coinMemberId;

    public void OnCoinBtn()
    {
       
        coinMemberId = LoginManager.Instance.playerData.memberId;
        print(coinMemberId);

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/coin/select/" + coinMemberId;
        print(requester.url);
        requester.requestType = RequestType.GET;

        requester.onComplete = OnLoadCoin;

        HttpManager.instance.SendRequest(requester);
        print("코인 정보 겟 완료!");
    }

    //public List<int> coinInfo;
    public CoinInsertInfo coin;
    public int coinInfo;

    public void OnLoadCoin(DownloadHandler handler)
    {

        string data = System.Text.Encoding.Default.GetString(handler.data);

        print("data : " + data);
        CoinInfo coinData = JsonUtility.FromJson<CoinInfo>(data);

        coin = coinData.data;

        print(coin.coinAmount);

        coinInfo = coin.coinAmount;
       
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
