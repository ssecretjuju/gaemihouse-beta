using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    //public 
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
        //PUN의 맵 로딩 자동 동기화를 사용할 수 있고, 맵 로딩 초기화 시 발생할 수 있는 네트워크 문제를 피할 수 있습니다.

        //PhotonNetwork.automaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
