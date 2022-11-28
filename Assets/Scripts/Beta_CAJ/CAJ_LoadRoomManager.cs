using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

//룸 정보를 받아온다
//룸 정보(이름, 수익률)에 따라 방을 만든다

public class CAJ_LoadRoomManager : MonoBehaviour
{
    
    public void OnClickGetPost()
    {
        //서버에 방 목록 조회 요청 (shareholder-room, GET)

        //HttpRequester 를 생성
        HttpRequester requester = new HttpRequester();

        //shareholder-room , GET
        //requester.url = "http://3.34.133.115:8080/shareholder-room";
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetPost;
        //requester.onComplete(UnityWebRequest.downloadHandler)
        //응답을 받아서 출력

        //HttpManager 에게 요청
        HttpManager.instance.SendRequest(requester);
    }

    public void OnCompleteGetPost(DownloadHandler handler)
    {
        //PostData 에서 Json 형태를 풀어버린다
        RoomData roomData = JsonUtility.FromJson<RoomData>(handler.text);

        //타이틀 UI에 출력
        //내용 UI에 출력
        print("조회완료");
    }

    public void OnClickGetPostAll()
    {
        //서버에 게시물 조회 요청(/posts/1 , GET)
        //HttRequester를 생성
        HttpRequester requester = new HttpRequester();

        ///posts/1 , GET, 완료되었을 때 호출되는 함수
        //requester.url = "http://3.34.133.115:8080/shareholder-room";
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/shareholder-room";
        requester.requestType = RequestType.GET;
        requester.onComplete = OnCompleteGetPostAll;

        //HttpManager에게 요청
        HttpManager.instance.SendRequest(requester);
    }

    public void OnCompleteGetPostAll(DownloadHandler handler)
    {
        //배열 데이터를 키값에 넣는다.
        //string s = "{\"data\":" + handler.text + "}";
        string s = "{\"data\":" + handler.text + "}";
        //print(s);


        string a = handler.text;    
        //print("a : " + a);

        //List<PostData>
        RoomDataArray array = JsonUtility.FromJson<RoomDataArray>(s);
        for (int i = 0; i < array.data.Count; i++)
        {
            
            print(array.data[i].roomTitle + "\n" + array.data[i].roomRegistedNumber + "\n" + array.data[i].roomCode + array.data[i].roomYield + array.data[i].roomLimitedNumber);
            //print(array);
        }
        

        print("조회 완료");
    }

    // Start is called before the first frame update
    void Start()
    {
        //OnClickGetPostAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
