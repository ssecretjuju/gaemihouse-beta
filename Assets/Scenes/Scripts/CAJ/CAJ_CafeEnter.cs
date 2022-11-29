using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


// JoinOrCreateRoom()을 사용해서, 방이 없으면 만들어서 입장하고 싶다
// 방의 이름은 고정되어 있어서, 지정할 필요가 없음 ! 
// 입장할 때 Instantiate로 캐릭터 생성 
public class CAJ_CafeEnter : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PhotonNetwork.LoadLevel("LYJ_Cafe");
        }
    }
}
