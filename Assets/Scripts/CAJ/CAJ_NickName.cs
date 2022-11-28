using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CAJ_NickName : MonoBehaviour
{
    //public string nickName;
    public Text nickName;
    public GameObject nickNamePrefab;


    // Start is called before the first frame update
    void Start()
    {
        nickName.text = LoginManager.Instance.playerData.memberNickname;

        
    }

    // Update is called once per frame
    void Update()
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
