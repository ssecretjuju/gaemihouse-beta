using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    public Text NickName;
    public Text CoinAmount;

    // Start is called before the first frame update
    void Start()
    {
        NickName.text = LoginManager.Instance.playerData.memberNickname;
        CoinAmount.text = CoinManager.Instance.coinInfo.coinAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
