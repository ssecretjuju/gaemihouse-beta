using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;



//단, CharacterController를 사용

public class AntMove_photon : MonoBehaviourPun, IPunObservable
{
    public float speed, rotationSpeed;
    private CharacterController characterController;

    private Transform tr;
    private PhotonView pv; //포톤뷰 컴포넌트
    public Transform camPivot;
    private Vector3 currPos = Vector3.zero;
    private Quaternion currRot = Quaternion.identity;

    Animator anim;

    void Awake()
    {
        gameObject.GetComponent<AntMove_photon>().enabled = false;

        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        tr = GetComponent<Transform>();
        pv = GetComponent<PhotonView>();
        pv.Synchronization = ViewSynchronization.UnreliableOnChange;
        pv.ObservedComponents[0] = this;

        //if (pv.IsMine)  //로컬이라면
        //{
        //    Camera.main.GetComponent<AntCamera>().target = camPivot;
        //}

        currPos = tr.position;
        currRot = tr.rotation;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)  //로컬 플레이어의 위치 정보 송신
        {
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
        }
        else  // 원격 플레이어의 위치 정보 수신
        {
            currPos = (Vector3)stream.ReceiveNext();
            currRot = (Quaternion)stream.ReceiveNext();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "LYJ_RoomScene")
        {
            gameObject.GetComponent<AntMove_photon>().enabled = true;
            gameObject.GetComponent<PhotonView>().enabled = true;
            gameObject.GetComponent<PhotonTransformView>().enabled = true;
            gameObject.GetComponentInChildren<PhotonAnimatorView>().enabled = true;

        }

        if (SceneManager.GetActiveScene().name == "LYJ_CharacterSelection")
        {
            return;
        }
        else
        {
            if (pv.IsMine) //로컬인 경우에 
            {
                float horizontalInput = Input.GetAxisRaw("Horizontal");
                float verticalInput = Input.GetAxisRaw("Vertical");

                Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
                float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
                movementDirection.Normalize();

                //transform.Translate(movementDirection * magnitude * Time.deltaTime, Space.World);
                characterController.SimpleMove(movementDirection * magnitude);

                if (movementDirection != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                }
            }
            else  //원격 플레이인 경우에
            {
                //원격 플레이어의 탱크를 수신받은 위치까지 부드럽게 이동(선형 보간값을 처리할 때 Lerp)
                tr.position = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 3.0f);
                //원격 플레이어의 탱크를 수신받은 각도까지 부드럽게 회전(각도 보간값을 처리할 때 Slerp)
                tr.rotation = Quaternion.Slerp(tr.rotation, currRot, Time.deltaTime * 3.0f);
            }
        }

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LYJ_CharacterSelection")
        {
            return;
        }
        else
        {
            if (pv.IsMine)
            {
                float horizontalInput = Input.GetAxisRaw("Horizontal");
                float verticalInput = Input.GetAxisRaw("Vertical");

                if (horizontalInput != 0 || verticalInput != 0)
                {
                    //상태를 Move로
                    anim.SetBool("isWalk", true);
                }
                //그렇지 않다면
                else
                {
                    //상태를 Idle로
                    anim.SetBool("isWalk", false);
                }
            }
        }
    }


}



