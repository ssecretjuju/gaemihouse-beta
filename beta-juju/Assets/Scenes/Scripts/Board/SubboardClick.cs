using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubboardClick : MonoBehaviour
{

    GameObject subboard;
    GameObject ConfirmWindow;

    void Start()
    {
        ConfirmWindow = GameObject.Find("SubBoardCanvas").transform.GetChild(0).gameObject;
       
    }

    public void OnClickSubboard()
    {
        //글을 누르면 제목,닉네임,날짜,내용이 표시되어있는 창이 뜬다.
        ConfirmWindow.SetActive(true);
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
