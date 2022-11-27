using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

[Serializable]
public class WorldInfo
{
    //위치, 크기, 각도
    public Vector3 position;
    public Vector3 scale;
    public Vector3 angle;
}


public class LobbySetting : MonoBehaviour
{
    private GameObject prefab_obj;
    //public ObjectInfo objInfo = new ObjectInfo();
    
    // Start is called before the first frame update
    void Start()
    {
        // prefab_obj = Resources.Load("LobbyScene_Prefab") as GameObject;
        // GameObject obj = MonoBehaviour.
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        // ate(prefab_obj);
        // obj.name = "clone";
        //
        // Vector3 pos = new Vector3(5, 2, 3);
        // obj.transform.position = pos;
        
        // objInfo.position = obj.transform.position;
        // objInfo.scale = obj.transform.localScale;
        // objInfo.angle = obj.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //버튼을 눌렀을때 월드의 정보를 저장하고 싶다.
    public void WorldSaveBtn()
    {
        prefab_obj = Resources.Load("LobbyScene_Prefab") as GameObject;
        GameObject obj = MonoBehaviour.Instantiate(prefab_obj);
        obj.name = "clone";

        Vector3 pos = new Vector3(5, 2, 3);
        obj.transform.position = pos;
        
        WorldInfo worldPrefab = new WorldInfo();
        worldPrefab.position = obj.transform.position;
        worldPrefab.scale = obj.transform.localScale;
        worldPrefab.angle = obj.transform.eulerAngles;

        HttpRequester requester = new HttpRequester();
        requester.url = "http://13.125.89.145:8080/world/update";
        requester.requestType = RequestType.POST;
        print("PostTest");

        HttpManager.instance.SendRequest(requester);
    }
}

