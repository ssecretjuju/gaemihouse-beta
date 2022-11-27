using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAJ_NickName : MonoBehaviour
{
    //public string nickName;
    public Text nickNameText;


    // Start is called before the first frame update
    void Start()
    {
        nickNameText.text = LoginManager.Instance.playerData.memberNickname;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
