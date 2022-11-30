using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;


// ������ ���� ����

[Serializable]
public class CoinInsertInfo
{
    public string memberId;
    public int coinAmount;
}

// �޴� ����

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
        //���࿡ instance�� null�̶��
        if (Instance == null)
        {
            //instance�� ���� �ְڴ�.
            Instance = this;
            //���� ��ȯ�� �Ǿ ���� �ı����� �ʰ� �ϰڴ�.
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
        print("���� ���� �� �Ϸ�!");
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
