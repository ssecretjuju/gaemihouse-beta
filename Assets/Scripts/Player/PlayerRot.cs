using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerRot : MonoBehaviourPun
{
    // 회전 속력 
    public float rotSpeed = 200;

    //CamPos의 Transform
    public Transform CameraPivot;

    //회전값 누적 변수
    float rotX;
    float rotY;

    // Start is called before the first frame update
    void Start()
    {
        //만약에 내것이라면
        if (photonView.IsMine == true)
        {
            //camPos를 활성화 한다.
            CameraPivot.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //만약에 내것이 아니라면 함수를 나간다.
        if (photonView.IsMine == false) return;
        if (Cursor.visible == true) return;

        //1. 마우스의 움직임을 받는다.
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        //2. 마우스이 움직임값으로 회전값을 누적시킨다.
        rotX += mx * rotSpeed * Time.deltaTime;
        rotY += my * rotSpeed * Time.deltaTime;

        //3. 플레어의 회전 y값을 셋팅한다.
        transform.localEulerAngles = new Vector3(0, rotX, 0);
        //4. CamPos의 회전 x값을 셋팅한다.
        CameraPivot.localEulerAngles = new Vector3(-rotY, 0, 0);

    }
}
