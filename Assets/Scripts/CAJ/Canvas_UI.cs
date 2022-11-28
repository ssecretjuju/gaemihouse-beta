using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_UI : MonoBehaviour
{
    // 닉네임
    public Text MemberNicName;

    // 코인
    public Text MemberCoinAmount;

    // Start is called before the first frame update
    void Start()
    {
        MemberNicName.text = LoginManager.Instance.playerData.memberNickname;
        MemberCoinAmount.text = CoinManager.Instance.coinInfo.coinAmount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
