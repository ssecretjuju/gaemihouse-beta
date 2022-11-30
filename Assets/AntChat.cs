using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class AntChat : MonoBehaviourPun
{
    public InputField inputfield;

    public GameObject bubble;
    public Text chat;

    private string inputString = "";

    private float currentTime;
    private bool checkTime = false;

    void Start()
    {
        bubble.SetActive(false);

        //string s = chat.text;
        Node node = FindObjectOfType<Node>();
        inputfield = node.input;
        node.antChat = this;
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            //chat.text = inputString;
            return;
        }
        else
        {
            if (Input.GetKey(KeyCode.Return))
            {
                ResetCheckTime();
                
            }
            
        }

        //chat.text = inputfield.text;

        UpdateCheckTime();

    }

    public void ShowBubble()
    {
        photonView.RPC("RPC_SetInputString", RpcTarget.All, inputfield.text);
    }

    private void ResetCheckTime()
    {
        currentTime = 0;
        checkTime = true;
    }

    private void UpdateCheckTime()
    {
        
        if (!checkTime)
        {
            return;
        }
        else
        {
            currentTime += Time.deltaTime;
        }


        if (currentTime >= 3)
        {
            checkTime = false;
            currentTime = 0;
            // inputString = "";
            photonView.RPC("RPC_ResetInputString", RpcTarget.All);
        }
        UpdateCheckTime();
    }

    [PunRPC]
    private void RPC_SetInputString(string s)
    {
        chat.text = s;
        bubble.SetActive(true);
        Invoke("HideBubble", 3f);
    }

    private void HideBubble()
    {
        bubble.SetActive(false);
    }

    [PunRPC]
    private void RPC_ResetInputString()
    {
        inputString = "";
    }




    ////public GameObject other;

    //    //public Text;

    //    private string inputString = "";

    //    private float currentTime = 0;
    //    private bool checkTime = false;

    //    void Start()
    //    {
    //        string Nodechat = GameObject.FindGameObjectWithTag("Chat").GetComponent<Text>();
    //        //string s = chat.text;
    //    }

    //    void Update()
    //    {
    //        if (!photonView.IsMine)
    //        {
    //            chat.text = inputString;
    //            return;
    //        }

    //        else
    //        {
    //            ResetCheckTime();
    //            photonView.RPC("RPC_SetInputString", RpcTarget.All, chat);
    //        }

    //        chat.text = inputString;

    //        UpdateCheckTime();
    //    }

    //    private void ResetCheckTime()
    //    {
    //        D("reset check time");
    //        currentTime = 0;
    //        checkTime = true;
    //    }


    //    private void UpdateCheckTime()
    //    {
    //        D("update check time");
    //        if (!checkTime)
    //        {
    //            return;
    //        }
    //        else
    //        {
    //            currentTime += Time.deltaTime;
    //        }


    //        if (currentTime >= 3)
    //        {
    //            checkTime = false;
    //            currentTime = 0;
    //            // inputString = "";
    //            photonView.RPC("RPC_ResetInputString", RpcTarget.All);
    //        }
    //    }

    //    [PunRPC]
    //    private void RPC_SetInputString(string s)
    //    {
    //        inputString = s;
    //    }

    //    [PunRPC]
    //    private void RPC_ResetInputString()
    //    {
    //        inputString = "";
    //    }


    //    public bool isDebug = true;

    //    public void D(string s)
    //    {
    //        if (photonView.IsMine || !isDebug) return;
    //        print(gameObject.transform.parent.parent.gameObject.name + " " + s);
    //    }
}
