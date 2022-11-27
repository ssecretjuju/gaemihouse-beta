using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;



//단, CharacterController를 사용

public class AntMove_photon1 : MonoBehaviourPunCallbacks
{
    public float speed, rotationSpeed;
    private CharacterController characterController;

    private Transform tr;
    private PhotonView pv; //포톤뷰 컴포넌트
    //public Transform camPivot;
    private Vector3 currPos = Vector3.zero;
    private Quaternion currRot = Quaternion.identity;

    Animator anim;

    void Awake()
    {
        //if (SceneManager.GetActiveScene().name == "LYJ_RoomScene")
        //{
        //    gameObject.GetComponent<AntMove_photon>().enabled = true;
        //    gameObject.GetComponent<PhotonView>().enabled = true;
        //    gameObject.GetComponent<PhotonTransformView>().enabled = true;
        //    gameObject.GetComponentInChildren<PhotonAnimatorView>().enabled = true;

        //}

        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        tr = GetComponent<Transform>();
        pv = GetComponent<PhotonView>();

        //if (pv.IsMine)  //로컬이라면
        //{
        //    Camera.main.GetComponent<AntCamera>().target = camPivot;
        //}

        currPos = tr.position;
        currRot = tr.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


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



