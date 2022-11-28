using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


//단, CharacterController를 사용

public class AntMove : MonoBehaviourPunCallbacks
{
    public float speed, rotationSpeed;
    private CharacterController characterController;

    Animator anim;

    void Start()
    {
        //로비씬이면 포톤뷰스크립트들 끄기

        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "[Beta]LYJ_LobbyScene")
        {
            gameObject.GetComponent<AntMove_photon1>().enabled = false;
            gameObject.GetComponent<PhotonView>().enabled = false;
            gameObject.GetComponent<PhotonTransformView>().enabled = false;
            gameObject.GetComponentInChildren<PhotonAnimatorView>().enabled = false;

        }

        if (SceneManager.GetActiveScene().name == "LYJ_RoomScene")
        {
            gameObject.GetComponent<AntMove>().enabled = false;
            //gameObject.GetComponent<AntMove_photon>().enabled = true;
            gameObject.GetComponent<AntMove_photon1>().enabled = true;
        }


        if (SceneManager.GetActiveScene().name == "LYJ_CharacterSelection")
        {
            return;
        }
        else
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

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LYJ_CharacterSelection")
        {
            return;
        }
        else
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



