using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Networking;
using System;

//다른 플레이어를 클릭하면 팝업 윈도우가 활성화된다 -> DoublcClick 스크립트에서 함
//팝업 윈도우에 담을 플레이어 정보: 주식경력, 평균수익률
//플레이어 자신을 누르면 기능하지 않는다.

public class PlayerInfoWindow : MonoBehaviour
{
    public GameObject DoubleClick;
    public GameObject playerInfoWindow;
    public GameObject ChatCanvas;
    public Text nickName;
    public Text carrerText;
    public Text yieldText;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayerWindow()
    {
        //팝업창이 활성화
        playerInfoWindow.SetActive(true);
        print("켜졋띠");
        print("data :" + LoginManager.Instance.playerData.yield);
        
        carrerText.text = LoginManager.Instance.playerData.stockCareer;

        float yield = float.Parse(LoginManager.Instance.playerData.yield);
        print(yield);
        //yield = Math.Round(yield, 3);
        yieldText.text = yield + "%";
        nickName.text = LoginManager.Instance.playerData.memberNickname;

        //회원정보에 저장되어있는 경력, 수익률 텍스트 동기화
        //LoginManager.Instance.playerData.yield = yieldText.text;





    }
    public void OnEscBtn()
    {
        playerInfoWindow.SetActive(false);
    }

    public void OnChatBtn()
    {
        ChatCanvas.SetActive(true);
    }
}
