using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class AntChat : MonoBehaviourPun
{
    public GameObject bubble;
    public Text chat;

    private string inputString = "";

    private float currentTime = 0;
    private bool checkTime = false;

    void Start()
    {
        chat =  GetComponent<Text>();
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            chat.text = inputString;
            return;
        }

        else
        {
            ResetCheckTime();
            photonView.RPC("RPC_SetInputString", RpcTarget.All, chat);
        }

        chat.text = inputString;

        UpdateCheckTime();
    }

    private void ResetCheckTime()
    {
        D("reset check time");
        currentTime = 0;
        checkTime = true;
    }


    private void UpdateCheckTime()
    {
        D("update check time");
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
    }

    [PunRPC]
    private void RPC_SetInputString(string s)
    {
        inputString = s;
    }

    [PunRPC]
    private void RPC_ResetInputString()
    {
        inputString = "";
    }


    public bool isDebug = true;

    public void D(string s)
    {
        if (photonView.IsMine || !isDebug) return;
        print(gameObject.transform.parent.parent.gameObject.name + " " + s);
    }
}
