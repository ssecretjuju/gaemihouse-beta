using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CAJ_NickName : MonoBehaviourPunCallbacks
{
    //public string nickName;
    public Text nickName;
    public GameObject nickNamePrefab;
    private PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "LYJ_LobbyScene")
        {
            pv = GetComponent<PhotonView>();
            if (PhotonNetwork.IsConnected && photonView.IsMine)
                pv.RPC("RPCNickName", RpcTarget.AllBuffered, LoginManager.Instance.playerData.memberNickname);
        }
        if (SceneManager.GetActiveScene().name == "LYJ_LobbyScene")
        {
            nickName.text = LoginManager.Instance.playerData.memberNickname;
        }


    }


    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name != "LYJ_LobbyScene")
        {
            pv = GetComponent<PhotonView>();
            if (PhotonNetwork.IsConnected && photonView.IsMine)
                pv.RPC("RPCNickName", RpcTarget.AllBuffered, LoginManager.Instance.playerData.memberNickname);
        }

        if (SceneManager.GetActiveScene().name == "LYJ_LobbyScene")
        {
            nickName.text = LoginManager.Instance.playerData.memberNickname;
        }
    }
    [PunRPC]
    public void RPCNickName(string name)
    {
            nickName.text = name;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "LYJ_LobbyScene")
        {
            if (pv.IsMine)
            {
                if (SceneManager.GetActiveScene().name == "LYJ_CharacterSelection")
                {
                    nickNamePrefab.SetActive(false);
                }
                else
                {
                    nickNamePrefab.SetActive(true);
                }
            }
        }
    }
}
