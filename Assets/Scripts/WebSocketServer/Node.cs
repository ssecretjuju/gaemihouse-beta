//아래 세 개는 그냥 기본이라고 생각하면 좋다.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using WebSocketSharp;

using System.Text;



public class Node : MonoBehaviour
{

    public Text chatLog;
    public InputField input;
    string chatters;
    ScrollRect scroll_rect;
    string temp;
    public WebSocket ws;//소켓 선언
    string mbti_name;


    [Header("IP입력_ PORT : 3333")]
    public string IP = "ws://3.34.133.115:8001";


    void Start()
    {
        scroll_rect = GameObject.FindObjectOfType<ScrollRect>();

        ws = new WebSocket(IP);// 127.0.0.1은 본인의 아이피 주소이다. 3333포트로 연결한다는 의미이다.
        ws.OnMessage += ws_OnMessage; //서버에서 유니티 쪽으로 메세지가 올 경우 실행할 함수를 등록한다.
        ws.OnOpen += ws_OnOpen;//서버가 연결된 경우 실행할 함수를 등록한다
        ws.OnClose += ws_OnClose;//서버가 닫힌 경우 실행할 함수를 등록한다.
        ws.Connect();//서버에 연결한다.
        //ws.Send("Hello I'm Json");//서버에게 "hello"라는 메세지를 보낸다.


        // 시작할 때, 저장된 값을 불러와서
        //mbti_name = PlayerPrefs.GetString("MBTI", "MBTI");

        // 받은 키 벨류로 name에 넣는다
        //name.text = mbti_name;

    }
    void ws_OnMessage(object sender, MessageEventArgs e)
    {
        //받은 메세지를 디버그 콘솔에 출력한다.
        Debug.Log(e.Data);

        print("1_");
        print($"EventMSG: {e.RawData}");
        //챗 로그에 나오게 하자
        string ttempp = Encoding.UTF8.GetString(e.RawData);

        temp = string.Format("\r\n{0}", ttempp);
        //StartCoroutine(Test());
        chatLog.text += temp;
        //print(temp);


    }
    void ws_OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log("open"); //디버그 콘솔에 "open"이라고 찍는다.
    }
    void ws_OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("close"); //디버그 콘솔에 "close"이라고 찍는다.
    }

    private void Update()
    {
        SendMsg();
        Test();
    }

    void OnClickButton()
    {
        // text 에 나오게 하고싶다.
        chatLog.text += input.text + "\n";

        // 그리고 초기화
        input.text = "";
    }

    void SendMsg()
    {
        // 버튼을 누르면
        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (input.text == null)
            {
                return;
            }

            input.ActivateInputField();

            var message = input.text;

            // Message 를 보낼 때
            // 이름이랑 같이 보낸다
            //ws.Send(string.Format("{0} : {1}","NickName", message ) );
            //ws.Send(string.Format("{0} : {1}","NickName", message ) );
            ws.Send("%" + message);

            print("1");

            // text 에 나오게 하고싶다.
            //chatLog.text += input.text + "\n";

            print("2");

            // 그리고 초기화
            input.text = "";

            print("3");


            // 스크롤 제어
            scroll_rect.verticalNormalizedPosition = 0.0f;

        }
    }

    public void Test()
    {

        chatLog.enabled = false;
        chatLog.enabled = true;
        chatLog.text = chatLog.text;
        //chatLog.text += msg;
        // 스크롤 항상 아래로 고정
        scroll_rect.verticalNormalizedPosition = 0.0f;


    }

    // 버튼을 누르면 인풋 필드에 있는 글을 Send 함수에 넣고 싶다,.
    // Send 함수를 눌렀을 때 그 Text 를 Scroll View 에 띄우고 싶다.



    // 보낼 때는 한 줄로,
    // 받을 때 누적
}