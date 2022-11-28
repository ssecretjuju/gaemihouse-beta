using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;



public class SubboardClick : MonoBehaviour
{
    public static SubboardClick Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Text comfrimTitle;
    public Text comfrimContent;
    public Text likey;

    public string subTitle;
    public string subContent;
    public string subLikey;

        //GameObject subboard;
    GameObject ConfirmWindow;
    GameObject SubboardParent;
    GameObject g2;

    void Start()
    {
        ConfirmWindow = GameObject.Find("SubBoardCanvas").transform.GetChild(0).gameObject;
        SubboardParent = GameObject.Find("SubBoardCanvas").transform.GetChild(1).gameObject;
        comfrimTitle = ConfirmWindow.transform.GetChild(0).GetComponent<Text>();
        comfrimContent = ConfirmWindow.transform.GetChild(1).GetComponent<Text>();
        likey = ConfirmWindow.transform.GetChild(3).GetComponent<Text>();

        //comfrimTitle = g2.transform.GetChild(0).GetComponent<InputField>();
        //comfrimTitle = g2.transform.GetChild(1).GetComponent<Text>();


    }

    public void OnClickSubboard()
    {
        //글을 누르면 제목,닉네임,날짜,내용이 표시되어있는 창이 뜬다.
        SubboardParent.SetActive(false);
        ConfirmWindow.SetActive(true);

        comfrimTitle.text = subTitle;
        comfrimContent.text = subContent;
        likey.text = subLikey;

        //OnGetConfirmWindow();

    }


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void Set(string s1, string s2, string s3, GameObject g1)
    //{
    //    subTitle = s1;
    //    subContent = s2;
    //    subLikey = s3;
    //    g2 = g1;

    //}
    //public void OnGetConfirmWindow()
    //{
    //    comfrimTitle.text = subTitle;
    //    comfrimContent.text = subContent;
    //    likey.text = subLikey;

    //}


}
