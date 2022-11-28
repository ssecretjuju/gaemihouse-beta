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

    Animator anim;
    private PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        pv = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            for (int i = 0; i < keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    photonView.RPC("OnEmoticon", RpcTarget.All, i);
                }
            }

            //애니

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetBool("isHappy", true);
            }
            else
            {
                anim.SetBool("isHappy", false);

            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetBool("isSad", true);
            }
            else
            {
                anim.SetBool("isSad", false);

            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetBool("isAngry", true);
            }
            else
            {
                anim.SetBool("isAngry", false);

            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                anim.SetBool("isClap", true);
            }
            else
            {
                anim.SetBool("isClap", false);

            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                anim.SetBool("isVictory", true);
            }
            else
            {
                anim.SetBool("isVictory", false);

            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                anim.SetBool("isPray", true);
            }
            else
            {
                anim.SetBool("isPray", false);

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
