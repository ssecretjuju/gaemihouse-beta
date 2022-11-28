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
    //�÷��̾� �г���
    string ChatNickname;
    //������
    private WebSocket ws;
    //InputChat
    public InputField inputChat;




    // Start is called before the first frame update
    void Start()
    {
        ChatNickname = LoginManager.Instance.playerData.memberNickname;
        ws = new WebSocket("ws://3.34.133.115:8001");
        
        //������ ����
        ws.Connect();

        //�������� �� (������ ����� ���)
        ws.OnOpen += (res, e) => {
            Debug.Log($"{ws.ReadyState.ToString()} => Open�̸� ���� ����");
        };

        //�ٸ���� �޽���
        ws.OnMessage += (res, e) => {
            //Debug.Log($"{e.Data}�� ��.");
            Debug.Log($"{e.Data}");
            //Debug.Log(e.Data);
        };

        //���������� �� �����ְ� ������ (���� ����)
        ws.OnClose += (res, e) =>
        {
            Debug.Log($"���� ����");
        };

        //InputChat���� ���͸� ������ �� ȣ��Ǵ� �Լ�
        //inputChat.onSubmit.AddListener(OnSubmit);
    }

    void OnSubmit(string s)
    {
        //1. ���� ���ٰ� ���͸� ġ��
        //2. ChatItem�� �ϳ� �����. (�θ� : ScrollView - Content)
        //GameObject item = Instantiate(chatItemFactory, trContent);

        //3. text ������Ʈ �����ͼ� inputField�� ������ ����
        //Text t = item.GetComponent<Text>();
        //t.text = inputChat.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
