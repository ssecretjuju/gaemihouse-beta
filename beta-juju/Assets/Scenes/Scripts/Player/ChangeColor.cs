using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

//Save 버튼 -> 커스텀인포를 서버에 보내서 그 멤버닉네임에 커스텀타입 값들을 저장한다.
//GO 버튼 -> 다음씬으로 이동한다
//플레이어 스크립트- 서버에서 커스텀인포를 겟해서 그 값에 맞게 파츠들 꺼지고 켜지게 함수작성 (Loadmodel)
//만약 로그인 시 이미 커스텀값들이 저장되어있는 아이디라면 로그인 시 바로 로비씬 전 영상씬으로 이동
//만약 처음 로그인(커스텀값ㄴ)이면 커스텀씬으로 이동

[Serializable]
public class PlayerCustomInfo
{
    public string colorMemberNickname;   
    public int faceType;
    public int bodyType;
    public int accType;
}

public class ChangeColor : MonoBehaviour
{
    public static ChangeColor instance;

    //플레이어 닉네임
    public Text UserNickname;


   public Toggle m_Toggle;

    //플레이어의 얼굴 정보
    public int FaceType;
    public int BodyType;
    public int AccType;

    public List<Toggle> toggleList;
    public List<Toggle> toggleList2;
    public List<Toggle> toggleList3;
    // 0= 검정, 1= 황금 ...




    void Start()
    {
        AntCustom.instance.faceType[0].SetActive(true);
        AntCustom.instance.bodyType[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //FACE
        toggleList[0].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.faceType[0].SetActive(true);
            AntCustom.instance.faceType[1].SetActive(false);
            AntCustom.instance.faceType[2].SetActive(false);
            AntCustom.instance.faceType[3].SetActive(false);
            FaceType = 0;
        });

        toggleList[1].onValueChanged.AddListener(delegate
        {

            AntCustom.instance.faceType[0].SetActive(false);
            AntCustom.instance.faceType[1].SetActive(true);
            AntCustom.instance.faceType[2].SetActive(false);
            AntCustom.instance.faceType[3].SetActive(false);
            FaceType = 1;
        });

        toggleList[2].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.faceType[0].SetActive(false);
            AntCustom.instance.faceType[1].SetActive(false);
            AntCustom.instance.faceType[2].SetActive(true);
            AntCustom.instance.faceType[3].SetActive(false);
            FaceType = 2;
        });

        toggleList[3].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.faceType[0].SetActive(false);
            AntCustom.instance.faceType[1].SetActive(false);
            AntCustom.instance.faceType[2].SetActive(false);
            AntCustom.instance.faceType[3].SetActive(true);
            FaceType = 3;
        });
        //BODY
        toggleList2[0].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.bodyType[0].SetActive(true);
            AntCustom.instance.bodyType[1].SetActive(false);
            AntCustom.instance.bodyType[2].SetActive(false);
            AntCustom.instance.bodyType[3].SetActive(false);
            BodyType = 0;
        });

        toggleList2[1].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.bodyType[0].SetActive(false);
            AntCustom.instance.bodyType[1].SetActive(true);
            AntCustom.instance.bodyType[2].SetActive(false);
            AntCustom.instance.bodyType[3].SetActive(false);
            BodyType = 1;
        });

        toggleList2[2].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.bodyType[0].SetActive(false);
            AntCustom.instance.bodyType[1].SetActive(false);
            AntCustom.instance.bodyType[2].SetActive(true);
            AntCustom.instance.bodyType[3].SetActive(false);
            BodyType = 2;
        });

        toggleList2[3].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.bodyType[0].SetActive(false);
            AntCustom.instance.bodyType[1].SetActive(false);
            AntCustom.instance.bodyType[2].SetActive(false);
            AntCustom.instance.bodyType[3].SetActive(true);
            BodyType = 3;

        });
        //ACC
        toggleList3[0].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.accType[0].SetActive(false);
            AntCustom.instance.accType[1].SetActive(false);
            AntCustom.instance.accType[2].SetActive(false);
            AntCustom.instance.accType[3].SetActive(false);
            AntCustom.instance.accType[4].SetActive(false);
            AccType = 0;
        });

        toggleList3[1].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.accType[0].SetActive(false);
            AntCustom.instance.accType[1].SetActive(true);
            AntCustom.instance.accType[2].SetActive(false);
            AntCustom.instance.accType[3].SetActive(false);
            AntCustom.instance.accType[4].SetActive(false);
            AccType = 1;
        });

        toggleList3[2].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.accType[0].SetActive(false);
            AntCustom.instance.accType[1].SetActive(false);
            AntCustom.instance.accType[2].SetActive(true);
            AntCustom.instance.accType[3].SetActive(false);
            AntCustom.instance.accType[4].SetActive(false);
            AccType = 2;
        });

        toggleList3[3].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.accType[0].SetActive(false);
            AntCustom.instance.accType[1].SetActive(false);
            AntCustom.instance.accType[2].SetActive(false);
            AntCustom.instance.accType[3].SetActive(true);
            AntCustom.instance.accType[4].SetActive(false);
            AccType = 3;
        });

        toggleList3[4].onValueChanged.AddListener(delegate
        {
            AntCustom.instance.accType[0].SetActive(false);
            AntCustom.instance.accType[1].SetActive(false);
            AntCustom.instance.accType[2].SetActive(false);
            AntCustom.instance.accType[3].SetActive(false);
            AntCustom.instance.accType[4].SetActive(true);
            AccType = 4;
        });

    }

    ////public void OnClickTypeChange()
    ////{
    ////    for (int i = 0; i < faceType.Length; i++)
    ////    {
    ////        faceType[i].SetActive(false);
    ////    }
    ////    faceType[FaceType].SetActive(true);

    ////    for (int i = 0; i < bodyType.Length; i++)
    ////    {
    ////        bodyType[i].SetActive(false);
    ////    }
    ////    bodyType[BodyType].SetActive(true);

    //}

    public void OnClickSaveCustomData()
    {
        PlayerCustomInfo customdata = new PlayerCustomInfo();
        customdata.faceType = FaceType;
        customdata.bodyType = BodyType;
        customdata.accType = AccType;
        customdata.colorMemberNickname = LoginManager.Instance.playerData.memberNickname;
                                                
        //playerdata.memberAvatarImage = File.ReadAllBytes(Application.persistentDataPath + "/Resources/AvatarImage/avatar0.png");

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/avatar";
        requester.requestType = RequestType.POST;

        requester.postData = JsonUtility.ToJson(customdata, true);
        print(requester.postData);

        HttpManager.instance.SendRequest(requester);

    }

    public void Gobtn()
    {
        SceneManager.LoadScene("[Beta]CAJ_LobbyScene");
    }
}