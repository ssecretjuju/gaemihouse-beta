using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using UnityEngine.Networking;

//inputfield �� �Էµ� text�� �����ϱ�
//����� text���� ����� DB�� ������
//DB�� �ִ� ���� ����Ƽ�� �Էµ� text���� ��ġ�ϸ� �׿� ��ġ�ϴ� �̹����� ���� -> �������� ���� �Է¹�ư
//�̹��� ���¹� 

[Serializable]
public class SearchInfo
{
    public string searchText;
}


[Serializable]
public class ImageUrl
{
    public string url1;
    public string url2;
    
}

public class PredictBoardManager : MonoBehaviour
{
    public GameObject predictCanvas;

    private void Update()
    {

    }

    public void OnCancelBtn()
    {
        predictCanvas.SetActive(false);
    }


    public InputField searchText;

    //��ư�� ������ �� �˻��� �ؽ�Ʈ�� �����ϰ� �ʹ�.
    public void OnClickSearch()
    {
        SearchInfo data = new SearchInfo();
        data.searchText = searchText.text;

        HttpRequester requester = new HttpRequester();
        requester.url = "http://secretjujucicd-api-env.eba-iuvr5h2k.ap-northeast-2.elasticbeanstalk.com/stock-prediction/" + searchText.text;
        requester.requestType = RequestType.POST;
        print("test");

        requester.postData = JsonUtility.ToJson(data, true);
        print(requester.postData);


        ///////////
        requester.onComplete = OnCompleteSearch;
        HttpManager.instance.SendRequest(requester);

    }

    public RawImage img;
    public RawImage img2;
    string ss;
    string ss2;

    //�˻����� �� �޴� �̹��� �ּҰ��� ����
    public void OnCompleteSearch(DownloadHandler handler)
    {
        
        ImageUrl url = JsonUtility.FromJson<ImageUrl>(handler.text);
        print(url.url1);

        ss = url.url1;
        ss2 = url.url2;

        print("2�� ���˿� �ּ� :" + url.url2);


        StartCoroutine(GetTexture());

    }

    //����� �̹��� �ּҸ� �ؽ�óȭ�ؼ� ����.
    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(ss);
        UnityWebRequest www2 = UnityWebRequestTexture.GetTexture(ss2);

        yield return www.SendWebRequest();
        yield return www2.SendWebRequest();


        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            img.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            img2.texture = ((DownloadHandlerTexture)www2.downloadHandler).texture;
        }
    }
}



