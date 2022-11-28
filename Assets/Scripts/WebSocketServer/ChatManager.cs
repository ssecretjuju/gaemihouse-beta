using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using WebSocketSharp;
using Photon.Pun;
using System.Text;


public class ChatManager : MonoBehaviour
{
    //플레이어 닉네임
    string ChatNickname;
    //웹소켓
    private WebSocket ws;
    //InputChat
    public InputField inputChat;




    // Start is called before the first frame update
    void Start()
    {
        ChatNickname = LoginManager.Instance.playerData.memberNickname;
        ws = new WebSocket("ws://3.34.133.115:8001");
        
        //서버에 연결
        ws.Connect();

        //접속했을 때 (서버가 연결된 경우)
        ws.OnOpen += (res, e) => {
            Debug.Log($"{ws.ReadyState.ToString()} => Open이면 연결 성공");
        };

        //다른사람 메시지
        ws.OnMessage += (res, e) => {
            //Debug.Log($"{e.Data}가 옴.");
            Debug.Log($"{e.Data}");
            //Debug.Log(e.Data);
        };

        //접속종료할 때 보여주고 싶으면 (서버 닫힘)
        ws.OnClose += (res, e) =>
        {
            Debug.Log($"연결 종료");
        };

        //InputChat에서 엔터를 눌렀을 때 호출되는 함수
        //inputChat.onSubmit.AddListener(OnSubmit);
    }

    void OnSubmit(string s)
    {
        //1. 글을 쓰다가 엔터를 치면
        //2. ChatItem을 하나 만든다. (부모 : ScrollView - Content)
        //GameObject item = Instantiate(chatItemFactory, trContent);

        //3. text 컴포넌트 가져와서 inputField의 내용을 세팅
        //Text t = item.GetComponent<Text>();
        //t.text = inputChat.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
