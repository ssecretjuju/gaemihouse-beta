using System;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using Photon.Pun;
using UnityEngine.EventSystems;

using System.Text;
using Unity.VisualScripting;

public class SocketIoClient : MonoBehaviourPun
{
    //ChatItme 공장
    public GameObject chatItemFactory;
    //InputChat 
    public InputField inputChat;
    //ScrollView의 Content transform
    public RectTransform trContent;
    
    public string ChatNickname;





    //public RectTransform rtScrollView;
    float prevContentH;
    
    private WebSocket ws;
    
    void Start()
    {
        ChatNickname = LoginManager.Instance.playerData.memberNickname;
        //print("instance.nickname : " + ChatNickname);

        ws = new WebSocket("ws://3.34.133.115:8001");
        //서버에 연결! 
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
        inputChat.onSubmit.AddListener(OnSubmit);
    }

    void OnSubmit(string s)
    {
        //1. 글을 쓰다가 엔터를 치면
        //2. ChatItem을 하나 만든다. (부모 : ScrollView - Content)
        GameObject item = Instantiate(chatItemFactory, trContent);
        
        //3. text 컴포넌트 가져와서 inputField의 내용을 세팅
        Text t = item.GetComponent<Text>();
        t.text = inputChat.text;
    }


    void Update()
    {
        if (ws == null)
        {
            return;
        }
    
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Console.Write("채팅 입력 > ");

            print("inputChat : " + inputChat);
            print(inputChat.text);

            var message = inputChat.text;
            // if (message != null)
            // {
            //     return;
            // }
            // if(message == "0") {
            //     return;
            // }
    
            //send : 입력 보내는 것 
            
           ws.Send( ChatNickname + "%" + message);
           //print("message : " + message);
            //ws.Send(message);

            inputChat.text = "";
            
            inputChat.ActivateInputField();
        }
        
        [PunRPC]
        void RpcAddChat(string message)
        {
            //이전 content의 H값을 저장하자
            prevContentH = trContent.sizeDelta.y;

            //2.ChatItem을 하나 만든다. 
            //(부모를 ScrollView - Content)
            GameObject item = Instantiate(chatItemFactory, trContent);

            //3.text 컴포넌트 가져와서 inputField의
            //내용을 셋팅
            // ChatItem chatItem = item.GetComponent<ChatItem>();
            // chatItem.SetText(chat);
            
            CAJ_ChatItem chatItem = item.GetComponent<CAJ_ChatItem>();
            chatItem.SetText(message);

            //4. 이전에 바닥에 닿아있었다면
            //StartCoroutine(AutoScrollBottom());
        }
        
        // IEnumerator AutoScrollBottom()
        // {
        //     yield return null;
        //     //스크롤뷰 H보다 Content H값이 클 때만(스크롤이 가능한 상태라면)
        //     if(trContent.sizeDelta.y > rtScrollView.sizeDelta.y)
        //     {            
        //         //(content y  >= 변경되기전 content H - 스크롤뷰 H)
        //         if (trContent.anchoredPosition.y >= prevContentH - rtScrollView.sizeDelta.y)
        //         {
        //             //5. 추가된 높이만큼 content y값을 변경하겠다.
        //             trContent.anchoredPosition = new Vector2(0, trContent.sizeDelta.y - rtScrollView.sizeDelta.y);
        //         }
        //     }
        // }
        
        //inputChat에서 엔터를 눌렀을 때 호출되는 함수
        // void OnSubmit(string s)
        // {
        //     // string s = message;
        //     // string chatText = PhotonNetwork.NickName + " : " + s;
        //     //
        //     if (ws == null)
        //     {
        //         return;
        //     }
        //     
        //     if (Input.GetKeyDown(KeyCode.Return))
        //     {
        //         Console.Write("채팅 입력 > ");
        //         //var message = Console.ReadLine();
        //         var message = inputChat;
        //         if(message == "0") {
        //             return;
        //         }
        //
        //         //send : 입력 보내는 것 
        //         //ws.Send($"닉네임 : {message}");
        //     }
        //     
        //     //ws.Send($"닉네임 : {message}");
        //     ws.Send(PhotonNetwork.NickName + " : " + message);
        //
        //     inputChat.text = "";
        //     inputChat.ActivateInputField();

        //이건 일단 다음! 

        // string chatText = PhotonNetwork.NickName + " : " + s;
        // //<color=#FF0000>닉네임</color>
        // // string chatText = "<color=#" + ColorUtility.ToHtmlStringRGB(nickColor) + ">" +
        // //                   PhotonNetwork.NickName + "</color>" + " : " + s;
        //
        // //1.글을 쓰다가 엔터를 치면
        // photonView.RPC("RpcAddChat", RpcTarget.All, chatText);
        //
        // //4. inputChat의 내용을 초기화
        // inputChat.text = "";
        //
        // //5. inputChat이 선택되도록 한다.
        // inputChat.ActivateInputField();

    }
    
    
}