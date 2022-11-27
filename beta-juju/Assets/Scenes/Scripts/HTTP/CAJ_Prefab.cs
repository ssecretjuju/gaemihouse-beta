using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CAJ_Prefab : MonoBehaviour
{
    private GameObject prefab_obj;

    public ObjectInfo1 objInfo = new ObjectInfo1();
    
    // Start is called before the first frame update
    void Start()
    {
        prefab_obj = Resources.Load("LobbyScene_Prefab") as GameObject;
        GameObject obj = MonoBehaviour.Instantiate(prefab_obj);
        obj.name = "clone";

        Vector3 pos = new Vector3(5, 2, 3);
        obj.transform.position = pos;

        objInfo.position = obj.transform.position;
        objInfo.scale = obj.transform.localScale;
        objInfo.angle = obj.transform.eulerAngles;
    }

    public void OnClickSave()
    {
        string jsonData = JsonUtility.ToJson(objInfo, true);
        print(jsonData);
        
        print(Application.dataPath);
        print(Application.persistentDataPath);
        
        //저장 경로 가져오기
        string path = Application.dataPath + "/Data";
        
        //저장 경로가 false(존재x)면 만들기
        if (Directory.Exists(path) == false)
        {
            Directory.CreateDirectory(path);
        }
        
        //Text 파일로 저장
        File.WriteAllText(path+ "/data.txt", jsonData);
    }

    public void OnClickLoad()
    {
        //파일 경로
        string path = Application.dataPath + "/Data/data.txt";
        //데이터를 불러온다.
        string jsonData = File.ReadAllText(path);
        print(jsonData);
        
        //jsonData -> ObjectInfo
        ObjectInfo1 info = JsonUtility.FromJson<ObjectInfo1>(jsonData);
        //오브젝트 생성
        CreateObject(info);
    }

    void CreateObject(ObjectInfo1 info)
    {
        //GameObject cloneobj = GameObject.Instantiate("LobbyScene_Prefab");
        prefab_obj = Resources.Load("LobbyScene_Prefab") as GameObject;
        GameObject cloneobj = MonoBehaviour.Instantiate(prefab_obj);

        cloneobj.transform.position = info.position;
        cloneobj.transform.localScale = info.scale;
        cloneobj.transform.eulerAngles = info.angle;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class ObjectInfo1
{
    //위치, 크기, 각도를 담는 클래스 틀
    //public int type;
    public Vector3 position;
    public Vector3 scale;
    public Vector3 angle;
}
