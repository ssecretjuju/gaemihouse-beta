using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]

public class BoardContent
{
    //작성자 닉넴
    public string nickName;
    //작성글 제목
    public string title;
    //작성글 내용
    public string content;
}

[System.Serializable]

public class ArrayData
{
    public List<BoardContent> data;

}

[System.Serializable]
public class CardLists
{
    public string cardName;
    public string desc;
}

[System.Serializable]

public class ArrayData2
{
    public List<CardLists> data2;
}

public class BoardNetwork : MonoBehaviour
{

    public GameObject btn_add;
    public GameObject descDisplay;
    public GameObject descDisplay_cancelBtn;
    public GameObject descDisplay_OkBtn;
    public InputField input_Title;
    public InputField input_memo;


    public BoardContent contentInfo = new BoardContent();

    public List<CardLists> dataList2 = new List<CardLists>();


    //ok버튼이랑 task버튼이랑 다른점?

    public void TaskBtn()
    {
        string path = UnityEngine.Application.dataPath + "/DataContent/dataContent.txt";
        //데이터를 불러온다.
        string jsonData2 = File.ReadAllText(path);
        print(jsonData2);

        //jsonData -> info
        ArrayData2 arrayData2 = JsonUtility.FromJson<ArrayData2>(jsonData2);

        //데이터 생성
        for (int i = 0; i <arrayData2.data2.Count; i++)
        {
            CardLists info = arrayData2.data2[i];
            dataList2.Add(info);
            print(info.cardName);
            print(info.desc);
        }

    }

    public void OnCardAddBtn()
    {
        descDisplay.SetActive(true);

        if(input_Title.text != null && input_memo.text != null)
        {
            input_Title.text = "";
            input_memo.text = "";
        }
    }

    //1.저장(ok)버튼을 누르면 정보를 저장한다.
    //2.글쓰기(cancel)버튼을 누르면 정보를 불러와서 json으로 만들고 json으로 불러온 후에 창이 꺼진다.


    public void OnOKBtn()
    {
        //new= 생성자, 변수를 생성해줌
        CardLists info = new CardLists();
        info.cardName = input_Title.text;
        info.desc = input_memo.text;

        //정보를 담아줌
        dataList2.Add(info);

        ArrayData2 arrayData2 = new ArrayData2();
        arrayData2.data2 = dataList2;
        string jsonData2 = JsonUtility.ToJson(arrayData2, true);
        print(jsonData2);

        //저장경로 가져오기
        string path = UnityEngine.Application.dataPath + "/DataContent";
        {
            Directory.CreateDirectory(path);
        }
        //Text파일로 저장
        File.WriteAllText(path + "/dataContent.txt", jsonData2);
    }

    public void OnDescCancelBtn()
    {
        //파일 경로
        string path = UnityEngine.Application.dataPath + "/DataContent/dataContent.txt";

        //데이터를 불러온다.
        string jsonData2 = File.ReadAllText(path);
        print(jsonData2);

        //jsonData -> info
        ArrayData2 arrayData2 = JsonUtility.FromJson<ArrayData2>(jsonData2);

        //데이터 생성
        for(int i = 0; i < arrayData2.data2.Count; i++)
        {
            CardLists info = arrayData2.data2[i];
            print(info.cardName);
            print(info.desc);
            print(arrayData2.data2.Count);
        }

        //descDisplay.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
