using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;



//��, CharacterController�� ���

public class AntMove_photon : MonoBehaviourPun, IPunObservable
{
    public float speed, rotationSpeed;
    private CharacterController characterController;

    private Transform tr;
    private PhotonView pv; //����� ������Ʈ
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

        //if (pv.IsMine)  //�����̶��
        //{
        //    Camera.main.GetComponent<AntCamera>().target = camPivot;
        //}

        currPos = tr.position;
        currRot = tr.rotation;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)  //���� �÷��̾��� ��ġ ���� �۽�
        {
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
        }
        else  // ���� �÷��̾��� ��ġ ���� ����
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
            if (pv.IsMine) //������ ��쿡 
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
            else  //���� �÷����� ��쿡
            {
                //���� �÷��̾��� ��ũ�� ���Ź��� ��ġ���� �ε巴�� �̵�(���� �������� ó���� �� Lerp)
                tr.position = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 3.0f);
                //���� �÷��̾��� ��ũ�� ���Ź��� �������� �ε巴�� ȸ��(���� �������� ó���� �� Slerp)
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
                    //���¸� Move��
                    anim.SetBool("isWalk", true);
                }
                //�׷��� �ʴٸ�
                else
                {
                    //���¸� Idle��
                    anim.SetBool("isWalk", false);
                }
            }
        }
    }


}



