using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;



public class KeywordManager : MonoBehaviour
{
    public GameObject keywordWindow;
    public Text keywordText;
    // Start is called before the first frame update
    void Start()
    {
        keywordWindow.SetActive(false);
    }
    public void OnKeyword()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            keywordWindow.SetActive(true);
            //keywordText.text = ChatKeyword.Instance.keydata.keywordContent1;
            print(keywordText.text);
        }
    }
}
