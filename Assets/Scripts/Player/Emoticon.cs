using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Emoticon : MonoBehaviourPunCallbacks
{
    //이모티콘

    public Sprite[] imoticon;
    public GameObject imoticonPrefab;
    private KeyCode[] keyCodes = {
KeyCode.Alpha1,
KeyCode.Alpha2,
KeyCode.Alpha3,
KeyCode.Alpha4,
KeyCode.Alpha5,
KeyCode.Alpha6,
KeyCode.Alpha7,
KeyCode.Alpha8,
KeyCode.Alpha9,
};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                photonView.RPC("OnEmoticon", RpcTarget.All, i);
            }
        }
            

    }

    [PunRPC]
    public void OnEmoticon(int i)
    {
           
        GameObject imo = gameObject.transform.GetChild(2).gameObject;
        EmoDestory_LYJ emo = imo.GetComponent<EmoDestory_LYJ>();
        emo.emoOn = true;
        emo.checkTime = 0;
        SpriteRenderer spriteRenderer = imo.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = imoticon[i];
        imo.transform.parent = gameObject.transform;

    }
}
